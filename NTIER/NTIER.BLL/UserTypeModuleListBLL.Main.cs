using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTIER.Common.Entity;
using NTIER.DAL;

namespace NTIER.BLL
{
    public partial class UserTypeModuleListBLL : BaseBusinessLogic
    {
        #region > Variables


        #endregion

        #region > Properties


        #endregion

        #region > Selects

        /// <summary>
        /// Retrieves all the record(s) from the table.
        /// </summary>
        /// <returns>Returns list of UserTypeModuleListEntity.</returns>
        public static IList<UserTypeModuleListEntity> GetAll()
        {
            List<UserTypeModuleListEntity> list = new List<UserTypeModuleListEntity>();

            using (UserTypeModuleListDAL dal =
                new UserTypeModuleListDAL(GetConnectionInfo().ConnectionString))
            {
                list.AddRange(dal.SelectAll());
            }

            return list;
        }


        /// <summary>
        /// Get record by userTypeModuleID.
        /// </summary>
        /// <param name="userTypeModuleID">Filter by userTypeModuleID.</param>
        /// <returns>Record(s) of UserTypeModuleList.</returns>
        public static UserTypeModuleListEntity GetByID(int userTypeModuleID)
        {
            using (UserTypeModuleListDAL dal = new UserTypeModuleListDAL(GetConnectionInfo()))
            {
                return dal.SelectByID(userTypeModuleID);
            }
        }


        /// <summary>
        /// Get record by moduleID.
        /// </summary>
        /// <param name="moduleID">Filter by moduleID.</param>
        /// <returns>Record(s) of UserTypeModuleList.</returns>
        public static IList<UserTypeModuleListEntity> GetByModuleID(short moduleID)
        {
            using (UserTypeModuleListDAL dal = new UserTypeModuleListDAL(GetConnectionInfo()))
            {
                return dal.SelectByModuleID(moduleID);
            }
        }


        /// <summary>
        /// Get record by userTypeID.
        /// </summary>
        /// <param name="userTypeID">Filter by userTypeID.</param>
        /// <returns>Record(s) of UserTypeModuleList.</returns>
        public static IList<UserTypeModuleListEntity> GetByUserTypeID(byte userTypeID)
        {
            using (UserTypeModuleListDAL dal = new UserTypeModuleListDAL(GetConnectionInfo()))
            {
                return dal.SelectByUserTypeID(userTypeID);
            }
        }


        #endregion

    }
}
