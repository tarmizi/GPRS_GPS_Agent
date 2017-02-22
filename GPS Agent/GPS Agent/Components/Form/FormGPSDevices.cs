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
    public partial class FormGPSDevices : System.Windows.Forms.Form
    {
        DB oo = new DB();
        FormMain f = new FormMain();
        string log;
        public FormGPSDevices()
        {
            InitializeComponent();
        }

        private void buttonSaveGpsDevice_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(deviceIDTextBox1.Text))
                {

                    MessageBox.Show("Device ID  is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(deviceNameTextBox.Text))
                {

                    MessageBox.Show("Device Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(simNumTextBox.Text))
                {

                    MessageBox.Show("sim Number is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }




                if (string.IsNullOrWhiteSpace(simOperatorTextBox.Text))
                {

                    MessageBox.Show("sim Operator is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(serverIPTextBox.Text))
                {

                    MessageBox.Show("server IP is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(gPSserverPortTextBox.Text))
                {

                    MessageBox.Show("server Port  is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(statusTextBox1.Text))
                {

                    MessageBox.Show("status is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(statusTextBox1.Text))
                {

                    MessageBox.Show("status is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(intervalTextBox1.Text))
                {

                    MessageBox.Show("interval is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(checkBoxEditDeviceID.Checked==true)
                { 
                string checkDupDeviceID = oo.checkMultipleDeviceIDGPSDDevice(deviceIDTextBox1.Text);
                if (checkDupDeviceID != "0")
                {
                    MessageBox.Show("Device ID Duplicate !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                }
                int ID = Convert.ToInt32(iDTextBox1.Text);

                bool val = oo.insertUpdateGPSDevices(ID, deviceIDTextBox1.Text, deviceNameTextBox.Text, deviceModelTextBox.Text, simNumTextBox.Text, simOperatorTextBox.Text, serverIPTextBox.Text, gPSserverPortTextBox.Text, statusTextBox1.Text, intervalTextBox1.Text, log);
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

        private void checkBoxStatusActive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStatusInActive.Checked == true)
            {
                statusTextBox1.Text = "Active";
                checkBoxStatusInActive.Checked = false;
            }
        }

        private void checkBoxStatusInActive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStatusInActive.Checked == true)
            {
                statusTextBox1.Text = "InActive";
                checkBoxStatusActive.Checked = false;
            }
        }

        private void FormGPSDevices_Load(object sender, EventArgs e)
        {
            log = f.labellogin.Text;
        }

        private void checkBoxEditDeviceID_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEditDeviceID.Checked==true)
            {
                deviceIDTextBox1.Enabled = true;

            }
            if (checkBoxEditDeviceID.Checked == false)
            {
                deviceIDTextBox1.Enabled = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(deviceIDTextBox1.Text))
                {

                    MessageBox.Show("Device ID  is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(deviceNameTextBox.Text))
                {

                    MessageBox.Show("Device Name is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(simNumTextBox.Text))
                {

                    MessageBox.Show("sim Number is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }




                if (string.IsNullOrWhiteSpace(simOperatorTextBox.Text))
                {

                    MessageBox.Show("sim Operator is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(serverIPTextBox.Text))
                {

                    MessageBox.Show("server IP is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(gPSserverPortTextBox.Text))
                {

                    MessageBox.Show("server Port  is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(statusTextBox1.Text))
                {

                    MessageBox.Show("status is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(statusTextBox1.Text))
                {

                    MessageBox.Show("status is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(intervalTextBox1.Text))
                {

                    MessageBox.Show("interval is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string checkDupDeviceID = oo.checkMultipleDeviceIDGPSDDevice(deviceIDTextBox1.Text);
                if (checkDupDeviceID != "0")
                {
                    MessageBox.Show("Device ID Duplicate !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int ID = Convert.ToInt32(iDTextBox1.Text="0");

                bool val = oo.insertUpdateGPSDevices(ID, deviceIDTextBox1.Text, deviceNameTextBox.Text, deviceModelTextBox.Text, simNumTextBox.Text, simOperatorTextBox.Text, serverIPTextBox.Text, gPSserverPortTextBox.Text, statusTextBox1.Text, intervalTextBox1.Text, log);
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
    }
}
