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
    public partial class FormLoginAdmin : System.Windows.Forms.Form
    {
        public FormLoginAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Properties.Settings.Default.PWD1 || textBox1.Text == Properties.Settings.Default.PWD2)
             {
                 FormAdminInfo ai = new FormAdminInfo();
                 ai.Show();
                 MessageBox.Show("Success!!");
                 this.Close();

             }
             else
             {
                 MessageBox.Show("Error Password.!!!!");
             }
       
        }
    }
}
