using DVLD_DataAccess;
using DVLDBusinessLayer.Properties;
using System;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsPerson
    {
        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public clsCountry Country;

        public clsPerson()
        {

            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            _Mode = enMode.AddNew;

        }

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName,
                                              string ThirdName, string LastName, DateTime DateOfBirth, short Gender
                                             , string Phone, string Email, string Address, int NationalityCountryID, string ImagePath)
        {

            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            this.Country = clsCountry.Find(NationalityCountryID);
            _Mode = enMode.Update;


        }
        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "",
               ThirdName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "";
            short Gender = 0;

            DateTime DateOfBirth = DateTime.Now;

            int NationalityCountryID = -1;

            if (clsPersonData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName,
                                             ref ThirdName, ref LastName, ref DateOfBirth, ref Gender
                                             , ref Phone, ref Email, ref Address, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                     DateOfBirth, Gender, Phone, Email, Address, NationalityCountryID, ImagePath);
            }
            else
                return null;

        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "",
                  Phone = "", Email = "", Address = "", ImagePath = "";

            short Gender = 0;

            DateTime DateOfBirth = DateTime.Now;

            int NationalityCountryID = -1;

            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName,
                                             ref ThirdName, ref LastName, ref DateOfBirth, ref Gender
                                             , ref Phone, ref Email, ref Address, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                     DateOfBirth, Gender, Phone, Email, Address, NationalityCountryID, ImagePath);
            }
            else
                return null;

        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                                     this.DateOfBirth, this.Gender, this.Phone, this.Email, this.Address, this.NationalityCountryID, this.ImagePath);

            return (PersonID != -1);
        }

        private bool _Update()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                                     this.DateOfBirth, this.Gender, this.Phone, this.Email, this.Address, this.NationalityCountryID, this.ImagePath);
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }


        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    };

                case enMode.Update:
                    {

                        return _Update();
                    }
            }

            return false;
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

    }
}
