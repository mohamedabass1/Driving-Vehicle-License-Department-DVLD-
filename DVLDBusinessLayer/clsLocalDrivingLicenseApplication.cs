using DVLDDataAccessLayer;
using System;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;


        public int LocalDrivingLicenseAppID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLicenseClass LicenseClassInfo;

        public string PersonFullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }

        }


        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseAppID = -1;
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;


        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseAppID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
         int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
         float PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            this.LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.LicenseClassID = LicenseClassID;
            LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);

            Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseAppID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication
                (
                ApplicationID, this.LicenseClassID);
            return (this.LocalDrivingLicenseAppID != -1);
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseAppID,
                                               this.ApplicationID, this.LicenseClassID);

        }
        public bool Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.

            base._Mode = (clsApplication.enMode)Mode;

            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLocalDrivingLicenseApplication())
                        {
                            Mode = enMode.Update;
                            return true;

                        }

                    }
                    break;
                case enMode.Update:
                    {
                        return _UpdateLocalDrivingLicenseApplication();
                    }

            }

            return false;
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseAppID)
        {
            int ApplicationID = -1, LicenseClassID = -1;


            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseAppID, ref ApplicationID, ref LicenseClassID);

            // Find The base Class
            if (isFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseAppID, ApplicationID, Application.ApplicantPersonID
                    , Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate,
                    Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            // 
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID
                (ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingLicenseApplication(
                    LocalDrivingLicenseApplicationID, Application.ApplicationID,
                    Application.ApplicantPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;


        }

        public bool Delete()
        {
            bool isLocalDrivingLicenseAppDeleted = false;
            bool isBaseApplicationDeleted = false;

            // we start to delete local Application
            isLocalDrivingLicenseAppDeleted = clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseAppID);


            if (isLocalDrivingLicenseAppDeleted)
            {
                // then we delete the base application
                isBaseApplicationDeleted = clsApplication.Delete(this.ApplicationID);
            }

            return isBaseApplicationDeleted;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }


        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.GetTotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public int TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.GetTotalTrialsPerTest(this.LocalDrivingLicenseAppID, (int)TestTypeID);
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseAppID, (int)TestTypeID);
        }


        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseAppID, (int)TestTypeID);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseAppID, (int)TestTypeID);
        }

        public static int GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public int GetPassedTestCount()
        {
            return GetPassedTestCount(this.LocalDrivingLicenseAppID);
        }

        public bool PassedAllTests()
        {
            return (GetPassedTestCount(this.LocalDrivingLicenseAppID) == 3);
        }
        public static clsTest GetLastTestPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTest.GetLastTestPerApplicationIDAndTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.GetLastTestPerApplicationIDAndTestType(this.LocalDrivingLicenseAppID, TestTypeID);
        }


        public static bool IsLicenseIssued(int ApplicantPersonID, int LicenseClassID)
        {
            return (clsLicense.GetActiveLicenseIDByPersonID(ApplicantPersonID, LicenseClassID) != -1);
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }


        public int IssueLicenseFirstTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;
            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                Driver.CreatedDate = DateTime.Now;

                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                    return -1;
            }
            else
                DriverID = Driver.DriverID;

            clsLicense License = new clsLicense();

            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClassID = this.LicenseClassID;
            License.IssueDate = DateTime.Now;

            License.ExpirationDate = License.IssueDate.AddYears(LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;

            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                SetCompleted();
                return License.LicenseID;
            }
            else
                return -1;
        }
    }
}
