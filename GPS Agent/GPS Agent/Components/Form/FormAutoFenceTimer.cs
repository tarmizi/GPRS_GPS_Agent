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
    public partial class FormAutoFenceTimer : System.Windows.Forms.Form
    {
        public FormAutoFenceTimer()
        {
            InitializeComponent();
        }
        FormDB con = new FormDB(); private string connstring;
        string[] DiagArray = new string[13];
        string[] RAArray = new string[4];
        private void button1_Click(object sender, EventArgs e)
        {
           
           
            List<string> AutoFenceTimerID = AutoFenceTimergetByIDStatus("Active");
            foreach (string afID in AutoFenceTimerID)
            {
                ExtractData(afID);
               
            }
            

        }




        private void ExtractData(string IDi)
        {
            int Count = 0;
            int CountRA = 0;

            List<string> AutoFenceTimertbl = AutoFenceTimergetDataByID(IDi);
            foreach (string AutoFenceTimerData in AutoFenceTimertbl)
            {
                DiagArray[Count] = AutoFenceTimerData;

                if (Count == 12)
                {
                    string ID = DiagArray[0].ToString();
                    string CreatedDate = DiagArray[1].ToString();
                    string TrackItem = DiagArray[2].ToString();
                    string TrackID = DiagArray[3].ToString();
                    string AccountNo = DiagArray[4].ToString();
                    string FencePath = DiagArray[5].ToString();
                    string ShapeType = DiagArray[6].ToString();
                    string FenceAreaName = DiagArray[7].ToString();
                    string TimeFrom = DiagArray[8].ToString();
                    string TimeTo = DiagArray[9].ToString();
                    string DaySetting = DiagArray[10].ToString();
                    string Status = DiagArray[11].ToString();
                    string FenceLength = DiagArray[12].ToString();
                    txtStart.Text = TimeFrom;
                    txtStop.Text = TimeTo;
                 //   MessageBox.Show(ID + '-' + CreatedDate + '-' + TrackItem + '-' + TrackID + '-' + AccountNo + '-' + FencePath + '-' + ShapeType + '-' + FenceAreaName + '-' + TimeFrom + '-' + TimeTo + '-' + DaySetting + '-' + Status + '-' + FenceLength);

                    Count = 0;
                    List<string> ResponderAlertTbl = AutoFenceTimergetResponderAlert(AccountNo);
                    foreach (string ResponderAlert in ResponderAlertTbl)                    
                    {



                        RAArray[CountRA] = ResponderAlert;
                        if (CountRA == 3)
                        {

                           
                            string Responder = RAArray[0].ToString();
                            string Responder2 = RAArray[1].ToString();
                            string Responder3 = RAArray[2].ToString();
                            string Responder4 = RAArray[3].ToString();

                            string[] wordArray1 = Responder.Split(',');
                            string ResponderAlert1 = wordArray1[0].ToString();
                            string ResponderAlertRelationShip1 = wordArray1[1].ToString();
                            string ResponderAlertPhoneNo1 = wordArray1[2].ToString();

                            string[] wordArray2 = Responder2.Split(',');
                            string ResponderAlert2 = wordArray2[0].ToString();
                            string ResponderAlertRelationShip2 = wordArray2[1].ToString();
                            string ResponderAlertPhoneNo2 = wordArray2[2].ToString();

                            string[] wordArray3 = Responder3.Split(',');
                            string ResponderAlert3 = wordArray3[0].ToString();
                            string ResponderAlertRelationShip3 = wordArray3[1].ToString();
                            string ResponderAlertPhoneNo3 = wordArray3[2].ToString();

                            string[] wordArray4 = Responder4.Split(',');
                            string ResponderAlert4 = wordArray4[0].ToString();
                            string ResponderAlertRelationShip4 = wordArray4[1].ToString();
                            string ResponderAlertPhoneNo4 = wordArray4[2].ToString();

                            //if (DateTime.Now.Hour >= Convert.ToInt32(TimeFrom) && (DateTime.Now.Hour <= Convert.ToInt32(TimeTo)))
                            //{
                              //InsertGeoFences(AAccountNo, SingleTrackID, trackingItems, circle.getRadius(), circle.getCenter().lat() + ',' + circle.getCenter().lng(), "circle", AAlertEmail, AAlertEmail, AAlertEmail, FenceAlertPhone1, FenceAlertPhone2, FenceAlertPhone3, FenceAlertPhone4, UserName, OS, 'Active', 'NotSend', 'ANSxyGPS@hotmail.my', '+60193198764', FenceAlertName1, FenceAlertName2, FenceAlertName3, FenceAlertName4, AISMSAlertMsg, geofenceArea, FenceAlertRelationship1, FenceAlertRelationship2, FenceAlertRelationship3, FenceAlertRelationship4);

                            bool a = AutoFenceTimer_Insert(AccountNo, TrackID, TrackItem, FenceLength, FencePath, ShapeType, "NA", "NA", "NA", ResponderAlertPhoneNo1, ResponderAlertPhoneNo2, ResponderAlertPhoneNo3, ResponderAlertPhoneNo4, "AutoFenceTimer", "NA", "Active", "NotSend", "tarmizi_09@hotmail.my", "NA", ResponderAlert1, ResponderAlert2, ResponderAlert3, ResponderAlert4, "PreDefined", FenceAreaName, ResponderAlertRelationShip1, ResponderAlertRelationShip2, ResponderAlertRelationShip3, ResponderAlertRelationShip4, ID);
                          
                            // MessageBox.Show(ID + '-' + CreatedDate + '-' + TrackItem + '-' + TrackID + '-' + AccountNo + '-' + FencePath + '-' + ShapeType + '-' + FenceAreaName + '-' + TimeFrom + '-' + TimeTo + '-' + DaySetting + '-' + Status + '-' + FenceLength + '-' + ResponderAlert1 + '-' + ResponderAlertRelationShip1 + '-' + ResponderAlert2 + '-' + ResponderAlertRelationShip2 + '-' + ResponderAlert3 + '-' + ResponderAlertRelationShip3 + '-' + ResponderAlert4 + '-' + ResponderAlertRelationShip4);
                           // }

                            CountRA = 0;
                        }
                        CountRA++;
                    }


                }

                Count++;
            }



        }




       


     

# region AutofenceTimer SQL 

        public bool AutoFenceTimer_Insert(string AccountNo, string TrackID, string TrackItem, string Fencelenght, string FencePath, string ShapeType, string FenceAlertemail, string FenceAlertemail2, string FenceAlertemail3, string FenceAlertPhone, string FenceAlertPhone2, string FenceAlertPhone3, string FenceAlertPhone4, string Createdby, string CreatedOS, string FenceStatus, string SendAlertStatus, string SenderEmail, string Senderphone, string FenceAlertName, string FenceAlertName2, string FenceAlertName3, string FenceAlertName4, string SMSAlertMsg, string FenceName, string FenceAlertResponderRelations, string FenceAlertResponderRelations2, string FenceAlertResponderRelations3, string FenceAlertResponderRelations4, string FenceAutoTimeID)
        {

            connstring = con.connectstring();
            SqlConnection _SQLConnection = new SqlConnection(connstring);
            bool _value = true;
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
                        _SQLCommand.CommandText = "Geofence_InsertFromAutofenceTimer";
                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);
                        _SQLCommand.Parameters.AddWithValue("@TrackID", TrackID);
                        _SQLCommand.Parameters.AddWithValue("@TrackItem", TrackItem);
                        _SQLCommand.Parameters.AddWithValue("@Fencelenght", Fencelenght);
                        _SQLCommand.Parameters.AddWithValue("@FencePath", FencePath);
                        _SQLCommand.Parameters.AddWithValue("@ShapeType", ShapeType);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertemail", FenceAlertemail);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertemail2", FenceAlertemail2);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertemail3", FenceAlertemail3);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertPhone", FenceAlertPhone);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertPhone2", FenceAlertPhone2);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertPhone3", FenceAlertPhone3);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertPhone4", FenceAlertPhone4);
                        _SQLCommand.Parameters.AddWithValue("@Createdby ", Createdby);
                        _SQLCommand.Parameters.AddWithValue("@CreatedOS", CreatedOS);
                        _SQLCommand.Parameters.AddWithValue("@FenceStatus", FenceStatus);
                        _SQLCommand.Parameters.AddWithValue("@SendAlertStatus", SendAlertStatus);
                        _SQLCommand.Parameters.AddWithValue("@SenderEmail", SenderEmail);
                        _SQLCommand.Parameters.AddWithValue("@Senderphone", Senderphone);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertName", FenceAlertName);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertName2", FenceAlertName2);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertName3", FenceAlertName3);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertName4", FenceAlertName4);
                        _SQLCommand.Parameters.AddWithValue("@SMSAlertMsg", SMSAlertMsg);
                        _SQLCommand.Parameters.AddWithValue("@FenceName", FenceName);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertResponderRelations", FenceAlertResponderRelations);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertResponderRelations2", FenceAlertResponderRelations2);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertResponderRelations3", FenceAlertResponderRelations3);
                        _SQLCommand.Parameters.AddWithValue("@FenceAlertResponderRelations4", FenceAlertResponderRelations4);
                        _SQLCommand.Parameters.AddWithValue("@FenceAutoTimeID", FenceAutoTimeID);
                        
                        _DBConnection.Open();

                        _SQLCommand.ExecuteNonQuery();

                    }

                    catch (Exception ex)
                    {
                        _value = false;


                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }

            }



            return _value;
        }

        public List<string> AutoFenceTimergetByIDStatus(string Status)
        {

            List<string> _Value = new List<string>();

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

                        _SQLCommand.CommandText = "AutoFenceTimer_getIDByStatus";

                        _SQLCommand.Parameters.AddWithValue("@Status", Status);

                        _DBConnection.Open();


                        SqlDataReader _SQLDataReader = _SQLCommand.ExecuteReader();



                        while (_SQLDataReader.Read())
                        {


                            _Value.Add(_SQLDataReader["ID"].ToString());
                          
                        }

                    }

                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }

            }



            return _Value;

        }
        public List<string> AutoFenceTimergetDataByID(string ID)
        {

            List<string> _Value = new List<string>();

            connstring = con.connectstring();



            // String connectionString = ("data source=AMIR-XPS;Initial Catalog=DRMS_DB;Integrated Security=false;User Id=drmsws;Password=drmsws;");
            // String connectionString = ("Data Source=SQL5014.Smarterasp.net;Initial Catalog=DB_9B86C3_trackingDB;User Id=DB_9B86C3_trackingDB_admin;Password=masruna7216393;");
            //  String connectionString = (connstring);

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

                        _SQLCommand.CommandText = "AutoFenceTimer_getDataByID";

                        _SQLCommand.Parameters.AddWithValue("@ID", ID);

                        _DBConnection.Open();


                        SqlDataReader _SQLDataReader = _SQLCommand.ExecuteReader();



                        while (_SQLDataReader.Read())
                        {


                            _Value.Add(_SQLDataReader["ID"].ToString());
                            _Value.Add(_SQLDataReader["CreatedDate"].ToString());
                            _Value.Add(_SQLDataReader["TrackItem"].ToString());
                            _Value.Add(_SQLDataReader["TrackID"].ToString());
                            _Value.Add(_SQLDataReader["AccountNo"].ToString());
                            _Value.Add(_SQLDataReader["FencePath"].ToString());
                            _Value.Add(_SQLDataReader["ShapeType"].ToString());
                            _Value.Add(_SQLDataReader["FenceAreaName"].ToString());
                            _Value.Add(_SQLDataReader["TimeFrom"].ToString());
                            _Value.Add(_SQLDataReader["TimeTo"].ToString());
                            _Value.Add(_SQLDataReader["DaySetting"].ToString());
                            _Value.Add(_SQLDataReader["Status"].ToString());
                            _Value.Add(_SQLDataReader["FenceLength"].ToString());



                        }

                    }

                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }

            }



            return _Value;

        }
        public List<string> AutoFenceTimergetResponderAlert(string AccountNo)
        {

            List<string> _Value = new List<string>();

            connstring = con.connectstring();



            // String connectionString = ("data source=AMIR-XPS;Initial Catalog=DRMS_DB;Integrated Security=false;User Id=drmsws;Password=drmsws;");
            // String connectionString = ("Data Source=SQL5014.Smarterasp.net;Initial Catalog=DB_9B86C3_trackingDB;User Id=DB_9B86C3_trackingDB_admin;Password=masruna7216393;");
            //  String connectionString = (connstring);

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

                        _SQLCommand.CommandText = "AutoFenceTimer_getResponderAlert";

                        _SQLCommand.Parameters.AddWithValue("@AccountNo", AccountNo);

                        _DBConnection.Open();


                        SqlDataReader _SQLDataReader = _SQLCommand.ExecuteReader();



                        while (_SQLDataReader.Read())
                        {

                            
                            //_Value.Add(_SQLDataReader["ID"].ToString());                        
                            //_Value.Add(_SQLDataReader["AccountNo"].ToString());
                            _Value.Add(_SQLDataReader["ResponderName"].ToString() + ',' + _SQLDataReader["ResponderRelationShip"].ToString()+ ',' + _SQLDataReader["ResponderPhoneNo"].ToString());
                            //_Value.Add(_SQLDataReader["ShapeType"].ToString());
                            //_Value.Add(_SQLDataReader["FenceAreaName"].ToString());
                            //_Value.Add(_SQLDataReader["TimeFrom"].ToString());
                            //_Value.Add(_SQLDataReader["TimeTo"].ToString());
                            //_Value.Add(_SQLDataReader["DaySetting"].ToString());
                            //_Value.Add(_SQLDataReader["Status"].ToString());
                            //_Value.Add(_SQLDataReader["FenceLength"].ToString());



                        }

                    }

                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);

                    }

                    finally
                    {

                        _DBConnection.Close();

                    }

                }

            }



            return _Value;

        }
# endregion



    }
}
