using DVLD_DataAccess;
using DVLD_Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsTests_Data
    {
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int NewTestID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Insert Into Tests (TestAppointmentID, TestResult,
                                            Notes,CreatedByUserID) 
                                        Values(@TestAppointmentID, @TestResult,@Notes, @CreatedByUserID);


                                Update TestAppointments
                               Set IsLocked = 1
                                   Where TestAppointmentID = @TestAppointmentID;

                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);

                    if (!string.IsNullOrEmpty(Notes))
                    {
                        command.Parameters.AddWithValue("@Notes", Notes);
                    }
                    else
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);




                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                        {
                            NewTestID = InsertedID;
                        }

                    }
                    catch (Exception ex)
                    {
                        NewTestID = -1;

                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }

                }
            }

            return NewTestID;
        }

        public static bool GetTestByTestAppointmentID(int TestAppointmentID,
                                              ref int TestID,
                                              ref bool TestResult,
                                              ref string Notes,
                                              ref int CreatedByUserID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM Tests
                         WHERE TestAppointmentID=@TestAppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestID = (int)reader["TestID"];
                                TestResult = (bool)reader["TestResult"];

                                if (reader["Notes"] != DBNull.Value)
                                    Notes = (string)reader["Notes"];
                                else
                                    Notes = "";

                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                IsFound = true;
                            }
                        }
                    }
                    catch
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }

        public static bool GetTestByTestID(int TestID,
                                       ref int TestAppointmentID,
                                      ref bool TestResult,
                                      ref string Notes,
                                      ref int CreatedByUserID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM Tests
                         WHERE TestID=@TestID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", TestID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestResult = (bool)reader["TestResult"];

                                if (reader["Notes"] != DBNull.Value)
                                    Notes = (string)reader["Notes"];
                                else
                                    Notes = "";

                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                IsFound = true;
                            }
                        }
                    }
                    catch
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }


        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int AffectedRows = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Update Tests
                            set TestAppointmentID = @TestAppointmentID,
                                TestResult = @TestResult,
                                Notes = @Notes,
                                CreatedByUserID = @CreatedByUserID
                                where TestID = @TestID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestID", TestID);
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);

                    if (!string.IsNullOrEmpty(Notes))
                    {
                        command.Parameters.AddWithValue("@Notes", Notes);
                    }
                    else
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();

                        AffectedRows = command.ExecuteNonQuery();



                    }
                    catch (Exception)
                    {
                        AffectedRows = 0;
                    }

                }
            }

            return (AffectedRows > 0);

        }

        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = "SELECT * FROM Tests order by TestID";

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool GetLastTestPerApplicationIDAndTestType(int LocalDrivingLicenseApplicationID, int TestTypeID, ref int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Select TOP 1 Tests.TestID , Tests.TestAppointmentID , Tests.TestResult, Tests.Notes, Tests.CreatedByUserID 
                                   From LocalDrivingLicenseApplications
                                  Inner Join TestAppointments On TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                                  Inner Join Tests On Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                  Where (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) AND (TestAppointments.TestTypeID = @TestTypeID)
                                  order by TestAppointments.AppointmentDate Desc;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestID = (int)reader["TestID"];
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestResult = (bool)reader["TestResult"];

                                if (reader["Notes"] == DBNull.Value)
                                    Notes = "";
                                else
                                    Notes = (string)reader["Notes"];

                                CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static int GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {

            int NumberOfPassedTests = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT PassedTestCount = count(TestTypeID)
                         FROM Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						 where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestResult=1;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        NumberOfPassedTests = (int)result;


                    }
                    catch (Exception ex)
                    {

                        NumberOfPassedTests = 0;
                        clsEventLogger.Log(ex.Message, System.Diagnostics.EventLogEntryType.Error);


                    }
                }


            }

            return NumberOfPassedTests;

        }


    }
}
