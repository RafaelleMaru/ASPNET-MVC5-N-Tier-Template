using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTIER.BLL;
using NTIER.Common;
using NTIER.Common.Entity;
using Rafaelle.Framework;

namespace NTIER.Web.Controllers
{
    [Authorize]
    public class  BaseController : Controller
    {

        protected FormCollection Form;
        protected object ID;
        protected ErrorMessageCollection ErrorMessage;
        private EnumPermission _action = EnumPermission.None;
        private string _ip;
        //private string _user


        public BaseController()
        {
            ErrorMessage = new ErrorMessageCollection();
        }
        protected virtual EnumModule CurrentModule
        {
            get { return EnumModule.None; }
        }


        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Request.IsAuthenticated || !User.Identity.IsAuthenticated)
            {
                
                MessageResult result = new MessageResult(Constants.AccessDenied,
                    true,
                    null);
                filterContext.Result = Json(result, JsonRequestBehavior.AllowGet);
                return;


            }

            base.OnActionExecuting(filterContext);

            ViewBag.CurrentUser = CurrentUser;


        }

        internal UserIdentity CurrentUser
        {
            get
            {

                if (!Request.IsAuthenticated || !User.Identity.IsAuthenticated)
                {
                    return null;
                }

                if (Session[Constants.KeyUser] == null)
                {
                    UserEntity user = UserBLL.GetByUsername(User.Identity.Name);

                    if (user == null)
                        return null;

                  

                    UserIdentity userIdentity = new UserIdentity(user.UserId,
                        (EnumUserType)user.UserTypeId,
                        user.Username,
                        String.Empty,
                        true,
                        false,
                        8,
                        user.Firstname + " " + user.Lastname); //Convert.ToInt16(Cerquit.Framework.Security.SecuritySupport.Decrypt(Request.Cookies[Constants.KEY_FACILITY].Value))


                    //TODO: SECURITY - initialize permissions
                    InitializePermissions(userIdentity);
                    Session[Constants.KeyUser] = userIdentity;

                    return userIdentity;
                }

                return (UserIdentity)Session[Constants.KeyUser];

            }
        }



        protected string CurrentUserName
        {
            get
            {
                string retVal = String.Empty;
                bool IsPublicUser = (CurrentUser.UserType == EnumUserType.PublicUser) ? true : false;

                if (IsPublicUser)
                    return retVal = CurrentUser.Username;

                return retVal;
            }
        }

        protected bool IsEditMode
        {
            get
            {
                if (ID == null)
                    return false;

                if (ID is Guid)
                {
                    return new Guid(ID.ToString()).CompareTo(Guid.Empty) != 0;
                }

                else if (ID is int || ID is short || ID is byte)
                {
                    return Convert.ToInt32(ID.ToString()) > 0;
                }

                return false;
            }
        }

        protected virtual bool ValidateBeforeSave()
        {
            Action = IsEditMode ? EnumPermission.Edit : EnumPermission.Add;

            if (!ValidateModulePermission())
            {
                ErrorMessage.Add(Constants.CommonAccessDenied);
                return false;
            }

            return true;
        }

        protected virtual bool ValidateBeforeDelete()
        {
            Action = EnumPermission.Delete;

            if (!ValidateModulePermission())
            {
                ErrorMessage.Add(Constants.CommonAccessDenied);
                return false;
            }

            return true;
        }


        protected virtual bool ValidateBeforeInitialize()
        {
            Action = EnumPermission.View; //-- when you initialize you are viewing

            if (!ValidateModulePermission())
            {
                ErrorMessage.Add(Constants.CommonAccessDenied);
                return false;
            }

            return true;
        }

        protected virtual bool ValidateBeforeListView()
        {
            Action = EnumPermission.ListView;

            if (!ValidateModulePermission())
            {
                ErrorMessage.Add(Constants.CommonAccessDenied);
                return false;
            }

            return true;
        }

        public string IP
        {
            get
            {
                if (String.IsNullOrEmpty(_ip) || _ip.Trim() == String.Empty)
                    _ip = GetIPAddress(Request);

                return _ip;
            }
        }

        private static string GetIPAddress(HttpRequestBase request)
        {
            string ip;

            try
            {
                ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!string.IsNullOrEmpty(ip))
                {
                    if (ip.IndexOf(",") > 0)
                    {
                        string[] ipRange = ip.Split(',');
                        //int le = ipRange.Length - 1;
                        ip = ipRange[0];
                    }
                }

                else
                {
                    //ip = request.UserHostAddress;
                    ip = request.ServerVariables["REMOTE_ADDR"];
                }
            }

            catch
            {
                ip = "UNKNOWN";
            }

            return ip;
        }

        protected EnumPermission Action
        {
            get { return _action; }
            set { _action = value; }
        }

        protected bool ValidateModulePermission()
        {
          
            UserIdentity identity = CurrentUser;

            if (identity == null)
                return false;

            //get user permission in given module
            EnumPermission permission =
                identity.GetModulePermission((int)CurrentModule);

            //check if the the user has permission to his/her action
            if ((permission & Action) == Action)
                return true;

            return false;

        }

        private void InitializePermissions(UserIdentity userIdentity)
        {
            //-- added projects
            InitializeUserModulePermissions(userIdentity);

        }

        private void InitializeUserModulePermissions(UserIdentity userIdentity)
        {
            //TODO: SECURITY - intitialize user module permission



            IList<UserTypeModuleListEntity> list = UserTypeModuleListBLL.GetByUserTypeID((byte)userIdentity.UserType);

            if (list == null || list.Count == 0)
                return;

            foreach (UserTypeModuleListEntity entity in list)
            {
                KeyValuePair<int, long> existingValue = userIdentity.Modules.ToList().FirstOrDefault(c => c.Key.Equals(entity.ModuleId));

                if (existingValue.Key > 0)
                {
                    EnumPermission newValue = (EnumPermission)existingValue.Value | (EnumPermission)entity.Permission;

                    userIdentity.Modules.Remove(new KeyValuePair<int, long>(existingValue.Key, existingValue.Value));
                    userIdentity.Modules.Add(new KeyValuePair<int, long>(existingValue.Key, (int)newValue));

                }
                else
                {
                    userIdentity.Modules.Add(new KeyValuePair<int, long>(entity.ModuleId, entity.Permission));
                }
            }
            


        }


  
    }
}