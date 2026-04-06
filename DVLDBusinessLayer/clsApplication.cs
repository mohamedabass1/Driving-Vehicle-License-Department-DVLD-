using DVLDDataAccessLayer;
using System;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public enMode _Mode = enMode.AddNew;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }



        // (int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, 
        // int ApplicationTypeID, short ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }

        public clsPerson PersonInfo { get; set; }

        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo;

        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Canceled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";

                }
            }
        }

        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public clsUser CreatedByUserInfo;


        public clsApplication()
        {

            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            _Mode = enMode.AddNew;
        }


        private clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
         int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
         float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindUserByUserID(CreatedByUserID);

            _Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplications_Data.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                (byte)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            return (this.ApplicationID != -1);
        }
        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsApplications_Data.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        }

        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;


            bool Found = clsApplications_Data.GetApplicationByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate,
                ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID);


            if (Found)
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                                   (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            }
            else
                return null;

        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewApplication())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                case enMode.Update:
                    {
                        return _UpdateApplication();
                    }
            }
            return false;
        }

        public bool Cancel()
        {
            return clsApplications_Data.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Cancelled);
        }

        public bool SetCompleted()
        {
            return clsApplications_Data.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Completed);
        }

        public static bool Delete(int ApplicationID)
        {
            return clsApplications_Data.DeleteApplication(ApplicationID);
        }



        public static DataTable GetAllApplication()
        {
            return clsApplications_Data.GetAllApplications();
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplications_Data.IsApplicationExist(ApplicationID);
        }

        public bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplications_Data.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, enApplicationType ApplicationTypeID)
        {
            return clsApplications_Data.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }
        public int GetActiveApplicationID(enApplicationType ApplicationTypeID)
        {
            return clsApplications_Data.GetActiveApplicationID(this.ApplicantPersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplications_Data.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

    }
}