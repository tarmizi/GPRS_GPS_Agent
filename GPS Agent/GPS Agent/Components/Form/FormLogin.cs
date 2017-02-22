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
        private void button2_Click(object sender, EventArgs e)
        {
          
            a.Close();
        }
    }
}
