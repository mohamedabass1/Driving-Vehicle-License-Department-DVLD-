using System.Windows.Forms;

namespace DVLD
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, System.EventArgs e)
        {


        }

        // Crud Templete
        /*
         public static int AddNewDriver()
         {
             int NewID = -1;
             using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
             {
                 string query = @"Insert Into Drivers () 
                                         Values();

                                  SELECT SCOPE_IDENTITY();";

                 using (SqlCommand command = new SqlCommand(query, connection))
                 {

                     command.Parameters.AddWithValue("@PersonID", PersonID);



                     try
                     {
                         connection.Open();
                         object result = command.ExecuteScalar();

                         if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                         {
                             NewID = InsertedID;
                         }

                     }
                     catch (Exception ex)
                     {
                         NewID = -1;

                         clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                     }

                 }
             }

             return NewID;
         }
         public static bool UpdateDriver()
         {
             int AffectedRows = 0;
             using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
             {
                 string query = @"Update Drivers
                             set 
                              Where DriverID = @DriverID;";

                 using (SqlCommand command = new SqlCommand(query, connection))
                 {

                     command.Parameters.AddWithValue("@DriverID", DriverID);


                     try
                     {
                         connection.Open();

                         AffectedRows = command.ExecuteNonQuery();



                     }
                     catch (Exception ex)
                     {
                         AffectedRows = 0;
                         clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                     }

                 }
             }

             return (AffectedRows > 0);
         }

         public static bool GetDriverByID()

         {
             bool IsFound = false;

             using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
             {
                 string query = @"SELECT * FROM Drivers
                          WHERE DriverID=@DriverID";

                 using (SqlCommand command = new SqlCommand(query, connection))
                 {
                     command.Parameters.AddWithValue("@DriverID", DriverID);

                     try
                     {
                         connection.Open();

                         using (SqlDataReader reader = command.ExecuteReader())
                         {
                             if (reader.Read())
                             {
                                 PersonID = (int)reader["PersonID"];


                                 IsFound = true;
                             }
                         }
                     }
                     catch (Exception ex)
                     {
                         IsFound = false;
                         clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                     }
                 }
             }

             return IsFound;
         }
         public static DataTable GetAllDrivers()
         {

             DataTable dt = new DataTable();
             SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

             string query = @"SELECT * FROM Drivers 
                                    ORDER By DriverID;";

             SqlCommand command = new SqlCommand(query, connection);

             try
             {
                 connection.Open();

                 SqlDataReader reader = command.ExecuteReader();

                 if (reader.HasRows)

                 {
                     dt.Load(reader);
                 }

                 reader.Close();


             }

             catch (Exception ex)
             {
                 clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

             }
             finally
             {
                 connection.Close();
             }

             return dt;

         }

         public static bool IsDriverExist(int DriverID)
         {
             bool isFound = false;

             using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
             {

                 string query = @"Select 1 From Drivers
                                  WHERE DriverID = @DriverID;";

                 using (SqlCommand command = new SqlCommand(query, connection))
                 {
                     command.Parameters.AddWithValue("@DriverID", DriverID);

                     try
                     {
                         connection.Open();

                         using (SqlDataReader reader = command.ExecuteReader())
                         {
                             isFound = reader.HasRows;
                         }
                     }
                     catch (Exception ex)
                     {
                         isFound = false;
                         clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                     }
                 }
             }
             return isFound;
         }
         */
        private void ctrlPersonCardWithFilter1_Load(object sender, System.EventArgs e)
        {

        }

        private void cbFillter_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void label3_Click(object sender, System.EventArgs e)
        {

        }

        private void txtSearsh_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void btnAddNewPerson_Click(object sender, System.EventArgs e)
        {

        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void lblTotalRecords_Click(object sender, System.EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dgvPeopleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            //Form frm = new frmShowPersonLicenseHistory(1);
            //frm.ShowDialog();


        }
    }
}
