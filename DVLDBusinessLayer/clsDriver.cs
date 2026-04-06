using DVLDDataAccessLayer;
using System;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsDriver
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;


        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }


        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;

            _Mode = enMode.AddNew;
        }
        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;

            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);

            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            _Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.DriverID = clsDriver_Data.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);

            return (DriverID != -1);
        }

        private bool _Update()
        {
            return clsDriver_Data.UpdateDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static clsDriver Find(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool isFound = clsDriver_Data.GetDriverByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate);

            if (isFound)
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }
        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool isFound = clsDriver_Data.GetDriverByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate);

            if (isFound)
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }



        public static DataTable GetAllDrivers()
        {
            return clsDriver_Data.GetAllDrivers();
        }

        public DataTable GetLicenses()
        {
            return clsLicense.GetDriverLicenses(this.DriverID);
        }

    }
}
