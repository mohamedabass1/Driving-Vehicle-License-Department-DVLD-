using DVLDDataAccessLayer;
using System;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsLicense
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 }


        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }

        public int DriverID { get; set; }
        public clsDriver DriverInfo;
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }

        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        public bool IsDetained { get; set; }
        public clsDetainedLicense DetainInfo { get; set; }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;

            _Mode = enMode.AddNew;

        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
             string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;

            this.DriverID = DriverID;
            this.DriverInfo = clsDriver.Find(DriverID);

            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);

            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;

            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;

            this.IssueReason = IssueReason;

            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindUserByUserID(CreatedByUserID);

            IsDetained = clsDetainedLicense.IsLicenseDetained(LicenseID);
            if (IsDetained)
                DetainInfo = clsDetainedLicense.GetDetainedLicenseInfoByLicenseID(LicenseID);


            _Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicense_Data.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                Notes, PaidFees, IsActive, (int)IssueReason, CreatedByUserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicense_Data.UpdateLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                Notes, PaidFees, IsActive, (int)IssueReason, CreatedByUserID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateLicense();

            }

            return false;
        }

        public static clsLicense FindByLicenseID(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            int IssueReason = -1;
            int CreatedByUserID = -1;

            bool isFound = clsLicense_Data.GetLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);


            if (isFound)
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

        public static clsLicense FindLicenseByDriverIDAndLicenseClass(int DriverID, int LicenseClass)
        {
            int LicenseID = -1, ApplicationID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            int IssueReason = 1;
            int CreatedByUserID = -1;

            bool isFound = clsLicense_Data.GetLicenseByDriverIDAndLicenseClass(DriverID, LicenseClass, ref LicenseID, ref ApplicationID, ref IssueDate, ref ExpirationDate,
                ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);


            if (isFound)
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

        public static DataTable GetAllLicenses()
        {
            return clsLicense_Data.GetAllLicenses();
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicense_Data.GetDriverLicenses(DriverID);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClass)

        {
            return clsLicense_Data.GetActiveLicenseIDByPersonID(PersonID, LicenseClass);
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClass)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClass) != -1);
        }

        public bool IsLicenseExpired()
        {
            return (this.ExpirationDate < DateTime.Now);
        }

        public static bool IsActiveLicense(int LicenseID)
        {
            return clsLicense_Data.IsActiveLicense(LicenseID);
        }

        public bool DeactivateCurrentLicense()
        {
            return clsLicense_Data.DeactivateLicense(LicenseID);
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:

                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacementForDamaged:
                    return "Replacement For Damaged";
                case enIssueReason.ReplacementForLost:
                    return "Replacement For Lost";
                default:
                    return "First Time";
            }
        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            if (!this.IsLicenseExpired())
                return null;

            // first create application
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUserID = CreatedByUserID;


            if (!Application.Save())
                return null;


            clsLicense NewLicense = new clsLicense
            {
                ApplicationID = Application.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength),
                Notes = Notes,
                PaidFees = this.LicenseClassInfo.ClassFees,
                IsActive = true,
                IssueReason = enIssueReason.Renew,
                CreatedByUserID = CreatedByUserID
            };

            if (!NewLicense.Save())
            {
                // once the license dose not saved we delete the application.
                clsApplication.Delete(Application.ApplicationID);
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;

        }
        public clsLicense Replace(enIssueReason issueReason, int createdByUserID)
        {
            //  the license must to by an active to replace
            if (!this.IsActive)
                return null;

            if (issueReason != enIssueReason.ReplacementForDamaged && issueReason != enIssueReason.ReplacementForLost)
                return null;

            clsApplication application = new clsApplication
            {
                ApplicantPersonID = this.DriverInfo.PersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = (int)(issueReason == enIssueReason.ReplacementForDamaged ?
                                      clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                                      clsApplication.enApplicationType.ReplaceLostDrivingLicense),

                ApplicationStatus = clsApplication.enApplicationStatus.Completed,
                LastStatusDate = DateTime.Now,
                PaidFees = clsApplicationType.Find((int)(issueReason == enIssueReason.ReplacementForDamaged ? clsApplication.enApplicationType.ReplaceDamagedDrivingLicense
                : clsApplication.enApplicationType.ReplaceLostDrivingLicense)).Fees,
                CreatedByUserID = createdByUserID
            };

            if (!application.Save())
                return null;

            clsLicense NewLicense = new clsLicense
            {
                ApplicationID = application.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = this.ExpirationDate,
                Notes = this.Notes,
                PaidFees = this.LicenseClassInfo.ClassFees,
                IsActive = true,
                IssueReason = issueReason,
                CreatedByUserID = createdByUserID
            };

            if (!NewLicense.Save())
            {
                clsApplication.Delete(application.ApplicationID);
                return null;
            }

            //we need to deactivate the Dammaged or Lost License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsDetainedLicense DetainLicense(float FineFees, int CreatedByUserID)
        {
            if (this.IsDetained)
                return null;

            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = FineFees;
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
                return null;


            this.IsDetained = true;
            this.DetainInfo = detainedLicense;

            return detainedLicense;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID)
        {
            if (!this.IsDetained)
                return false;


            clsApplication application = new clsApplication
            {
                ApplicantPersonID = this.DriverInfo.PersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense,
                ApplicationStatus = clsApplication.enApplicationStatus.Completed,
                LastStatusDate = DateTime.Now,
                PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees,

                CreatedByUserID = ReleasedByUserID
            };


            if (!application.Save())
                return false;

            this.DetainInfo.IsReleased = true;
            this.DetainInfo.ReleaseDate = DateTime.Now;
            this.DetainInfo.ReleaseApplicationID = application.ApplicationID;
            this.DetainInfo.ReleasedByUserID = ReleasedByUserID;

            if (!this.DetainInfo.Release())
                return false;


            this.IsDetained = false;
            return true;

        }
    }
}
