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
    public partial class FormUser : System.Windows.Forms.Form
    {
        DB oo = new DB();
        FormMain f = new FormMain();
        FormAccountMain Am = new FormAccountMain();
        public FormUser()
        {
            InitializeComponent();
        }

        private void checkBoxStatusActive_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxStatusActive.Checked==true)
            {
                statusTextBox3.Text = "1";
                checkBoxStatusInActive.Checked = false;

            }
        }

        private void checkBoxStatusInActive_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxStatusInActive.Checked==true)
            {
                statusTextBox3.Text = "0";
                checkBoxStatusActive.Checked = false;

            }
        }

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            FormAccountMain i = (FormAccountMain)Application.OpenForms["FormAccountMain"];    

            try{
                int ID=Convert.ToInt32(iDTextBox3.Text);
                string updateby=f.labellogin.Text;
                bool check=oo.updateGPSUser( ID, userNameTextBox.Text, passwordTextBox.Text,
         statusTextBox3.Text, accountNoTextBox3.Text, updateby, loginTypeTextBox.Text,
         emailRegTextBox.Text);
                if(check==true)
                {
                    MessageBox.Show("save success");
                    i.textBoxAssignedUser.Text = userNameTextBox.Text;
                }else
                {
                    MessageBox.Show("save Failed.!!");
                }
               

            }catch(Exception f)
            {
                MessageBox.Show("save Failed.!!"+f.ToString());

            }
           
        }
    }
}
