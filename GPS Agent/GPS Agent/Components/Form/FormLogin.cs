using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPSAgent.Components.Form
{
    public partial class FormLogin : System.Windows.Forms.Form
    {
       
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain i = (FormMain)Application.OpenForms["FormMain"];
            if (textBoxUN.Text == Properties.Settings.Default.UN1 || textBoxPWD.Text == Properties.Settings.Default.PWD1)
            {
                
                MessageBox.Show("Success!!");
                i.labellogin.Text = textBoxUN.Text;
                this.Close();

            }else
            if (textBoxUN.Text == Properties.Settings.Default.UN2 || textBoxPWD.Text == Properties.Settings.Default.PWD2)
            {

                MessageBox.Show("Success!!");
                i.labellogin.Text = textBoxUN.Text;
                this.Close();

            }
            else
            {
                MessageBox.Show("Error Password.!!!!");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBoxUN.Text = "";
            textBoxPWD.Text = "";
        }
        FormMain a = (FormMain)Application.OpenForms["FormMain"];
      //  int APNi = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            //Regex MyRegex = new Regex("[^a-z@,:_]", RegexOptions.IgnoreCase);
            //string word = "3G*8800000015*0087*UD,220414,134652,A,22.571707,N,113.8613968,E,0.1,0.0,100,7,60,90,1000,50,0000,4,1,460,0,9360,4082,131,9360,4092,148,9360,4091,143,9360,4153,141,E,A,V,N,ATOK,atok,sobur_SABAR@unifi,1c:a5:33a7:2f:35,-85,rumahkeluarga1@unifi,70:62:b9:e6:68:2a,-85" + "_{ (7 438 ?. !`";
            //string APNData = MyRegex.Replace(word, @"");
            //string WPSApn = "";



            //string[] APNChunks = APNData.Split(',');
            //foreach (string DetectedAPN in APNChunks)
            //{

            //    GPSdatas.Add(dtGPS);
            //    if (!DetectedAPN.Contains(":") && DetectedAPN.Length > 1 && !DetectedAPN.Contains("UD"))
            //    {
            //        MessageBox.Show(" Count: " + APNi.ToString() + "   Split Data :" + DetectedAPN);
            //        WPSApn += DetectedAPN + ',';
            //    }

            //    APNi = APNi + 1;
            //}

            //WPSApn = WPSApn.Remove(WPSApn.Length - 1);

            //MessageBox.Show(" APN: --" + WPSApn);
            a.Close();
        }
    }
}
