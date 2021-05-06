using System;
using System.Collections.Specialized;
using NTIER.Common.Interface;
using Rafaelle.Framework;

namespace NTIER.Common.Entity
{
    public partial class UserTypeModuleEntity : ModelBase, IUserTypeModuleEntity, IValidatable
    {


        #region > Variables


        private int _userTypeModuleId;

        private byte _userTypeId;

        private short _moduleId;

        private long _permission;

        private DateTime _created;

        private string _createdBy;

        private DateTime _updated;

        private string _updatedBy;

        #endregion


        #region > Constructor


        public UserTypeModuleEntity()
        {

        }
        
        public UserTypeModuleEntity(int userTypeModuleId, 
            byte userTypeId, 
            short moduleId, 
            long permission, 
            DateTime created, 
            string createdBy, 
            DateTime updated, 
            string updatedBy)
        {
            _userTypeModuleId = userTypeModuleId;
            _userTypeId = userTypeId;
            _moduleId = moduleId;
            _permission = permission;
            _created = created;
            _createdBy = createdBy;
            _updated = updated;
            _updatedBy = updatedBy;

        }

        public UserTypeModuleEntity(NameValueCollection form)
        {
            UserTypeModuleId = Convert.ToInt32(form["userTypeModuleId"]);
            UserTypeId = Convert.ToByte(form["userTypeId"]);
            ModuleId = Convert.ToInt16(form["moduleId"]);
            Permission =Convert.ToInt64(form["permission"].Trim());
            Created = Convert.ToDateTime(form["created"]);
            CreatedBy = form["createdBy"];
            Updated = Convert.ToDateTime(form["updated"]);
            UpdatedBy = form["updatedBy"];
        }

        #endregion




        #region > Properties
        
        public int UserTypeModuleId
        {
            get { return _userTypeModuleId; }
            set { _userTypeModuleId = value; }
        }

        public byte UserTypeId
        {
            get { return _userTypeId; }
            set { _userTypeId = value; }
        }

        public short ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }

        public long Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        public DateTime Updated
        {
            get { return _updated; }
            set { _updated = value; }
        }
        public string UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }

        #endregion
    }
}
