using System;
using System.Collections.Specialized;
using NTIER.Common.Interface;
using Rafaelle.Framework;

namespace NTIER.Common.Entity
{
    [Serializable]
    public partial class UserTypeModuleListEntity : ModelBase, IUserTypeModuleListEntity, IValidatable
    {

        #region > Variables

        private int _userTypeModuleId;
        private short _moduleId;
        private byte _userTypeId;
        private string _moduleName;
        private long _permission;
        private long _validPermission;

        #endregion


        #region > Constructors

        public UserTypeModuleListEntity()
        {

        }

        public UserTypeModuleListEntity(int userTypeModuleId,
            short moduleId,
            byte userTypeId,
            string moduleName,
            long permission,
            long validPermission)
        {
            _userTypeModuleId = userTypeModuleId;
            _moduleId = moduleId;
            _userTypeId = userTypeId;
            _moduleName = moduleName;
            _permission = permission;
            _validPermission = validPermission;

        }

        public UserTypeModuleListEntity(NameValueCollection form)
        {
            UserTypeModuleId = Convert.ToInt32(form["userTypeModuleId"]);
            ModuleId = Convert.ToInt16(form["moduleId"]);
            UserTypeId = Convert.ToByte(form["userTypeId"]);
            ModuleName = form["moduleName"].ToString();
            Permission = Convert.ToInt64(form["permission"]);
            ValidPermission = Convert.ToInt64(form["validPermission"]);

        }

        #endregion

        #region > Properties

        public int UserTypeModuleId
        {
            get
            {
                return _userTypeModuleId;
            }

            set
            {
                _userTypeModuleId = value;
            }
        }

        public short ModuleId
        {
            get
            {
                return _moduleId;
            }

            set
            {
                _moduleId = value;
            }
        }

        public byte UserTypeId
        {
            get
            {
                return _userTypeId;
            }

            set
            {
                _userTypeId = value;
            }
        }

        public string ModuleName
        {
            get
            {
                return _moduleName;
            }

            set
            {
                _moduleName = value;
            }
        }

        public long Permission
        {
            get
            {
                return _permission;
            }

            set
            {
                _permission = value;
            }
        }

        public long ValidPermission
        {
            get
            {
                return _validPermission;
            }

            set
            {
                _validPermission = value;
            }
        }


        #endregion

        public NameValueCollection ToNameValueCollection()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("UserTypeModuleId", UserTypeModuleId.ToString());
            collection.Add("ModuleId", ModuleId.ToString());
            collection.Add("UserTypeId", UserTypeId.ToString());
            collection.Add("ModuleName", ModuleName);
            collection.Add("Permission", Permission.ToString());
            collection.Add("ValidPermission", ValidPermission.ToString());

            return collection;
        }

    }
}
