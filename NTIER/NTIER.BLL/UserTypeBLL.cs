using NTIER.Common.Entity;
using NTIER.DAL;

namespace NTIER.BLL
{
    public partial class UserTypeBLL
    {


        public static UserTypeEntity GetByUserTypeName(string userTypeName)
        {
            using (UserTypeDAL dal = new UserTypeDAL(GetConnectionInfo()))
            {
                return dal.SelectByUserTypeName(userTypeName);
            }
        }

        public static bool UserTypeNameExist(string userTypeName, byte id)
        {
            UserTypeEntity userType = GetByUserTypeName(userTypeName);
            if (userType != null)
            {
                if ((id == 0) || (userType.UserTypeId != id))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Get record by userID.
        /// </summary>
        /// <param name="userId">Select by Id.</param>
        /// <returns>Record of User.</returns>
        public static UserTypeEntity GetById(byte userTypeId)
        {
            using (UserTypeDAL dal = new UserTypeDAL(GetConnectionInfo()))
            {
                return dal.SelectById(userTypeId);
            }
        }


    }
}
