using DVLD_DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsTestAppointments_Data
    {
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
           DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int NewTestAppointmentID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Insert Into TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID,
                                            AppointmentDate,PaidFees,CreatedByUserID, IsLocked,RetakeTestApplicationID) 
                                        Values(@TestTypeID, @LocalDrivingLicenseApplicationID,@AppointmentDate,
                                               @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);


                    if (RetakeTestApplicationID != -1)
                    {
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
                    }
                    else
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);


                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                        {
                            NewTestAppointmentID = InsertedID;
                        }

                    }
                    catch (Exception)
                    {
                        NewTestAppointmentID = -1;

                    }

                }
            }

            return NewTestAppointmentID;
        }


        public static bool GetTestAppointmentByAppointmentID(int TestAppointmentID,
                                                              ref int TestTypeID,
                                                              ref int LocalDrivingLicenseApplicationID,
                                                              ref DateTime AppointmentDate,
                                                              ref float PaidFees,
                                                              ref int CreatedByUserID,
                                                              ref bool IsLocked,
                                                              ref int RetakeTestApplicationID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * 
                                          From TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

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
                                TestTypeID = (int)reader["TestTypeID"];
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsLocked = (bool)reader["IsLocked"];

                                if (reader["RetakeTestApplicationID"] != DBNull.Value)
                                {
                                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                }
                                else
                                    RetakeTestApplicationID = -1;

                                IsFound = true;
                            }

                        }

                    }
                    catch (Exception)
                    {

                        IsFound = false;
                    }
                }


            }
            return IsFound;
        }

        public static bool GetLastTestAppointment(int LocalDrivingLicenseApplicationID,
                                                              int TestTypeID,
                                                              ref int TestAppointmentID,
                                                              ref DateTime AppointmentDate,
                                                              ref float PaidFees,
                                                              ref int CreatedByUserID,
                                                              ref bool IsLocked,
                                                              ref int RetakeTestApplicationID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT Top 1 * 
                                          From TestAppointments
                                         WHERE (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) And (TestTypeID = @TestTypeID)
                                          Order by TestAppointmentID Desc";

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
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsLocked = (bool)reader["IsLocked"];

                                if (reader["RetakeTestApplicationID"] != DBNull.Value)
                                {
                                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                }
                                else
                                    RetakeTestApplicationID = -1;

                                IsFound = true;
                            }

                        }

                    }
                    catch (Exception)
                    {

                        IsFound = false;
                    }
                }


            }
            return IsFound;
        }

        public static DataTable GetAppliationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dtTestAppointments = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT  TestAppointmentID,AppointmentDate, PaidFees , IsLocked
                                 FROM TestAppointments
                                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                 And TestTypeID = @TestTypeID
                                   ORDER BY AppointmentDate DESC; ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            dtTestAppointments.Load(reader);

                        }
                    }
                    catch (Exception)
                    {


                    }
                }
            }

            return dtTestAppointments;


        }


        public static bool UpdateTestAppointment(int TestAppointmentID,
                                         int TestTypeID,
                                         int LocalDrivingLicenseApplicationID,
                                         DateTime AppointmentDate,
                                         float PaidFees,
                                         int CreatedByUserID,
                                         bool IsLocked,
                                         int RetakeTestApplicationID)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE TestAppointments SET
                         TestTypeID = @TestTypeID,
                         LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                         AppointmentDate = @AppointmentDate,
                         PaidFees = @PaidFees,
                         CreatedByUserID = @CreatedByUserID,
                         IsLocked = @IsLocked,
                         RetakeTestApplicationID = @RetakeTestApplicationID
                         WHERE TestAppointmentID = @TestAppointmentID AND IsLocked =0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);

                    if (RetakeTestApplicationID != -1)
                    {
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                    }

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










        ///*************
        public static bool IsExistsByTestAppointmentID(int TestAppointmentID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT 1 
                                 FROM TestAppointments
                                 WHERE TestAppointmentID = @TestAppointmentID; ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                    catch (Exception)
                    {
                        isFound = false;

                    }


                }
            }
            return isFound;
        }

        public static bool IsAppointmentLocked(int TestAppointmentID)
        {
            bool isLocked = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"
                                  Select  1 FROM TestAppointments 
                                  Where TestAppointmentID = @TestAppointmentID 
                                        AND IsLocked =1;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isLocked = reader.HasRows;
                        }
                    }
                    catch (Exception)
                    {
                        isLocked = false;

                    }
                }
            }
            return isLocked;
        }

        public static bool HasTestActiveAppointmentForLocalApplicationIDAndTestTypeID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT 1
                         FROM TestAppointments
                         WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                         And TestTypeID = @TestTypeID
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
                    catch (Exception)
                    {
                        IsFound = false;
                    }
                }
            }

            return IsFound;
        }
        public static bool SetLockedAppointment(int TestAppointmentID)
        {
            int AffcetedRows = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Update TestAppointments SET IsLocked = 1
                                 WHERE TestAppointmentID = @TestAppointmentID  And IsLocked=0;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();
                        AffcetedRows = command.ExecuteNonQuery();

                    }
                    catch (Exception)
                    {
                        AffcetedRows = 0;

                    }
                }
            }

            return (AffcetedRows > 0);
        }


    }
}
