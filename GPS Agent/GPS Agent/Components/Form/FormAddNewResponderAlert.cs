using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace GPSAgent.Components.Form
{
    public partial class FormAddNewResponderAlert : System.Windows.Forms.Form
    {
        DB oo = new DB();
        FormMain f = new FormMain();

        string log;
        public FormAddNewResponderAlert()
        {
            InitializeComponent();
        }

        private void checkBoxStatusActive_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxStatusActive.Checked==true)
            {
                textBoxStatus.Text = "Active";
                checkBoxStatusInActive.Checked = false;
            }
        }

        private void checkBoxStatusInActive_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxStatusInActive.Checked==true)
            {
                textBoxStatus.Text = "InActive";
                checkBoxStatusActive.Checked = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(textBoxResponderName.Text))
                {

                    MessageBox.Show("Responder Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxRelationShip.Text))
                {

                    MessageBox.Show("RelationShip is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxMobilePhone.Text))
                {

                    MessageBox.Show("MobilePhone is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }




                if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
                {

                    MessageBox.Show("Email is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxStatus.Text))
                {

                    MessageBox.Show("Status is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ID=Convert.ToInt32(ResponderIDtxtBox.Text);

                bool val = oo.updateResponderAlert(ID, textBoxAccountNo.Text, textBoxResponderName.Text, textBoxRelationShip.Text, textBoxMobilePhone.Text, textBoxEmail.Text, textBoxStatus.Text, log);
                if (val == true)
                {
                    MessageBox.Show("save success!!");
                   

                }
                else
                {
                    MessageBox.Show("save failed!!");
                }
            }
            catch (Exception v)
            {
                MessageBox.Show("save failed!!" + v.ToString());
            }
        }

        private void FormAddNewResponderAlert_Load(object sender, EventArgs e)
        {
            log = f.labellogin.Text;
        }
    }
}
