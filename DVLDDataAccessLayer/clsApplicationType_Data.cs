using DVLD_DataAccess;
using DVLD_Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public static class clsApplicationType_Data
    {
        public static DataTable GetAllApplicationTypes()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * From ApplicationTypes;";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtApplicationTypes = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtApplicationTypes.Load(reader);
                }

                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return dtApplicationTypes;
        }

        public static bool GetApplicationTypeInfo(int ApplicationTypeID, ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @" Select * from  ApplicationTypes
                              Where  ApplicationTypeID = @ApplicationTypeID; ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            bool isFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);


                }

                reader.Close();

            }
            catch (Exception ex)
            {

                isFound = false;
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static int AddNewApplicationType(string ApplicationTypeTitle, float ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @" Insert Into  ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                                Values (@ApplicationTypeTitle,@ApplicationFees);
                                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


            int ApplicationTypeID = -1;
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);


            }

            finally
            {
                connection.Close();
            }


            return ApplicationTypeID;
        }
        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @" UPDATE ApplicationTypes
                                            SET ApplicationTypeTitle = @ApplicationTypeTitle,
                                                ApplicationFees = @ApplicationFees
                                            WHERE ApplicationTypeID = @ApplicationTypeID;
                                             ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            int AffectedRows = 0;
            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }
    }
}
