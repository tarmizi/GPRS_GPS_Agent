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

namespace GPSAgent.Components.Form
{
    public partial class FormAdminInfo : System.Windows.Forms.Form
    {
        public FormAdminInfo()
        {
            InitializeComponent();
        }

        private void FormAdminInfo_Load(object sender, EventArgs e)
        {

            textBoxAdminUserName1.Text = Properties.Settings.Default.UN1;
            textBoxAdminPassword1.Text = Properties.Settings.Default.PWD1;
            textBoxAdminUserName2.Text = Properties.Settings.Default.UN2;
            textBoxAdminPassword2.Text = Properties.Settings.Default.PWD2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                  Properties.Settings.Default.UN1=textBoxAdminUserName1.Text;
               Properties.Settings.Default.PWD1=  textBoxAdminPassword1.Text ;
              Properties.Settings.Default.UN2 = textBoxAdminUserName2.Text  ;
               Properties.Settings.Default.PWD2 =textBoxAdminPassword2.Text ;
              
                Properties.Settings.Default.Save();
                MessageBox.Show("Save");

            }
            catch (Exception f)
            {
                MessageBox.Show("Failed Save " + f.ToString());
            }
        }
    }
}
