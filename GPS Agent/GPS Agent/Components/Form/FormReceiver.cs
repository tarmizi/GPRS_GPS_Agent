using GPSAgent.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPSAgent.Components.Form
{
    public partial class FormReceiver : System.Windows.Forms.Form
    {
        public FormReceiver()
        {
            InitializeComponent();
        }

        private void startListenerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gPSTrackerDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  this.CtrlDeviceList.SelectedIndex = 1;
           // GPSTracker oSelected = this.CtrlDeviceList.SelectedItem as GPSTracker;
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
        }
    }
}
