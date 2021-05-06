using System;
using System.Collections.Specialized;
using NTIER.Common.Interface;
using Rafaelle.Framework;

namespace NTIER.Common.Entity
{
    public partial class UserTypeEntity : ModelBase, IUserTypeEntity, IValidatable
    {

        #region > Variables

        private byte _userTypeId;
        private string _userTypeName;


        #endregion


        #region > Constructors

        public UserTypeEntity()
        {

        }

        public UserTypeEntity(byte userTypeId,
            string userTypeName)
        {
            _userTypeId = userTypeId;
            _userTypeName = userTypeName;

        }

        public UserTypeEntity(NameValueCollection form)
        {
            UserTypeId = Convert.ToByte(form["userTypeId"]);
            UserTypeName = form["UserTypeName"];

        }



        #endregion



        #region > Properties



        public byte UserTypeId
        {
            get { return _userTypeId; }
            set { _userTypeId = value; }
        }


        public string UserTypeName
        {
            get { return _userTypeName; }
            set { _userTypeName = value; }
        }



        #endregion



    }
}
