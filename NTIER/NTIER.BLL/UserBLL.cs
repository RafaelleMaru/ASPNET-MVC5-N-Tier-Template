using System;
using System.Collections.Generic;
using NTIER.Common.Entity;
using NTIER.DAL;

namespace NTIER.BLL
{
    public partial class UserBLL
    {

        public static UserEntity GetByUsername(string username)
        {
            using (UserDAL dal = new UserDAL(GetConnectionInfo()))
            {
                return dal.SelectByUsername(username);
            }
        }

        public static bool UserNameExist(string username, Guid id)
        {
            UserEntity user = GetByUsername(username);
            if (user != null)
            {
                if ((id == Guid.Empty) || (user.UserId != id))
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
        public static UserEntity GetById(Guid userId)
        {
            using (UserDAL dal = new UserDAL(GetConnectionInfo()))
            {
                return dal.SelectById(userId);
            }
        }

        /// <summary>
        /// Get record by userID.
        /// </summary>
        /// <param name="userTypeId"></param>
        /// <returns>Record of User.</returns>
        public static List<UserEntity> GetByUserTypeId(byte userTypeId)
        {
            using (UserDAL dal = new UserDAL(GetConnectionInfo()))
            {
                return dal.SelectByUserTypeId(userTypeId);
            }
        }


    }
}
