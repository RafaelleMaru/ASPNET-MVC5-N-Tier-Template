using System;
using System.Collections.Generic;

namespace NTIER.Common.Entity
{
    public partial class UserTypeEntity
    {
        
        #region > IValidatable Members

        public string ValidationMessage
        {
            get { return base.ErrorMessages.ToString(); }
        }

        public bool Validate()
        {

            
            if (String.IsNullOrEmpty(UserTypeName.Trim()) && UserTypeName.Trim().Length == 0)
                ErrorMessages.Add(Constants.UserTypeUserTypeNameRequired);

            

            return base.ErrorMessages.Count == 0;
        }

        #endregion
        

        #region > Custom Collection

        
        public IList<UserTypeModuleEntity> UserTypeModuleList { get; set; }


        #endregion


    }
}
