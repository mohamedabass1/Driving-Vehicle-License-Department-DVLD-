using System;
using System.Data;
using System.Data.SqlClient;
namespace DVLD_DataAccess
{
    public static class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
                                             ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref short Gender
                                             , ref string Phone, ref string Email, ref string Address, ref int NationalityCountryID, ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from People Where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            bool IsFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = (byte)reader["Gender"];



                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                        Email = "";

                    Address = (string)reader["Address"];

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                        ImagePath = "";
                }

                reader.Close();

            }
            catch (Exception)
            {

                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
                                           ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref short Gender
                                           , ref string Phone, ref string Email, ref string Address, ref int NationalityCountryID, ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select * from People Where NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            bool IsFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = (byte)reader["Gender"];



                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                        Email = "";

                    Address = (string)reader["Address"];


                    NationalityCountryID = (int)reader["NationalityCountryID"];


                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                        ImagePath = "";
                }

                reader.Close();

            }
            catch (Exception)
            {

                IsFound = false;
            }
            finally
            {
                connection.Close();
            }


            return IsFound;
        }




        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName,
                                      string ThirdName, string LastName, DateTime DateOfBirth, short Gender
                                     , string Phone, string Email, string Address, int NationalityCountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Insert Into People (NationalNo,FirstName, SecondName,ThirdName,LastName,
                             DateOfBirth,Gender,Phone,Email,Address,NationalityCountryID,ImagePath)

                              Values(@NationalNo,@FirstName,@SecondName, @ThirdName,@LastName,@DateOfBirth,@Gender,
                                   @Phone,@Email,@Address,@NationalityCountryID,@ImagePath); 

                      SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);


            // The Gender Column Data Type in the Table is Bit 



            command.Parameters.AddWithValue("@Gender", Gender);



            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);


            command.Parameters.AddWithValue("@Address", Address);



            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


            int PersonID = -1;
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }


            return PersonID;
        }


        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
                                   string ThirdName, string LastName, DateTime DateOfBirth, short Gender
                                  , string Phone, string Email, string Address, int NationalityCountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"UPDATE People
                            SET 
                                NationalNo = @NationalNo,
                                FirstName = @FirstName,
                                SecondName = @SecondName,
                                ThirdName = @ThirdName,
                                LastName = @LastName,
                                DateOfBirth = @DateOfBirth,
                                Gender = @Gender,
                                Phone = @Phone,
                                Email = @Email,
                                Address = @Address,
                                NationalityCountryID = @NationalityCountryID,
                                ImagePath = @ImagePath
                            WHERE PersonID = @PersonID;
                            ";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);


            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);


            // The Gender Column Data Type in the Table is Bit 

            command.Parameters.AddWithValue("@Gender", Gender);


            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);


            command.Parameters.AddWithValue("@Address", Address);



            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


            int AffectedRows = 0;
            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();


            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }


            return (AffectedRows != 0);
        }


        public static bool DeletePerson(int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Delete People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            int AffectedRows = 0;
            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {


            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows != 0);

        }

        public static DataTable GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"
                            SELECT 
                                People.PersonID              AS [Person ID],
                                People.NationalNo            AS [National No],
                                People.FirstName             AS [First Name],
                                People.SecondName            AS [Second Name],
                                People.ThirdName             AS [Third Name],
                                People.LastName              AS [Last Name],
                                CASE People.Gender
                                    WHEN 0 THEN 'Male'
                                    WHEN 1 THEN 'Female'
                                END                          AS [Gender],
                                People.DateOfBirth           AS [Date of Birth],
                                Countries.CountryName        AS [Nationality],
                                People.Phone                 AS [Phone],
                                People.Email                 AS [Email]
                            FROM 
                                People 
                                INNER JOIN Countries 
                                    ON People.NationalityCountryID = Countries.CountryID;";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable PeopleDataTable = new DataTable();
            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    PeopleDataTable.Load(reader);
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

            return PeopleDataTable;
        }


        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select found=1  From People 
                             Where PersonID = @PersonID ;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = @"Select found=1  From People 
                             Where NationalNo = @NationalNo ;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }



    }
}
