using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using GPSAgent.Data;
using GPSAgent.Extensions;
using GPSAgent.Net;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
//using System.Collections;

namespace GPSAgent.Components.Form
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        #region Constant
        private const int MAX_LIMIT = 20000;
        #endregion

        #region Private
        private Server m_Server = null;
        private DataBaseDB DB_Server = null;
        private FixedSizedQueue<Log> m_Logs = new FixedSizedQueue<Log>() { Limit = MAX_LIMIT };
        #endregion



        #region Constructor
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        protected override void OnLoad(EventArgs e)
        {
            this.CtrlLogListView.Columns.Add(new ColumnHeader() { Text = "Type" });
            this.CtrlLogListView.Columns.Add(new ColumnHeader() { Text = "Message", Width = this.CtrlLogListView.ClientRectangle.Width - this.CtrlLogListView.Columns[0].Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth });
            this.CtrlLogListView.VirtualListSize = 0;
            this.labelDBserver.Text = Properties.Settings.Default.Server;
            this.labelDB.Text = Properties.Settings.Default.DB;
            labelProgramStarted.Text = DateTime.Now.ToLongDateString();

            base.OnLoad(e);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Reads Application configuration
            System.Diagnostics.Trace.WriteLine("Reading Application configuration...");
            AppConfig oAppCfg = AppConfig.Get();

            // Adds default configuration if none exists
            if (oAppCfg.GPSTrackers.Count == 0)
            {
                oAppCfg = AppConfig.Default();
                AppConfig.Save(oAppCfg);
            }

            // Adds to ComboBox
            foreach (object o in oAppCfg.GPSTrackers)
                this.CtrlDeviceList.Items.Add(o);

            FormLogin login = new FormLogin();
            login.ShowDialog();
            #region DEBUG
            // watch GPS tracker format
            //sos
            //line = "#123456789#watch#0#0000#SOS#1#V#10144.9898,E,031232.434,N,000.47,136#110913#005541##";
            //auth
            //line = "#356823031187318#TK333#1#0000#AUT#10#V#10144.9829,E,0312.5777,N,000.12,790000#230713#013707#V#10144.9833,E,0312.5786,N,000.02,790000#230713#013737#V#10144.9836,E,0312.5800,N,000.28,790000#230713#013807#V#10144.9832,E,0312.5808,N,000.17,790000#230713#013831#V#10144.9803,E,0312.5799,N,000.28,260#230713#013907#V#10144.9805,E,0312.5816,N,000.47,260#230713#013936#V#10144.9889,E,0312.5880,N,000.78,730000#230713#014006#V#10144.9887,E,0312.5908,N,000.32,590000#230713#014036#V#10144.9884,E,0312.5897,N,000.22,590000#230713#014106#V#10144.9874,E,0312.5900,N,000.16,590000#230713#014131##";

            //auth2
            //line = "#356823031187318#TK333#1#0000#AUT#10#V#10144.9832,E,0312.5808,N,000.17,790000#230713#013831#V#10144.9803,E,0312.5799,N,000.28,260#230713#013907#V#10144.9805,E,0312.5816,N,000.47,260#230713#013936#V#10144.9889,E,0312.5880,N,000.78,730000#230713#014006#V#10144.9887,E,0312.5908,N,000.32,590000#230713#014036#V#10144.9884,E,0312.5897,N,000.22,590000#230713#014106#V#10144.9874,E,0312.5900,N,000.16,590000#230713#014131##";


            //auth3
            //line = "#356823031187318#TK333#1#0000#AUT#10#V#10144.9829,E,0312.5777,N,000.12,790000#230713#013707#V#10144.9833,E,0312.5786,N,000.02,790000#230713#013737#V#10144.9836,E,0312.5800,N,000.28,790000#230713#013807#V#10144.9832,E,0312.5808,N,000.17,790000#230713#013831#V#10144.9803,E,0312.5799,N,000.28,260#230713#013907#V#10144.9805,E,0312.5816,N,000.47,260#230713#013936#V#10144.9889,E,0312.5880,N,000.78,730000#230713#014006#V#10144.9887,E,0312.5908,N,000.32,590000#230713#014036#V#10144.9884,E,0312.5897,N,000.22,590000#230713#014106#V#10144.9874,E,0312.5900,N,000.16,590000#230713#014131#V#10144.9874,E,0312.5900,N,000.16,590000#230713#014131##";

            //TK GPS tracker format
            //const string s1 = "#135790246811222#13486119277#1#0000#SOS#1#27bc10af#11407.4182,E,2232.7632,N,0.00,79.50#070709#134147.000##";
            //GPSAgent.GPS.TrackerData o1 = GPS.TrackerData.Parse(GPS.TrackerData.DeviceModel.TK333, s1);
            //const string s2 = "090907070718,13145826175,GPRMC,070718.000,A,2234.0228,N,11403.0764,E,0.00,,070909,,,A*73,F,,imei:354776030042714,05,50.1,F:4.11V,0,132,40512,460,01,2533,720B";
            //GPSAgent.GPS.TrackerData o2 = GPS.TrackerData.Parse(GPS.TrackerData.DeviceModel.TK102B, s2);
            #endregion
        }

        private void CtrlLogListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            Log o = this.m_Logs[e.ItemIndex];
            e.Item = o.Item;
        }
        private void CtrlDeviceEditButton_Click(object sender, EventArgs e)
        {
            GPSTracker oSelected = this.CtrlDeviceList.SelectedItem as GPSTracker;
            using (FormEdit f = new FormEdit(oSelected))
            {
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    oSelected.ServerPort = f.GPSTracker.ServerPort;

                    AppConfig oAppConfig = AppConfig.Get();
                    foreach (GPSTracker o in oAppConfig.GPSTrackers)
                    {
                        if (o.Equals(f.GPSTracker))
                        {
                            o.ServerPort = f.GPSTracker.ServerPort;
                            o.ServerMaxConnections = f.GPSTracker.ServerMaxConnections;
                            break;
                        }
                    }
                    AppConfig.Save(oAppConfig);
                }
            }
        }
        private void CtrlDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CtrlDeviceEditButton.Enabled = this.CtrlServerStartButton.Enabled = this.CtrlDeviceList.SelectedIndex != -1 ? true : false;
        }
        private void CtrlServerStartButton_Click(object sender, EventArgs e)
        {
            if (this.CtrlServerStartButton.Text.Equals("Start"))
            {
                this.CtrlDeviceList.Enabled = false;
                this.CtrlDeviceEditButton.Enabled = false;
                this.CtrlServerStartButton.Enabled = false;
                this.CtrlServerStatusText.ForeColor = Color.Gray;
                this.CtrlServerStatusText.Text = "Starting...";

                Application.DoEvents();

                GPSTracker oGPSTracker = this.CtrlDeviceList.SelectedItem as GPSTracker;

                try
                {
                    this.m_Server = new Server(oGPSTracker);
                    this.DB_Server = new DataBaseDB();

                    this.m_Server.OnClientConnected += this.Server_OnClientConnected;
                    this.m_Server.OnClientDisconnected += this.Server_OnClientDisconnected;
                    this.m_Server.OnError += this.Server_OnError;
                    this.m_Server.OnMessageReceived += this.Server_OnMessageReceived;
                    this.m_Server.Start();

                    this.LogAddInfo("Listening on ported " + oGPSTracker.ServerPort);
                    //listBoxGPSpacket.Items.Add("Listening on ported: " + oGPSTracker.ServerPort);
                    //FormReceiver ii = (FormReceiver)Application.OpenForms["FormReceiver"];
                    //ii.listBoxGpsData.Items.Add("Listening on ported " + oGPSTracker.ServerPort);

                    this.CtrlServerStartButton.Text = "Stop";
                    this.CtrlServerStartButton.Enabled = true;
                    this.CtrlServerStatusText.ForeColor = Color.Blue;
                    this.CtrlServerStatusText.Text = "Online";
                   // GeofenceIDlist.Add("x");
                    timer1.Enabled = true;
                    timer1.Start();
                    this.CtrlClientsLabel.Visible = this.CtrlClientsText.Visible = true;
                    this.labelProgramStarted.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (this.m_Server != null)
                    {
                        this.m_Server.OnClientConnected -= this.Server_OnClientConnected;
                        this.m_Server.OnClientDisconnected -= this.Server_OnClientDisconnected;
                        this.m_Server.OnError -= this.Server_OnError;
                        this.m_Server.OnMessageReceived -= this.Server_OnMessageReceived;
                        this.m_Server.Dispose();
                        this.m_Server = null;
                    }

                    // Reset to initial state
                    this.m_Logs.Clear();
                    this.CtrlLogListView.VirtualListSize = 0;

                    this.CtrlDeviceList.Enabled = true;
                    this.CtrlDeviceEditButton.Enabled = true;
                    this.CtrlServerStartButton.Text = "Start";
                    this.CtrlServerStartButton.Enabled = true;
                    this.CtrlServerStatusText.Text = "Offline";
                    this.CtrlServerStatusText.ForeColor = Color.Red;
                    this.CtrlClientsText.Text = "0";
                    this.CtrlClientsLabel.Visible = this.CtrlClientsText.Visible = false;
                }
            }
            else if (this.CtrlServerStartButton.Text.Equals("Stop"))
            {
                if (this.m_Server != null)
                {
                    this.m_Server.OnClientConnected -= this.Server_OnClientConnected;
                    this.m_Server.OnClientDisconnected -= this.Server_OnClientDisconnected;
                    this.m_Server.OnError -= this.Server_OnError;
                    this.m_Server.OnMessageReceived -= this.Server_OnMessageReceived;
                    this.m_Server.Dispose();
                    this.m_Server = null;
                }

                // Reset to initial state
                this.m_Logs.Clear();
                this.CtrlLogListView.VirtualListSize = 0;

                this.CtrlDeviceList.Enabled = true;
                this.CtrlDeviceEditButton.Enabled = true;
                this.CtrlServerStartButton.Text = "Start";
                this.CtrlServerStartButton.Enabled = true;
                this.CtrlServerStatusText.Text = "Offline";
                this.CtrlServerStatusText.ForeColor = Color.Red;
                this.CtrlClientsText.Text = "0";
                timer1.Enabled = false;
                timer1.Stop();
                this.CtrlClientsLabel.Visible = this.CtrlClientsText.Visible = false;
            }
        }


        string imei;
        string mode;
        string datetime;
        string GPStrackerSimnumber;
        string DataExistStatus;
        string GMTzonetime;
        string Uknown;
        string Latitude;
        string Longitude;
        string Speed;
        string Direction;
        string TracKiD;
        string SimNUM;
        DB oo = new DB();
        string holdimei;
        int countDevice = 0;
        int countPacketData = 0;
        string holdxory;
        List<string> listGPS = new List<string>();
        List<string> listofImeiNo = new List<string>();
        int i = 0;
        int APNi = 0;
        //int packetcounted = 0;
        //int countLitsGPS = 0;
        private void Server_OnMessageReceived(string szMessage, GPSTracker oGPSTracker, EndPoint oEndPoint)
        {
            //  GPSTrackerCobanFamily(szMessage);
            if (szMessage.Contains("imei:"))
            {
                GPSTrackerCobanFamily(szMessage);

            } if (szMessage.Contains("["))
            {
                MSIproject(szMessage);

            }
            else
            {
               // AngkasaProject(szMessage);
                this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Uknown Message received Raw Data " + szMessage);
            }



        }
        private void Server_OnError(Exception ex)
        {
            this.LogAddError(ex);
            //FormReceiver ii = (FormReceiver)Application.OpenForms["FormReceiver"];
            //ii.listBoxGpsData.Items.Add("Error " + ex.ToString());
        }
        private void Server_OnClientConnected(int iTotalClient, System.Net.EndPoint oEndPoint)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                listBoxGPSpacket.Items.Add("Incoming connection from " + oEndPoint.ToString());
                countrow = listBoxGPSpacket.Items.Count;
                this.CtrlClientsText.Text = iTotalClient.ToString();
                //this.LogAddInfo("Incoming connection from " + oEndPoint.ToString());
                //  AngkasaProject("#356823031187318#TK333#1#0000#AUT#10#V#10144.9832,E,0312.5808,N,000.17,790000#230713#013831#V#10144.9803,E,0312.5799,N,000.28,260#230713#013907#V#10144.9805,E,0312.5816,N,000.47,260#230713#013936#V#10144.9889,E,0312.5880,N,000.78,730000#230713#014006#V#10144.9887,E,0312.5908,N,000.32,590000#230713#014036#V#10144.9884,E,0312.5897,N,000.22,590000#230713#014106#V#10144.9874,E,0312.5900,N,000.16,590000#230713#014131##");

                //FormReceiver ii = (FormReceiver)Application.OpenForms["FormReceiver"];
                //ii.listBoxGpsData.Items.Add("Incoming connection from " + oEndPoint.ToString());
                //listBoxGPSpacket.Items.Add("Incoming connection from " + oEndPoint.ToString());
            }));
        }
        private void Server_OnClientDisconnected(int iTotalClient, System.Net.EndPoint oEndPoint)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.CtrlClientsText.Text = iTotalClient.ToString();
                this.LogAddInfo("Disconnected from " + oEndPoint.ToString());
                countrow = listBoxGPSpacket.Items.Count;
                listGPS.Clear();
                //FormReceiver ii = (FormReceiver)Application.OpenForms["FormReceiver"];
                //ii.listBoxGpsData.Items.Add("Disconnected from " + oEndPoint.ToString());
                //   listBoxGPSpacket.Items.Add("Disconnected from " + oEndPoint.ToString());
            }));
        }
        #endregion

        #region Method
        int countrow;
        private void LogAddInfo(string szMessage)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    //this.m_Logs.Enqueue(new Log(Log.LogType.INFO, szMessage));
                    listBoxGPSpacket.Items.Add(szMessage);
                    labelCountedPacket.Text = countPacketData.ToString();
                    countrow = listBoxGPSpacket.Items.Count;
                    listBoxGPSpacket.SelectedIndex = countrow - 1;
                    // labelDeviceCount.Text = countDevice.ToString();
                    labelDeviceConnected.Text = "Devices Counted:" + countDevice.ToString();

                    //this.CtrlLogListView.VirtualListSize = this.m_Logs.Count;
                    // this.CtrlLogListView.Items[this.CtrlLogListView.Items.Count - 1].EnsureVisible();

                }));
            }
            catch (Exception v)
            {
                listBoxGPSpacket.Items.Add("LogAddInfo Error:" + v.ToString());
                countrow = listBoxGPSpacket.Items.Count;
                // this.m_Logs.Enqueue(new Log(Log.LogType.INFO,"LogAddInfo Error:" + v.ToString()));
                // this.CtrlLogListView.VirtualListSize = this.m_Logs.Count;
                //this.CtrlLogListView.Items[this.CtrlLogListView.Items.Count - 1].EnsureVisible();
            }
        }



        private void LogDeviceCount(int DeviceCount)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    //this.m_Logs.Enqueue(new Log(Log.LogType.INFO, szMessage));

                    labelDeviceConnected.Text = "Devices Counted:" + DeviceCount.ToString();

                    //this.CtrlLogListView.VirtualListSize = this.m_Logs.Count;
                    // this.CtrlLogListView.Items[this.CtrlLogListView.Items.Count - 1].EnsureVisible();

                }));
            }
            catch (Exception v)
            {
                listBoxGPSpacket.Items.Add("LogAddInfo Error:" + v.ToString());
                countrow = listBoxGPSpacket.Items.Count;
                // this.m_Logs.Enqueue(new Log(Log.LogType.INFO,"LogAddInfo Error:" + v.ToString()));
                // this.CtrlLogListView.VirtualListSize = this.m_Logs.Count;
                //this.CtrlLogListView.Items[this.CtrlLogListView.Items.Count - 1].EnsureVisible();
            }
        }
        private void LogAddError(Exception ex)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    listBoxGPSpacket.Items.Add("LogAddError:" + ex.Message.ToString());
                    countrow = listBoxGPSpacket.Items.Count;
                    //this.m_Logs.Enqueue(new Log(Log.LogType.ERROR, "LogAddError:" + ex.Message.ToString()));
                    //this.CtrlLogListView.VirtualListSize = this.m_Logs.Count;
                    //this.CtrlLogListView.Items[this.CtrlLogListView.Items.Count - 1].EnsureVisible();
                }));
            }
            catch (Exception v)
            {

                listBoxGPSpacket.Items.Add("LogAddError:" + v.ToString());
                countrow = listBoxGPSpacket.Items.Count;
                //this.m_Logs.Enqueue(new Log(Log.LogType.ERROR, v.ToString()));
                //this.CtrlLogListView.VirtualListSize = this.m_Logs.Count;
                //this.CtrlLogListView.Items[this.CtrlLogListView.Items.Count - 1].EnsureVisible();
            }
        }
        #endregion



        #region Class
        /// <summary>
        /// Virtual ListView item
        /// </summary>
        private class Log
        {
            public enum LogType
            {
                INFO,
                ERROR
            }

            public Log(LogType iType, string szMessage)
            {
                this.Item = new ListViewItem(new string[] { iType.ToString(), szMessage }) { Tag = this };
            }

            public ListViewItem Item { get; private set; }
        }
        /// <summary>
        /// Fixed sized Queue
        /// </summary>
        public class FixedSizedQueue<T>
        {
            ConcurrentQueue<T> q = new ConcurrentQueue<T>();

            public T this[int index]
            {
                get
                {
                    return q.ElementAt(index);
                }
            }
            public int Limit { get; set; }
            public void Enqueue(T obj)
            {
                q.Enqueue(obj);
                lock (this)
                {
                    T overflow;
                    while (q.Count > Limit && q.TryDequeue(out overflow)) ;
                }
            }
            public void Clear()
            {
                T item;
                while (q.TryDequeue(out item))
                {
                    // do nothing
                }
            }

            public int Count
            {
                get
                {
                    return q.Count;
                }
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            // oo.insertGPSdata("NA", "NA", "NA", "none", "NA", "none", "GPRS mode", "NA", "NA", "NA", "NA", "WTP2681j", "+601110976958", "NA");
         //   oo.insertGPSdata("NA", "NA", "NA", "none", "NA", "none", "GPRS mode", "10142.5559", "0305.9742", Speed, Direction, "WTP2687", "+601110976958", "NA");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            oo.GetSimNumTrackID("359710048057492");
            string TracKiD = oo.TrackingID;
            string SimNUM = oo.SimNumber;
            MessageBox.Show(TracKiD + "," + SimNUM);
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDB h = new FormDB();
            h.Show();


        }

        private void commadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.CtrlDeviceList.SelectedIndex = 1;
            //GPSTracker oSelected = this.CtrlDeviceList.SelectedItem as GPSTracker;
            //using (FormEdit f = new FormEdit(oSelected))
            //{
            //    if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        oSelected.ServerPort = f.GPSTracker.ServerPort;

            //        AppConfig oAppConfig = AppConfig.Get();
            //        foreach (GPSTracker o in oAppConfig.GPSTrackers)
            //        {
            //            if (o.Equals(f.GPSTracker))
            //            {
            //                o.ServerPort = f.GPSTracker.ServerPort;
            //                o.ServerMaxConnections = f.GPSTracker.ServerMaxConnections;
            //                break;
            //            }
            //        }
            //        AppConfig.Save(oAppConfig);
            //    }
            //}

            FormReceiver fr = new FormReceiver();
            fr.Show();
        }

        private void CtrlClientsText_Click(object sender, EventArgs e)
        {

        }

        private void CtrlServerGroup_Enter(object sender, EventArgs e)
        {

        }

        private void trafficToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            //////////listBoxGPSpacket.Items.Clear();
            //////////GeofenceIDlist.Clear();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void subscriberAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAccountMain frmAccountMain = new FormAccountMain();
            frmAccountMain.Show();
        }

        private void activatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // webBrowser1.Url("");
            tabControl1.SelectedTab = tabPage2;
            if (Properties.Settings.Default.SetUrl.Length > 1)
            {
                webBrowser1.ScriptErrorsSuppressed = true;
                webBrowser1.Navigate(Properties.Settings.Default.SetUrl);
            }
            else
            {
                MessageBox.Show("URL Not Setup..!!!");
            }

            // webBrowser1.Navigate("http://drms.dsmaf.mil.my");
        }

        private void setUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSetUrlGeofenceMonitoring frmSetUrl = new FormSetUrlGeofenceMonitoring();
            frmSetUrl.Show();
        }

        private void geofencesMonitoringCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void viewTracfficSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void sMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSetSMSpathprogram frmSetPath = new FormSetSMSpathprogram();
            frmSetPath.Show();
        }

        private void launchProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.SMSpathprogram.Length > 1)
            {
                try
                {
                    Process.Start(Properties.Settings.Default.SMSpathprogram);
                }
                catch (Exception g)
                {
                    MessageBox.Show(g.ToString());
                }
            }
            else
            {
                MessageBox.Show("Path SMS Program Not Setup..!!!");
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            var result = MessageBox.Show("quit application", "confirmation",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
        }

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {



            FormLoginAdmin la = new FormLoginAdmin();
            la.ShowDialog();
            // //or 
            // string message, title, defaultValue;
            // string myValue;
            // // Set prompt. 
            // message = "Enter Admin Password";
            // // Set title. 
            // title = "Admin Password";
            // // Set default value. 
            // defaultValue = "";//Display message, title, and default value. 
            // myValue = Interaction.InputBox(message, title, defaultValue, 100, 100);// If user has clicked Cancel, set myValue to defaultValue 


            // if (myValue == Properties.Settings.Default.PWD1 || myValue == Properties.Settings.Default.PWD2)
            //{
            //    FormAdminInfo ai = new FormAdminInfo();
            //    ai.Show();

            //}else
            // {
            //     MessageBox.Show("Error Password.!!!!");
            // }



            //if (myValue == "")
            //{
            //    myValue = defaultValue;

            //    MessageBox.Show(myValue);



            //}
            //else
            //{
            //    //MessageBox.Show(myValue);





            //}


        }

        private void lockSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.ShowDialog();
        }

        private void clearDeviceCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listofImeiNo.Clear();
            labelDeviceConnected.Text = "Devices Counted: 0";
        }

        private void autoFenceTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAutoFenceTimer ft = new FormAutoFenceTimer();
            ft.Show();
        }


        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormAbout ab = new FormAbout();
            ab.ShowDialog();
        }



        # region GPSdataExtractor(MSI project)
     //   [SG*8800000015*0087*UD,220414,134652,A,22.571707,N,113.8613968,E,0.1,0.0,100,7,60,90,1000,50,0000,4,1,460,0,9360,4082,131,9360,4092,148,9360,4091,143,9360,4153,141]
    public void MSIproject(string data)
        {
            string MSIIdDevice;
        string SignalStatus;
        string Longituted;
        string Latituded;
        string Speed;
        string WatchGPSdata;
        string Directions;
        int Altitude;
        string BateryReading;
        int GSMSignalReading;
        string TerminalState;
        string APN;

        List<string> GPSdatas = new List<string>();


        if (data.Contains("LK"))
        {
            this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
            return;
        }



          if (countPacketData > 4000)
            {
                countPacketData = 0;
                //listBoxGPSpacket.Items.Clear();
                oo.deleteAllsignal();
            }
            WatchGPSdata = data.Replace("*", ",");
            //  string[] GPSdata = new string[13];

            listGPS.Clear();
            GPSdatas.Clear();
            //   this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);

            listGPS.Add(WatchGPSdata);


            this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
            try
            {
                foreach (string packetGps in listGPS)
                {


                    string[] vMessageChunks = packetGps.Split(',');
                    foreach (string dtGPS in vMessageChunks)
                    {

                        GPSdatas.Add(dtGPS);
                        this.LogAddInfo(" Count: " + i.ToString() + "   Split Data :" + dtGPS);
                        i = i + 1;
                    }
                }
                i = 0;
                MSIIdDevice = GPSdatas[1].ToString();
                SignalStatus = GPSdatas[6].ToString();
                Latituded = GPSdatas[7].ToString();
                Longituted = GPSdatas[9].ToString();
                Speed = GPSdatas[11].ToString();
                Directions = GPSdatas[12].ToString();
                Altitude = Convert.ToInt32(GPSdatas[13].ToString());
                GSMSignalReading = Convert.ToInt32(GPSdatas[15].ToString());
                BateryReading = GPSdatas[16].ToString();
                TerminalState = GPSdatas[19].ToString();
              




                Regex MyRegex = new Regex("[^a-z@,:_]", RegexOptions.IgnoreCase);              
                string APNData = MyRegex.Replace(data + "_{ (7 438 ?. !`", @"");
                string WPSApn = "";



                string[] APNChunks = APNData.Split(',');
                foreach (string DetectedAPN in APNChunks)
                {

                    //    GPSdatas.Add(dtGPS);
                    if (!DetectedAPN.Contains(":") && DetectedAPN.Length > 1 && !DetectedAPN.Contains("UD"))
                    {
                        // MessageBox.Show(" Count: " + APNi.ToString() + "   Split Data :" + DetectedAPN);
                        WPSApn += DetectedAPN + ',';
                    }

                    APNi = APNi + 1;
                }

                APNi = 0;

                WPSApn = WPSApn.Remove(WPSApn.Length - 1);

                if (MSIIdDevice != holdimei)
                {
                    holdimei = MSIIdDevice;
                    if (!listofImeiNo.Contains(MSIIdDevice))
                    {
                        countDevice = countDevice + 1;
                        LogDeviceCount(countDevice);
                    }
                    listofImeiNo.Add(MSIIdDevice);
                    //oo.GetSimNumTrackID(MSIIdDevice);
                    //TracKiD = oo.TrackingID;
                    //SimNUM = oo.SimNumber;


                }

                //oo.insertGPSdata(MSIIdDevice, MSIIdDevice, "NA", "NA", SignalStatus, "NA",
                //    "NA", Longituted, Latituded, Speed, Directions, MSIIdDevice, SimNUM, BateryReading, Altitude, GSMSignalReading, TerminalState, WPSApn);
            }catch (Exception b)
            {
                listGPS.Clear();
                GPSdatas.Clear();
                this.LogAddInfo("parsed MSIproject error :" + b.ToString());
            }
    

        }

        #endregion








        # region GPSdataExtractor(model wt100 and TK102)
       


        private void AngkasaProject(string data)
        {
            //#IMEI No.#User ID#Status#password#data type#packet’s numbers#GSM base station code#longitude,latitude,speed,direction#date#time#GSM base station code#longitude,latitude,speed,direction#date#time#....##
            //  "#356823031187318#TK333#1#0000#AUT#10#V#10144.9832,E,0312.5808,N,000.17,790000#230713#013831#V#10144.9803,E,0312.5799,N,000.28,260#230713#013907#V#10144.9805,E,0312.5816,N,000.47,260#230713#013936#V#10144.9889,E,0312.5880,N,000.78,730000#230713#014006#V#10144.9887,E,0312.5908,N,000.32,590000#230713#014036#V#10144.9884,E,0312.5897,N,000.22,590000#230713#014106#V#10144.9874,E,0312.5900,N,000.16,590000#230713#014131##";
 string AngkasaImeiNo;
        string AngkasaUid;
        string AngkasaStatus;
        string AngkasaPassword;
        string AngkasaDataType;
        string AngkasaPacketNumber;
        string AngkasaGSMbaseStation;
        string AngkasaLongitude;
        //  string AngkasaLongitudeE;
        string AngkasaLatitude;
        //  string AngkasaLatitudeN;
        string AngkasaSpeed;
        string AngkasaDirection;
        string WatchGPSdata;
        List<string> GPSdatas = new List<string>();
            if (countPacketData > 4000)
            {
                countPacketData = 0;
                //listBoxGPSpacket.Items.Clear();
                oo.deleteAllsignal();
            }
            WatchGPSdata = data.Replace("#", ",");
            //  string[] GPSdata = new string[13];

            listGPS.Clear();
            GPSdatas.Clear();
            //   this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);

            listGPS.Add(WatchGPSdata);
            this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
            try
            {
                foreach (string packetGps in listGPS)
                {


                    string[] vMessageChunks = packetGps.Split(',');
                    foreach (string dtGPS in vMessageChunks)
                    {

                        GPSdatas.Add(dtGPS);
                        this.LogAddInfo(" Count: " + i.ToString() + "   Split Data :" + dtGPS);
                        i = i + 1;
                    }
                }
                i = 0;
                AngkasaImeiNo = GPSdatas[1].ToString();
                AngkasaUid = GPSdatas[2].ToString();
                AngkasaStatus = GPSdatas[3].ToString();
                AngkasaPassword = GPSdatas[4].ToString();
                AngkasaDataType = GPSdatas[5].ToString();
                AngkasaPacketNumber = GPSdatas[6].ToString();
                AngkasaGSMbaseStation = GPSdatas[7].ToString();
                AngkasaLongitude = GPSdatas[8].ToString();
                AngkasaLatitude = GPSdatas[10].ToString();
                AngkasaSpeed = GPSdatas[12].ToString();
                AngkasaDirection = GPSdatas[13].ToString();

                if (AngkasaImeiNo != holdimei)
                {
                    holdimei = AngkasaImeiNo;
                    if (!listofImeiNo.Contains(imei))
                    {
                        countDevice = countDevice + 1;
                    }
                    listofImeiNo.Add(imei);
                    oo.GetSimNumTrackID(AngkasaImeiNo);
                    TracKiD = oo.TrackingID;
                    SimNUM = oo.SimNumber;


                }

           //     oo.insertGPSdata(AngkasaImeiNo, AngkasaImeiNo, AngkasaGSMbaseStation, AngkasaPassword, AngkasaStatus, AngkasaPacketNumber, AngkasaGSMbaseStation, AngkasaLongitude, AngkasaLatitude, AngkasaSpeed, AngkasaDirection, TracKiD, SimNUM, "NA");

                //if (TracKiD.Length > 1)
                //{
                //    countPacketData = countPacketData + 1;

                //    //if(holdxory !=Latitude)
                //    //{
                //    oo.insertGPSdata(imei, imei, DataExistStatus, "none", mode, "none", "GPRS mode", AngkasaLongitude, AngkasaLatitude, AngkasaSpeed, AngkasaDirection, TracKiD, SimNUM, "NA");
                //    // holdxory = Latitude;

                //    //}else
                //    //{
                //    //    this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | SAME LOCATION DETECTED.!! " + szMessage);
                //    //}


                //}



            }
            catch (Exception g)
            {

                listGPS.Clear();
                GPSdatas.Clear();
                this.LogAddInfo("parsed AngkasaProject error  :" + g.ToString());
                //    countrow = listBoxGPSpacket.Items.Count;

            }



        }


        public void GPSTrackerCobanFamily(string data)
        {


            string AngkasaImeiIndicated;
            string AngkasaImeiNo;
            string AngkasaUid;
            string AngkasaStatus;
            string AngkasaPassword;
            //string AngkasaDataType;
            //string AngkasaPacketNumber;
            //string AngkasaGSMbaseStation;
            string AngkasaLongitude;
            string AngkasaDatetime;
            string AngkasaLocalTime;
            string AngkasaAvaiablity;
            //  string AngkasaLongitudeE;
            string AngkasaLatitude;
            //  string AngkasaLatitudeN;
            string AngkasaSpeed;
            string AngkasaDirection;
            string WatchGPSdata;
            List<string> GPSdatas = new List<string>();
            if (countPacketData > 4000)
            {
                countPacketData = 0;
                //listBoxGPSpacket.Items.Clear();
                oo.deleteAllsignal();
            }
            WatchGPSdata = data.Replace(":", ",");
            //  string[] GPSdata = new string[13];

            listGPS.Clear();
            GPSdatas.Clear();
            //   this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);

            listGPS.Add(WatchGPSdata.Replace(";", ","));
            this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
            try
            {
                foreach (string packetGps in listGPS)
                {


                    string[] vMessageChunks = packetGps.Split(',');
                    foreach (string dtGPS in vMessageChunks)
                    {

                        GPSdatas.Add(dtGPS);
                        this.LogAddInfo(" Count: " + i.ToString() + "   Split Data :" + dtGPS);
                        i = i + 1;
                    }
                }
                i = 0;
                AngkasaImeiIndicated = GPSdatas[0].ToString();

                if (AngkasaImeiIndicated.Contains("imei"))
                {
                    AngkasaImeiNo = GPSdatas[1].ToString();
                    AngkasaUid = GPSdatas[2].ToString();
                    AngkasaDatetime = GPSdatas[3].ToString();
                    AngkasaPassword = GPSdatas[4].ToString();
                    AngkasaStatus = GPSdatas[5].ToString();
                    AngkasaLocalTime = GPSdatas[6].ToString();
                    AngkasaAvaiablity = GPSdatas[7].ToString();
                    AngkasaLongitude = GPSdatas[8].ToString();
                    AngkasaLatitude = GPSdatas[10].ToString();
                    AngkasaSpeed = GPSdatas[12].ToString();
                    AngkasaDirection = GPSdatas[13].ToString();

                    if (AngkasaImeiNo != holdimei)
                    {
                        holdimei = AngkasaImeiNo;
                        if (!listofImeiNo.Contains(imei))
                        {
                            countDevice = countDevice + 1;
                        }
                        listofImeiNo.Add(imei);
                        oo.GetSimNumTrackID(AngkasaImeiNo);
                        TracKiD = oo.TrackingID;
                        SimNUM = oo.SimNumber;


                    }

                    oo.insertGPSdataNonMSI(AngkasaImeiNo, AngkasaImeiNo, AngkasaDatetime, AngkasaPassword, AngkasaStatus, AngkasaLocalTime, AngkasaAvaiablity, AngkasaLongitude, AngkasaLatitude, AngkasaSpeed, AngkasaDirection, TracKiD, SimNUM, "NA");

                }



            }
            catch (Exception g)
            {

                listGPS.Clear();
                GPSdatas.Clear();
                this.LogAddInfo("parsed GPSTrackerCobanFamily error :" + g.ToString());
                //    countrow = listBoxGPSpacket.Items.Count;

            }







        }
        #endregion
       


        # region AutoFenceTimer
        FormDB con = new FormDB(); private string connstring;
        string[] DiagArray = new string[13];
        string[] RAArray = new string[4];        
        List<string> GeofenceIDlist = new List<string>();
    


    

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<string> AutoFenceTimerID = AutoFenceTimergetByIDStatus("Active");
            foreach (string afID in AutoFenceTimerID)
            {
                ExtractData(afID);

            }

        }
        private void ExtractData(string IDi)
        {
            int Count = 0;
            int CountRA = 0;

            List<string> AutoFenceTimertbl = AutoFenceTimergetDataByID(IDi);
            foreach (string AutoFenceTimerData in AutoFenceTimertbl)
            {
                DiagArray[Count] = AutoFenceTimerData;

                if (Count == 12)
                {
                    string ID = DiagArray[0].ToString();
                    string CreatedDate = DiagArray[1].ToString();
                    string TrackItem = DiagArray[2].ToString();
                    string TrackID = DiagArray[3].ToString();
                    string AccountNo = DiagArray[4].ToString();
                    string FencePath = DiagArray[5].ToString();
                    string ShapeType = DiagArray[6].ToString();
                    string FenceAreaName = DiagArray[7].ToString();
                    string TimeFrom = DiagArray[8].ToString();
                    string TimeTo = DiagArray[9].ToString();
                    string DaySetting = DiagArray[10].ToString();
                    string Status = DiagArray[11].ToString();
                    string FenceLength = DiagArray[12].ToString();
                    //txtStart.Text = TimeFrom;
                    //txtStop.Text = TimeTo;
                    //   MessageBox.Show(ID + '-' + CreatedDate + '-' + TrackItem + '-' + TrackID + '-' + AccountNo + '-' + FencePath + '-' + ShapeType + '-' + FenceAreaName + '-' + TimeFrom + '-' + TimeTo + '-' + DaySetting + '-' + Status + '-' + FenceLength);

                    Count = 0;
                    List<string> ResponderAlertTbl = AutoFenceTimergetResponderAlert(AccountNo);
                    foreach (string ResponderAlert in ResponderAlertTbl)
                    {



                        RAArray[CountRA] = ResponderAlert;
                        if (CountRA == 3)
                        {


                            string Responder = RAArray[0].ToString();
                            string Responder2 = RAArray[1].ToString();
                            string Responder3 = RAArray[2].ToString();
                            string Responder4 = RAArray[3].ToString();

                            string[] wordArray1 = Responder.Split(',');
                            string ResponderAlert1 = wordArray1[0].ToString();
                            string ResponderAlertRelationShip1 = wordArray1[1].ToString();
                            string ResponderAlertPhoneNo1 = wordArray1[2].ToString();

                            string[] wordArray2 = Responder2.Split(',');
                            string ResponderAlert2 = wordArray2[0].ToString();
                            string ResponderAlertRelationShip2 = wordArray2[1].ToString();
                            string ResponderAlertPhoneNo2 = wordArray2[2].ToString();

                            string[] wordArray3 = Responder3.Split(',');
                            string ResponderAlert3 = wordArray3[0].ToString();
                            string ResponderAlertRelationShip3 = wordArray3[1].ToString();
                            string ResponderAlertPhoneNo3 = wordArray3[2].ToString();

                            string[] wordArray4 = Responder4.Split(',');
                            string ResponderAlert4 = wordArray4[0].ToString();
                            string ResponderAlertRelationShip4 = wordArray4[1].ToString();
                            string ResponderAlertPhoneNo4 = wordArray4[2].ToString();
                            //14 >= 8 && 14 <=16
                            if (DateTime.Now.Hour >= Convert.ToInt32(TimeFrom) && (DateTime.Now.Hour <= Convert.ToInt32(TimeTo)))
                            {
                            //InsertGeoFences(AAccountNo, SingleTrackID, trackingItems, circle.getRadius(), circle.getCenter().lat() + ',' + circle.getCenter().lng(), "circle", AAlertEmail, AAlertEmail, AAlertEmail, FenceAlertPhone1, FenceAlertPhone2, FenceAlertPhone3, FenceAlertPhone4, UserName, OS, 'Active', 'NotSend', 'ANSxyGPS@hotmail.my', '+60193198764', FenceAlertName1, FenceAlertName2, FenceAlertName3, FenceAlertName4, AISMSAlertMsg, geofenceArea, FenceAlertRelationship1, FenceAlertRelationship2, FenceAlertRelationship3, FenceAlertRelationship4);
                               

                                //bool checkGID = checkIsContain(ID);
                                //if (checkGID==false)
                                //{
                                //    GeofenceIDlist.Add(ID);                               
                                   bool a = AutoFenceTimer_Insert(AccountNo, TrackID, TrackItem, FenceLength, FencePath, ShapeType, "NA", "NA", "NA", ResponderAlertPhoneNo1, ResponderAlertPhoneNo2, ResponderAlertPhoneNo3, ResponderAlertPhoneNo4, "AutoFenceTimer", "NA", "CreatedFence", "NotSend", "tarmizi_09@hotmail.my", "NA", ResponderAlert1, ResponderAlert2, ResponderAlert3, ResponderAlert4, "PreDefined", FenceAreaName, ResponderAlertRelationShip1, ResponderAlertRelationShip2, ResponderAlertRelationShip3, ResponderAlertRelationShip4, ID);
                                //}
                            // MessageBox.Show(ID + '-' + CreatedDate + '-' + TrackItem + '-' + TrackID + '-' + AccountNo + '-' + FencePath + '-' + ShapeType + '-' + FenceAreaName + '-' + TimeFrom + '-' + TimeTo + '-' + DaySetting + '-' + Status + '-' + FenceLength + '-' + ResponderAlert1 + '-' + ResponderAlertRelationShip1 + '-' + ResponderAlert2 + '-' + ResponderAlertRelationShip2 + '-' + ResponderAlert3 + '-' + ResponderAlertRelationShip3 + '-' + ResponderAlert4 + '-' + ResponderAlertRelationShip4);
                             }

                            CountRA = 0;
                        }
                        CountRA++;
                    }


                }

                Count++;
            }



        }




        public bool checkIsContain(string geofenceID)
        {
            bool value = false;

            if (GeofenceIDlist.Contains(geofenceID))
            {
                value = true;
            }

            return value;

        }

        #endregion 


        # region AutofenceTimer SQL

        public bool AutoFenceTimer_Insert(string AccountNo, string TrackID, string TrackItem, string Fencelenght, string FencePath, string ShapeType, string FenceAlertemail, string FenceAlertemail2, string FenceAlertemail3, string FenceAlertPhone, string FenceAlertPhone2, string FenceAlertPhone3, string FenceAlertPhone4, string Createdby, string CreatedOS, string FenceStatus, string SendAlertStatus, string SenderEmail, string Senderphone, string FenceAlertName, string FenceAlertName2, string FenceAlertName3, string FenceAlertName4, string SMSAlertMsg, string FenceName, string FenceAlertResponderRelations, string FenceAlertResponderRelations2, string FenceAlertResponderRelations3, string FenceAlertResponderRelations4, string FenceAutoTimeID)
        {

            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            bool _value = true;
            using (SqlConnection _DBConnection = _SQLConnection)
            {

                SqlCommand _SQLCommand = new SqlCommand();
                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _SQLCommand.CommandTimeout = 0;
                using (_SQLCommand)
                {

                    try
                    {

                        _SQLCommand.Connection = _DBConnection;
                        _SQLCommand.CommandText = "Geofence_InsertFromAutofenceTimer";
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);
                        _SQLCommand.Parameters.AddWithValue("@TrackID", TrackID);
                        _SQLCommand.Parameters.AddWithValue("@TrackItem", TrackItem);
                        _SQLCommand.Parameters.AddWithValue("@Fencelenght", Fencelenght);
                        _SQLCommand.Parameters.AddWithValue("@FencePath", FencePath);
                        _SQLCommand.Parameters.AddWithValue("@ShapeType", ShapeType);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertemail", FenceAlertemail);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertemail2", FenceAlertemail2);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertemail3", FenceAlertemail3);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertPhone", FenceAlertPhone);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertPhone2", FenceAlertPhone2);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertPhone3", FenceAlertPhone3);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertPhone4", FenceAlertPhone4);
                        _SQLCommand.Parameters.AddWithValue("@Createdby ", Createdby);
                        _SQLCommand.Parameters.AddWithValue("@CreatedOS", CreatedOS);
                        _SQLCommand.Parameters.AddWithValue("@FenceStatus", FenceStatus);
                        _SQLCommand.Parameters.AddWithValue("@SendAlertStatus", SendAlertStatus);
                        _SQLCommand.Parameters.AddWithValue("@SenderEmail", SenderEmail);
                        _SQLCommand.Parameters.AddWithValue("@Senderphone", Senderphone);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertName", FenceAlertName);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertName2", FenceAlertName2);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertName3", FenceAlertName3);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertName4", FenceAlertName4);
                        _SQLCommand.Parameters.AddWithValue("@SMSAlertMsg", SMSAlertMsg);
                        _SQLCommand.Parameters.AddWithValue("@FenceName", FenceName);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertResponderRelations", FenceAlertResponderRelations);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertResponderRelations2", FenceAlertResponderRelations2);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertResponderRelations3", FenceAlertResponderRelations3);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertResponderRelations4", FenceAlertResponderRelations4);
                        _SQLCommand.Parameters.AddWithValue("@FenceAutoTimeID", FenceAutoTimeID);

                        _DBConnection.Open();

                        _SQLCommand.ExecuteNonQuery();

                    }

                    catch (Exception ex)
                    {
                        _value = false;


                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }

            }



            return _value;
        }

        public List<string> AutoFenceTimergetByIDStatus(string Status)
        {

            List<string> _Value = new List<string>();

            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);

            using (SqlConnection _DBConnection = _SQLConnection)
            {

                SqlCommand _SQLCommand = new SqlCommand();

                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                _SQLCommand.CommandTimeout = 0;



                using (_SQLCommand)
                {

                    try
                    {

                        _SQLCommand.Connection = _DBConnection;

                        _SQLCommand.CommandText = "AutoFenceTimer_getIDByStatus";

                        _SQLCommand.Parameters.AddWithValue("@Status", Status);

                        _DBConnection.Open();


                        SqlDataReader _SQLDataReader = _SQLCommand.ExecuteReader();



                        while (_SQLDataReader.Read())
                        {


                            _Value.Add(_SQLDataReader["ID"].ToString());

                        }

                    }

                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }

            }



            return _Value;

        }
        public List<string> AutoFenceTimergetDataByID(string ID)
        {

            List<string> _Value = new List<string>();

            connstring = con.connectstring();



            // String connectionString = ("data source=AMIR-XPS;Initial Catalog=DRMS_DB;Integrated Security=false;User Id=drmsws;Password=drmsws;");
            // String connectionString = ("Data Source=SQL5014.Smarterasp.net;Initial Catalog=DB_9B86C3_trackingDB;User Id=DB_9B86C3_trackingDB_admin;Password=masruna7216393;");
            //  String connectionString = (connstring);

            SqlConnection _SQLConnection = new SqlConnection(connstring);

            using (SqlConnection _DBConnection = _SQLConnection)
            {

                SqlCommand _SQLCommand = new SqlCommand();

                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                _SQLCommand.CommandTimeout = 0;



                using (_SQLCommand)
                {

                    try
                    {

                        _SQLCommand.Connection = _DBConnection;

                        _SQLCommand.CommandText = "AutoFenceTimer_getDataByID";

                        _SQLCommand.Parameters.AddWithValue("@ID", ID);

                        _DBConnection.Open();


                        SqlDataReader _SQLDataReader = _SQLCommand.ExecuteReader();



                        while (_SQLDataReader.Read())
                        {


                            _Value.Add(_SQLDataReader["ID"].ToString());
                            _Value.Add(_SQLDataReader["CreatedDate"].ToString());
                            _Value.Add(_SQLDataReader["TrackItem"].ToString());
                            _Value.Add(_SQLDataReader["TrackID"].ToString());
                            _Value.Add(_SQLDataReader["AccountNo"].ToString());
                            _Value.Add(_SQLDataReader["FencePath"].ToString());
                            _Value.Add(_SQLDataReader["ShapeType"].ToString());
                            _Value.Add(_SQLDataReader["FenceAreaName"].ToString());
                            _Value.Add(_SQLDataReader["TimeFrom"].ToString());
                            _Value.Add(_SQLDataReader["TimeTo"].ToString());
                            _Value.Add(_SQLDataReader["DaySetting"].ToString());
                            _Value.Add(_SQLDataReader["Status"].ToString());
                            _Value.Add(_SQLDataReader["FenceLength"].ToString());



                        }

                    }

                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }

            }



            return _Value;

        }
        public List<string> AutoFenceTimergetResponderAlert(string AccountNo)
        {

            List<string> _Value = new List<string>();

            connstring = con.connectstring();



            // String connectionString = ("data source=AMIR-XPS;Initial Catalog=DRMS_DB;Integrated Security=false;User Id=drmsws;Password=drmsws;");
            // String connectionString = ("Data Source=SQL5014.Smarterasp.net;Initial Catalog=DB_9B86C3_trackingDB;User Id=DB_9B86C3_trackingDB_admin;Password=masruna7216393;");
            //  String connectionString = (connstring);

            SqlConnection _SQLConnection = new SqlConnection(connstring);

            using (SqlConnection _DBConnection = _SQLConnection)
            {

                SqlCommand _SQLCommand = new SqlCommand();

                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                _SQLCommand.CommandTimeout = 0;



                using (_SQLCommand)
                {

                    try
                    {

                        _SQLCommand.Connection = _DBConnection;

                        _SQLCommand.CommandText = "AutoFenceTimer_getResponderAlert";

                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);

                        _DBConnection.Open();


                        SqlDataReader _SQLDataReader = _SQLCommand.ExecuteReader();



                        while (_SQLDataReader.Read())
                        {


                            //_Value.Add(_SQLDataReader["ID"].ToString());                        
                            //_Value.Add(_SQLDataReader["AccountNo"].ToString());
                            _Value.Add(_SQLDataReader["ResponderName"].ToString() + ',' + _SQLDataReader["ResponderRelationShip"].ToString() + ',' + _SQLDataReader["ResponderPhoneNo"].ToString());
                            //_Value.Add(_SQLDataReader["ShapeType"].ToString());
                            //_Value.Add(_SQLDataReader["FenceAreaName"].ToString());
                            //_Value.Add(_SQLDataReader["TimeFrom"].ToString());
                            //_Value.Add(_SQLDataReader["TimeTo"].ToString());
                            //_Value.Add(_SQLDataReader["DaySetting"].ToString());
                            //_Value.Add(_SQLDataReader["Status"].ToString());
                            //_Value.Add(_SQLDataReader["FenceLength"].ToString());



                        }

                    }

                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }

            }



            return _Value;

        }
        # endregion

       



        

    }
}