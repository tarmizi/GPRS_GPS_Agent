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
    public partial class FormAddNewTrackingItem : System.Windows.Forms.Form
    {
        DB oo = new DB();
        FormMain f = new FormMain();
        FormAccountMain fA = new FormAccountMain();
        string log;
        public FormAddNewTrackingItem()
        {
            InitializeComponent();
        }

        private void buttonSaveAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(accountNoTextBox1.Text))
                {

                    MessageBox.Show("Account Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(trackIDTextBox.Text))
                {

                    MessageBox.Show("Track ID is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(trackItemTextBox.Text))
                {

                    MessageBox.Show("track ItemT Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }




                if (string.IsNullOrWhiteSpace(deviceIDTextBox.Text))
                {

                    MessageBox.Show("Device ID is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(sexTextBox.Text))
                {

                    MessageBox.Show("Sex is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(riskTextBox.Text))
                {

                    MessageBox.Show("Risk  is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(ageTextBox.Text))
                {

                    MessageBox.Show("Age  is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                string checkDupTrackID = oo.checkMultipleTrackID(trackIDTextBox.Text);
                if (checkDupTrackID !="0")
                {
                    MessageBox.Show("Track ID Duplicate!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string checkDupDeviceIDTrackID = oo.checkMultipleDeviceID(trackIDTextBox.Text, deviceIDTextBox.Text);
                if (checkDupDeviceIDTrackID != "0")
                {
                    MessageBox.Show("Device ID Duplicate !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }





                int ID = Convert.ToInt32(textBoxTrackItemID.Text="0");

                bool val = oo.insertUpdateTrackingItem(accountNoTextBox1.Text, trackIDTextBox.Text,
           deviceIDTextBox.Text, trackItemTextBox.Text, gPSModelTextBox.Text, log,
            log, textBoxStatus.Text, sexTextBox.Text, riskTextBox.Text, ageTextBox.Text, ID);
                if (val == true)
                {
                    MessageBox.Show("save success!!");
                    FormAccountMain i = (FormAccountMain)Application.OpenForms["FormAccountMain"];
                    i.reloadTrackingItem();
                 
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

        private void FormAddNewTrackingItem_Load(object sender, EventArgs e)
        {
            log = f.labellogin.Text;
        }

        private void checkBoxStatusActive_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxStatusActive.Checked == true)
            {
                checkBoxStatusInActive.Checked = false;
                textBoxStatus.Text = "Active";
               
            }
        }

        private void checkBoxStatusInActive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStatusInActive.Checked==true)
            {
                checkBoxStatusActive.Checked = false;
                textBoxStatus.Text = "InActive";

            }
        }

        private void buttonEditTrackingItem_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(accountNoTextBox1.Text))
                {

                    MessageBox.Show("Account Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(trackIDTextBox.Text))
                {

                    MessageBox.Show("Track ID is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(trackItemTextBox.Text))
                {

                    MessageBox.Show("track ItemT Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }




                if (string.IsNullOrWhiteSpace(deviceIDTextBox.Text))
                {

                    MessageBox.Show("Device ID is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(sexTextBox.Text))
                {

                    MessageBox.Show("Sex is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(riskTextBox.Text))
                {

                    MessageBox.Show("Risk  is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(ageTextBox.Text))
                {

                    MessageBox.Show("Age  is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (checkBoxEditTrackID.Checked==true)
                {
                string checkDupTrackID = oo.checkMultipleTrackID(trackIDTextBox.Text);
                if (checkDupTrackID != "0")
                {
                    MessageBox.Show("Track ID Duplicate!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                }

                if(checkBoxEditDeviceID.Checked==true)
                { 
                string checkDupDeviceIDTrackID = oo.checkMultipleDeviceID(trackIDTextBox.Text, deviceIDTextBox.Text);
                if (checkDupDeviceIDTrackID != "0")
                {
                    MessageBox.Show("Device ID Duplicate !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                }




                int ID = Convert.ToInt32(textBoxTrackItemID.Text);

                bool val = oo.insertUpdateTrackingItem(accountNoTextBox1.Text, trackIDTextBox.Text,
           deviceIDTextBox.Text, trackItemTextBox.Text, gPSModelTextBox.Text, log,
            log, textBoxStatus.Text, sexTextBox.Text, riskTextBox.Text, ageTextBox.Text, ID);
                if (val == true)
                {
                    MessageBox.Show("save success!!");
                    FormAccountMain i = (FormAccountMain)Application.OpenForms["FormAccountMain"];
                    i.reloadTrackingItem();

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

        private void checkBoxEditTrackID_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxEditTrackID.Checked==true)
            {
                trackIDTextBox.Enabled = true;
                buttonEditTrackingItem.Visible = true;
                buttonSaveAddNewItem.Visible = false;
            }
            if (checkBoxEditTrackID.Checked == false)
            {
                trackIDTextBox.Enabled = false;
                buttonEditTrackingItem.Visible = false;
                buttonSaveAddNewItem.Visible = true;

            }
        }

        private void checkBoxEditDeviceID_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxEditDeviceID.Checked==true)
            {
                deviceIDTextBox.Enabled = true;
                buttonEditTrackingItem.Visible = true;
                buttonSaveAddNewItem.Visible = false;
            }
            if (checkBoxEditDeviceID.Checked == false)
            {
                deviceIDTextBox.Enabled = false;
                buttonEditTrackingItem.Visible = false;
                buttonSaveAddNewItem.Visible = true;
            }
        }

        private void buttonGPSDeviceList_Click(object sender, EventArgs e)
        {
            FormGPSTrackerDeviceList TD = new FormGPSTrackerDeviceList();
            TD.Show();
        }





    }
}
