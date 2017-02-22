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
    public partial class FormSetUrlGeofenceMonitoring : System.Windows.Forms.Form
    {
        public FormSetUrlGeofenceMonitoring()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.SetUrl = textBoxUrl.Text;
                Properties.Settings.Default.RefreshUrl = textBoxRI.Text;
                
                MessageBox.Show("Save");

            }
            catch (Exception f)
            {
                MessageBox.Show("Failed Save " + f.ToString());
            }
        }

        private void FormSetUrlGeofenceMonitoring_Load(object sender, EventArgs e)
        {
            textBoxUrl.Text = Properties.Settings.Default.SetUrl;
            textBoxRI.Text = Properties.Settings.Default.RefreshUrl;
        }
    }
}
