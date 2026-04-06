using DVLDDataAccessLayer;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsUser
    {

        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }


        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;

            _Mode = enMode.AddNew;
        }
        private clsUser(int UserID, int PersonID, string UserName, string Password, bool isActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = isActive;

            _Mode = enMode.Update;
        }

        public static clsUser FindUserByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
                return null;
        }
        public static clsUser FindUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
                return null;
        }
        public static clsUser FindUserByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            if (clsUserData.GetUserByUserNameAndPassword(UserName, clsHashHelper.ComputeHash(Password), ref UserID, ref PersonID, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
                return null;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, clsHashHelper.ComputeHash(this.Password), this.IsActive);

            return (this.UserID != -1);
        }
        private bool _UpdateUserInfo()
        {
            return clsUserData.UpdateUserInfo(this.UserID, this.UserName, clsHashHelper.ComputeHash(this.Password), this.IsActive);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {

                        return _UpdateUserInfo();
                    }
            }

            return false;

        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }
        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool IsUserExist(string UserName, string Password)
        {
            return clsUserData.IsUserExist(UserName, clsHashHelper.ComputeHash(Password));
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }

        public bool ChangePassword(string NewPassword)
        {
            return clsUserData.ChangePassword(this.UserID, clsHashHelper.ComputeHash(NewPassword));
        }
    }
}
