using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common
{
    [Serializable]
    public class UserIdentity
    {
        private Guid _userId;
        private EnumUserType _userType;
        private string _username;
        private string _userSessionId;
        private bool _isSessionActive;
        private bool _isLoggedIn;
        private double _timezoneHours;
        private string _userFullname;

        public UserIdentity()
        {
            Modules = new List<KeyValuePair<int, long>>();
        }


        public UserIdentity(Guid userId,
            EnumUserType userType,
            string username,
            string userSessionId,
            bool isSessionActive,
            bool isLoggedIn,
            double timezoneHours,
            string userFullname)
        {
            UserId = userId;
            UserType = userType;
            Username = username;
            UserSessionID = userSessionId;
            IsSessionActive = isSessionActive;
            IsLoggedIn = isLoggedIn;
            TimezoneHours = timezoneHours;
            Modules = new List<KeyValuePair<int, long>>();
         
            UserFullname = userFullname;
        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public EnumUserType UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string UserFullname
        {
            get { return _userFullname; }
            set { _userFullname = value; }
        }

        public string UserSessionID
        {
            get { return _userSessionId; }
            set { _userSessionId = value; }
        }

        public bool IsSessionActive
        {
            get { return _isSessionActive; }
            set { _isSessionActive = value; }
        }

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; }
        }

        public double TimezoneHours
        {
            get { return _timezoneHours; }
            set { _timezoneHours = value; }
        }


        //-- id, permission
        public List<KeyValuePair<int, long>> Modules
        {
            get;
            set;
        }

        public EnumPermission GetModulePermission(int moduleID)
        {
            if (Modules == null || Modules.Count == 0)
                return EnumPermission.None;

            var selectedModule = from module in Modules
                                 where module.Key == moduleID
                                 select module;

            if (selectedModule != null && selectedModule.Count<KeyValuePair<int, long>>() > 0)
            {
                return (EnumPermission)selectedModule.First<KeyValuePair<int, long>>().Value;
            }

            return EnumPermission.None;
        }

        public bool HasViewAccessAnyAdminModule()
        {
            bool retVal = false;

            retVal = retVal || ((GetModulePermission((int)EnumModule.User) & EnumPermission.View) == EnumPermission.View);

            return retVal;
        }

        public bool HasViewAccessAnyProjectModule()
        {
            bool retVal = false;


            return retVal;
        }


    }
}
