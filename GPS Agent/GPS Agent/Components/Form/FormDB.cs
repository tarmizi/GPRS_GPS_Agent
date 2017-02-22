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
    public partial class FormDB : System.Windows.Forms.Form
    {


     
    
        private string _connstring;
       
       


        





        public FormDB()
        {
            InitializeComponent();
        }


        public string connectstring()
        {

            return _connstring = "data source=" + Properties.Settings.Default.Server + ";Initial Catalog=" + Properties.Settings.Default.DB + ";Integrated Security=false;User ID=" + Properties.Settings.Default.Usr + ";Password=" + Properties.Settings.Default.Pwd; 

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxSvrName.Text = Properties.Settings.Default.Server;
            textBoxDBName.Text = Properties.Settings.Default.DB;
            textBoxUsr.Text = Properties.Settings.Default.Usr;
            textBoxPwd.Text = Properties.Settings.Default.Pwd;
        }

        private void buttonConn_Click(object sender, EventArgs e)
        {
            FormMain v = new FormMain();
            try
            {
               Properties.Settings.Default.Server=  textBoxSvrName.Text ;
                 Properties.Settings.Default.DB= textBoxDBName.Text;
                Properties.Settings.Default.Usr= textBoxUsr.Text;
                 Properties.Settings.Default.Pwd= textBoxPwd.Text;
                 v.labelDB.Text = textBoxDBName.Text;
                 v.labelDBserver.Text = textBoxSvrName.Text;
                 Properties.Settings.Default.Save();
                 MessageBox.Show("Save");

            }catch(Exception f)
            {
                MessageBox.Show("Failed Save "+f.ToString());
            }
        }
    }
}
