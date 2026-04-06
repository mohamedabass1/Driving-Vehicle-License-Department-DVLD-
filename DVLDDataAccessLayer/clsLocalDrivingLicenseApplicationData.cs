using DVLD_DataAccess;
using DVLD_Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public static class clsLocalDrivingLicenseApplicationData
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID,
                                                                                    ref int LicenseClassID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * From LocalDrivingLicenseApplications 
                       Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID; ";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);



            bool isFuond = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFuond = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                isFuond = false;
            }
            finally
            {
                connection.Close();

            }

            return isFuond;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(
                  int ApplicationID, ref int LocalDrivingLicenseApplicationID,
                  ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"
                            	SELECT * FROM LocalDrivingLicenseApplications_View
                                 ORDER BY [Application Date] DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dt = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into LocalDrivingLicenseApplications 
                                    (ApplicationID,LicenseClassID)
                             Values( @ApplicationID,@LicenseClassID); 
              SELECT SCOPE_IDENTITY();";





            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int NewLocalDrivingLicenseAppID = -1;

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    NewLocalDrivingLicenseAppID = InsertedID;
                }
            }
            catch (Exception)
            {

                NewLocalDrivingLicenseAppID = -1;
            }
            finally
            {
                connection.Close();
            }

            return NewLocalDrivingLicenseAppID;

        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID,
                                                                            int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"UPDATE LocalDrivingLicenseApplications
                     SET 
                        ApplicationID = @ApplicationID,
                        LicenseClassID = @LicenseClassID
                     WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int AffectedRows = 0;

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                AffectedRows = 0;
            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"DELETE FROM LocalDrivingLicenseApplications
                     WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            int AffectedRows = 0;

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch
            {
                AffectedRows = 0;
            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static int GetTotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int TotalTiral = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {

                string query = @"
                               SELECT    TotalTiral = Count(TestID)
                               FROM      LocalDrivingLicenseApplications INNER JOIN
                                         TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            				Where (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID) 
                                                AND (TestAppointments.TestTypeID = @TestTypeID) ;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Count))
                        {
                            TotalTiral = Count;
                        }
                    }
                    catch (Exception ex)
                    {

                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }

            return TotalTiral;
        }


        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;


            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT        1
                                    FROM LocalDrivingLicenseApplications INNER JOIN
                                         TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                    Where (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ) and TestAppointments.TestTypeID = @TestTypeID;";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Result = reader.HasRows;
                        }
                    }
                    catch (Exception ex)
                    {
                        Result = false;

                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }
                }
            }


            return Result;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT 1
                         FROM TestAppointments
                         WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                         AND TestTypeID = @TestTypeID
                         AND IsLocked = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            IsFound = reader.HasRows;
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

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Select  1 from LocalDrivingLicenseApplications 
	                                Inner join TestAppointments On  TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
	                                Inner join Tests ON  Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
	                                	Where  (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) and (TestAppointments.TestTypeID = @TestTypeID) and (Tests.TestResult = 1) ;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            IsFound = reader.HasRows;
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



    }
}
