using DVLDDataAccessLayer;
using System;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsInternationalLicense
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication ApplicationInfo;
        public int DriverID { get; set; }
        public clsDriver DriverInfo;
        public int IssuedUsingLocalLicenseID { get; set; }
        public clsLicense LocalLicenseInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }


        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;

            _Mode = enMode.AddNew;
        }

        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssuedDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            ApplicationInfo = clsApplication.FindBaseApplication(ApplicationID);

            this.DriverID = DriverID;
            DriverInfo = clsDriver.Find(DriverID);

            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            LocalLicenseInfo = clsLicense.FindByLicenseID(IssuedUsingLocalLicenseID);

            this.IssueDate = IssuedDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            InternationalLicenseID = clsInternationalLicenses_Data.AddNewInternationalLicense(ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                IssueDate, ExpirationDate, IsActive, CreatedByUserID);

            return (InternationalLicenseID != -1);

        }

        private bool _Update()
        {
            return clsInternationalLicenses_Data.UpdateInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                IssueDate, ExpirationDate, IsActive, CreatedByUserID);
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


        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -2, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;


            bool isFound = clsInternationalLicenses_Data.GetInternationalLicenseByID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID,
              ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID);

            if (isFound)
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
                return null;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenses_Data.GetAllInternationalLicenses();
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenses_Data.GetDriverInternationalLicenses(DriverID);
        }
        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenses_Data.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }

        public int GetActiveLicense()
        {
            return GetActiveInternationalLicenseIDByDriverID(this.DriverID);
        }

        public bool DeactivateCurrentLicense()
        {
            return clsInternationalLicenses_Data.DeactivateInternationalLicense(InternationalLicenseID);
        }

        public bool IsLicenseExpired()
        {
            return (this.ExpirationDate < DateTime.Now);
        }


    }
}
