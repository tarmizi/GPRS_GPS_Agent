//using GPSAgent.Data;
//using System;
//using System.Collections.Generic;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Net.Sockets;
//using System.Text.RegularExpressions;


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
using System.Net.Sockets;
using System.Text;

namespace GPSAgent.Components.Form
{
    public partial class FormReceiver : System.Windows.Forms.Form
    {
        public FormReceiver()
        {
            InitializeComponent();
        }
        SocketPermission permission;
        Socket sListener;
        IPEndPoint ipEndPoint;
        Socket handler;
        private void startListenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

      






        public void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = null;

            // A new Socket to handle remote host communication 
            Socket handler = null;
            try
            {
                // Receiving byte array 
                byte[] buffer = new byte[3072];
                // Get Listening Socket object 
                listener = (Socket)ar.AsyncState;
                // Create a new socket 
                handler = listener.EndAccept(ar);

                // Using the Nagle algorithm 
                handler.NoDelay = false;

                // Creates one object array for passing data 
                object[] obj = new object[2];
                obj[0] = buffer;
                obj[1] = handler;

                // Begins to asynchronously receive data 
                handler.BeginReceive(
                    buffer,        // An array of type Byt for received data 
                    0,             // The zero-based position in the buffer  
                    buffer.Length, // The number of bytes to receive 
                    SocketFlags.None,// Specifies send and receive behaviors 
                    new AsyncCallback(ReceiveCallback),//An AsyncCallback delegate 
                    obj            // Specifies infomation for receive operation 
                    );

                // Begins an asynchronous operation to accept an attempt 
                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                listener.BeginAccept(aCallback, listener);
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }
        FormMain main = new FormMain();
        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Fetch a user-defined object that contains information 
                object[] obj = new object[2];
                obj = (object[])ar.AsyncState;

                // Received byte array 
                byte[] buffer = (byte[])obj[0];

                // A Socket to handle remote host communication. 
                handler = (Socket)obj[1];

                // Received message 
                string content = string.Empty;
                string contentAppnd = string.Empty;

                // The number of bytes received. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    content += Encoding.ASCII.GetString(buffer, 0,
                        bytesRead);

                    // If message contains "<Client Quit>", finish receiving
                    if (content.IndexOf("<Client Quit>") > -1)
                    {
                        // Convert byte array to string
                        string str = content.Substring(0, content.LastIndexOf("<Client Quit>"));


                        this.Invoke((MethodInvoker)delegate
                        {
                            ///////  listBoxGPSTraffic.Items.Add += "Read " + str.Length * 2 + " bytes from client.\n Data: " + str; // runs on UI thread
                        });
                        //this is used because the UI couldn't be accessed from an external Thread
                        //this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                        //{
                        //    tbAux.Text = "Read " + str.Length * 2 + " bytes from client.\n Data: " + str;
                        //}
                        //);
                    }
                    else
                    {
                        // Continues to asynchronously receive data
                        byte[] buffernew = new byte[3072];
                        obj[0] = buffernew;
                        obj[1] = handler;
                        handler.BeginReceive(buffernew, 0, buffernew.Length,
                            SocketFlags.None,
                            new AsyncCallback(ReceiveCallback), obj);
                    }


                    this.Invoke((MethodInvoker)delegate
                    {
                        contentAppnd += content;
                        if (content.Contains("imei:"))
                        {
                            GPSTrackerCobanFamily(contentAppnd);

                        } if (content.Contains("["))
                        {
                            MSIproject(contentAppnd);

                        }
                      //  listBoxGPSTraffic.Items.Add(contentAppnd);
                        //    textBoxMsgReceiveFromClient.Text += content; // runs on UI thread
                        //  sendACK();
                    });

                    //this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                    //{
                    //    tbAux.Text = content;
                    //}
                    //);
                }
            }
            catch (Exception exc)
            {
              //  main.MSIproject(exc.ToString());
             //  listBoxGPSTraffic.Items.Add(exc.ToString());
               ExceptionErrorMsg(exc.ToString());
                // textBoxMsgReceiveFromClient.Text += exc.ToString(); // runs on UI thread 
            }
        }

        private void ExceptionErrorMsg(string msg)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                listBoxGPSTraffic.Items.Add("ExceptionErrorMsg :" + msg);
               
            }));
        }
       
        private void buttonStartServer_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Creates one SocketPermission object for access restrictions
                permission = new SocketPermission(
                NetworkAccess.Accept,     // Allowed to accept connections 
                TransportType.Tcp,        // Defines transport types 
                "",                       // The IP addresses of local host 
                SocketPermission.AllPorts // Specifies all ports 
                );

                // Listening Socket object 
                sListener = null;

                // Ensures the code to have permission to access a Socket 
                permission.Demand();

                // Resolves a host name to an IPHostEntry instance 
                // IPHostEntry ipHost = Dns.GetHostEntry("");

                // Gets first IP address associated with a localhost 
                //   IPAddress ipAddr = ipHost.AddressList[0];
                //// IPAddress ipAddress = IPAddress.Parse(textBoxWorklistSServerIP.Text);
                 int Port=Convert.ToInt32( textBoxWorklistServerIPPort.Text);

                 IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, Port);
                // Creates a network endpoint 
                // ipEndPoint = new IPEndPoint(ipAddr, 4510);

                // Create one Socket object to listen the incoming connection 
                sListener = new Socket(
                   AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );

                // Associates a Socket with a local endpoint 
                sListener.Bind(serverEndPoint);

                toolStripStatusLabel.Text = "Server started.................";

                buttonStartServer.Enabled = false;
                buttonStartListerning.Enabled = true;
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        private void buttonStartListerning_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Places a Socket in a listening state and specifies the maximum 
                // Length of the pending connections queue 
                sListener.Listen(10);

                // Begins an asynchronous operation to accept an attempt 
                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                sListener.BeginAccept(aCallback, sListener);

                toolStripStatusLabel.Text = "Server is now listening on....  port: " + textBoxWorklistServerIPPort.Text;

                buttonStartListerning.Enabled = false;
                timer1.Enabled = true;
                timer1.Start();
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
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

#region CobanGPS



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
            listBoxGPSTraffic.Items.Add("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
            try
            {
                foreach (string packetGps in listGPS)
                {


                    string[] vMessageChunks = packetGps.Split(',');
                    foreach (string dtGPS in vMessageChunks)
                    {

                        GPSdatas.Add(dtGPS);
                        listBoxGPSTraffic.Items.Add(" Count: " + i.ToString() + "   Split Data :" + dtGPS);
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
                listBoxGPSTraffic.Items.Add("parsed GPSTrackerCobanFamily error :" + g.ToString());
                //    countrow = listBoxGPSpacket.Items.Count;

            }







        }


#endregion




        #region MSIProject
             public void MSIproject(string data)
             {
                 string MSIIdDevice;
                 string SignalStatus;
                 string Longituted;
                 string Latituded;
                 string Speed;
                 string WatchGPSdata;
                 string Directions;
                 string Altitude;
                 string BateryReading;
                 string GSMSignalReading;
                 string TerminalState;
                 string APN;

                 List<string> GPSdatas = new List<string>();


                 if (data.Contains("LK"))
                 {
                     listBoxGPSTraffic.Items.Add("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
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


                 listBoxGPSTraffic.Items.Add("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
                 try
                 {
                     foreach (string packetGps in listGPS)
                     {


                         string[] vMessageChunks = packetGps.Split(',');
                         foreach (string dtGPS in vMessageChunks)
                         {

                             GPSdatas.Add(dtGPS);
                             listBoxGPSTraffic.Items.Add(" Count: " + i.ToString() + "   Split Data :" + dtGPS);
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
                     Altitude = GPSdatas[13].ToString();
                     GSMSignalReading = GPSdatas[15].ToString();
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
                     if (WPSApn.Length > 1)
                     { WPSApn = WPSApn.Remove(WPSApn.Length - 1); }
                    

                     if (MSIIdDevice != holdimei)
                     {
                         holdimei = MSIIdDevice;
                         if (!listofImeiNo.Contains(MSIIdDevice))
                         {
                             countDevice = countDevice + 1;
                            toolStripStatusLabelDeviceCount.Text = countDevice.ToString();
                            
                         }
                         listofImeiNo.Add(MSIIdDevice);
                         //oo.GetSimNumTrackID(MSIIdDevice);
                         //TracKiD = oo.TrackingID;
                         //SimNUM = oo.SimNumber;


                     }

                     oo.insertGPSdata(MSIIdDevice, MSIIdDevice, "NA", "NA", SignalStatus, "NA",
                         "NA", Longituted, Latituded, Speed, Directions, MSIIdDevice, SimNUM, BateryReading, Altitude, GSMSignalReading, TerminalState, WPSApn);
                 }
                 catch (Exception b)
                 {
                     listGPS.Clear();
                     GPSdatas.Clear();
                     listBoxGPSTraffic.Items.Add("parsed MSIproject error :" + b.ToString());
                 }


             }
        #endregion




             FormDB con = new FormDB(); private string connstring;
             string[] DiagArray = new string[13];
             string[] RAArray = new string[4];
             List<string> GeofenceIDlist = new List<string>();
             int counttime = 0;

             private void timer1_Tick(object sender, System.EventArgs e)
             {

                 counttime++;
                 labelCount.Text = counttime.ToString();


                 //if(labelCount.Text =="3")
                 //{
                 //    timer1.Stop();
                 //    labelCount.Text = "0";
                   //  ExtractData();
                     List<string> AutoFenceTimerID = AutoFenceTimergetByIDStatus("Active");
                     foreach (string afID in AutoFenceTimerID)
                     {
                         ExtractData(afID);
                       //  MessageBox.Show(afID);

                     }
                   
              //   }
                 
             }


             private void ExtractData(string afID)
             {
                 int Count = 0;

                
                     List<string> AutoFenceTimertbl = AutoFenceTimergetDataByID(afID);
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

                             //6.45=consider 6
                            //        6                                   6                6                             8
                             if (DateTime.Now.Hour >= Convert.ToInt32(TimeFrom) && (DateTime.Now.Hour < Convert.ToInt32(TimeTo)))
                             {

                                 bool a = AutoFenceTimer_Insert(AccountNo, TrackID, TrackItem, FenceLength, FencePath, ShapeType, "NA", "NA", "NA", "ResponderAlertPhoneNo1", "ResponderAlertPhoneNo2", "ResponderAlertPhoneNo3", "ResponderAlertPhoneNo4", "AutoFenceTimer", "NA", "CreatedFence", "NotSend", "tarmizi_09@hotmail.my", "NA", "ResponderAlert1", "ResponderAlert2", "ResponderAlert3", "ResponderAlert4", "PreDefined", FenceAreaName, "ResponderAlertRelationShip1", "ResponderAlertRelationShip2", "ResponderAlertRelationShip3", "ResponderAlertRelationShip4", ID);

                                 Count = 0;
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

             private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
             {
                 FormDB h = new FormDB();
                 h.Show();
             }

             private void trafficToolStripMenuItem_Click(object sender, EventArgs e)
             {
                 this.listBoxGPSTraffic.Items.Clear();
             }

             private void clearDeviceCountToolStripMenuItem_Click(object sender, EventArgs e)
             {
                 listofImeiNo.Clear();
                 toolStripStatusLabelDeviceCount.Text = "Devices Counted: 0";
             }

             private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
             {
                 FormLoginAdmin la = new FormLoginAdmin();
                 la.ShowDialog();
             }

             private void autoFenceTimerToolStripMenuItem_Click(object sender, EventArgs e)
             {
                 FormAutoFenceTimer ft = new FormAutoFenceTimer();
                 ft.Show();
             }

             private void lockSystemToolStripMenuItem_Click(object sender, EventArgs e)
             {
                 FormLogin login = new FormLogin();
                 login.ShowDialog();
             }

             private void subscriberAccountToolStripMenuItem_Click(object sender, EventArgs e)
             {

                 FormAccountMain frmAccountMain = new FormAccountMain();
                 frmAccountMain.Show();
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

             private void FormReceiver_FormClosing(object sender, FormClosingEventArgs e)
             {
                 var result = MessageBox.Show("quit application", "confirmation",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

                 e.Cancel = (result == DialogResult.No);
             }

             private void FormReceiver_Resize(object sender, EventArgs e)
             {
                 if (this.WindowState == FormWindowState.Minimized)
                 {
                     Hide();
                     notifyIcon1.Visible = true;
                 }  
             }

             private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
             {
                 Show();
                 this.WindowState = FormWindowState.Normal;
                 notifyIcon1.Visible = false; 
             }


    }
}
