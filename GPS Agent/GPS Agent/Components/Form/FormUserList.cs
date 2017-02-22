using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPSAgent.Components.Form
{
    public partial class FormUserList : System.Windows.Forms.Form
    
    {
        DB oo = new DB();
        private string connstring;
        public FormUserList()
        {
            InitializeComponent();
        }

        private void buttonLoadAllUser_Click(object sender, EventArgs e)
        {
            gPSuserDataGridView.DataSource = oo.GPSUserAll();
            gPSuserDataGridView.DataMember = "GPSUserAll";
        }

        private void buttonSearchAllUser_Click(object sender, EventArgs e)
        {
            gPSuserDataGridView.DataSource = oo.GPSUserAllSearchCol(textBoxAllUserSearch.Text);
            gPSuserDataGridView.DataMember = "GPSUserAllSearchCol";
        }

        private void buttonRefreshAllUser_Click(object sender, EventArgs e)
        {
            gPSuserDataGridView.DataSource = oo.GPSUserAll();
            gPSuserDataGridView.DataMember = "GPSUserAll";

        }

        private void gPSuserDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = gPSuserDataGridView.Rows[e.RowIndex].Index.ToString();
            int cellValue = Convert.ToInt32(gPSuserDataGridView.Rows[e.RowIndex].Cells[0].Value);
            loadGPSUserByID(cellValue);
        }

        public void loadGPSUserByID(int ID)
        {

            // MessageBox.Show(TrackID);
            FormDB con = new FormDB();
            //FormAddNewTrackingItem ad = new FormAddNewTrackingItem();
            //FormGPSDevices GPSF = new FormGPSDevices();
            FormUser us = new FormUser();

            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            using (SqlConnection _DBConnection = _SQLConnection)
            {
                SqlCommand _SQLCommand = new SqlCommand();
                _SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                _SQLCommand.CommandTimeout = 0;
                using (_SQLCommand)
                {
                    try
                    {
                        _SQLCommand.Connection = _DBConnection;
                        _SQLCommand.CommandText = "Get_GPSUserByID";
                        _SQLCommand.Parameters.AddWithValue("@ID", ID);
                        _DBConnection.Open();
                        SqlDataReader result = _SQLCommand.ExecuteReader();

                        result.Read();
                        if (result.HasRows)
                        {

                            us.iDTextBox3.Text = result.GetInt32(0).ToString();
                            us.userNameTextBox.Text = result.GetString(1).ToString();
                            us.passwordTextBox.Text = result.GetString(2).ToString();
                            us.statusTextBox3.Text = result.GetString(3).ToString();
                            //us.accountNoTextBox3.Text = result.GetString(4).ToString();
                            us.accountNoTextBox3.Text = textBoxAssignedAccNo.Text;
                            us.registerByTextBox.Text = result.GetString(5).ToString();
                            us.updateByTextBox.Text = result.GetString(6).ToString();
                            us.CreatedDatetextBox.Text = result.GetDateTime(7).ToString();


                            us.loginIPTextBox.Text = result.GetString(10).ToString();
                            us.loginTypeTextBox.Text = result.GetString(11).ToString();
                            string lastlogindate = result.GetDateTime(12).ToString();


                            us.loginCountTextBox.Text = result.GetInt32(13).ToString();
                            us.browserTextBox.Text = result.GetString(15).ToString();
                            us.oSTextBox.Text = result.GetString(16).ToString();
                            us.emailRegTextBox.Text = result.GetString(17).ToString();
                            string modifieddate = result.GetDateTime(8).ToString();
                            if (lastlogindate.Length > 2)
                            { us.LastLoginDatetextBox.Text = result.GetDateTime(12).ToString(); }
                            if (modifieddate.Length > 2)
                            {
                                us.ModifiedDatetextBox.Text = result.GetDateTime(8).ToString();
                            }
                        }

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }


            }
            //GPSF.checkBoxEditDeviceID.Visible = true;
            //GPSF.buttonSaveGpsDevice.Visible = true;
            //GPSF.button1.Visible = false;
            us.accountNoTextBox3.Enabled = false;
            us.Show();
        }
    }
}
