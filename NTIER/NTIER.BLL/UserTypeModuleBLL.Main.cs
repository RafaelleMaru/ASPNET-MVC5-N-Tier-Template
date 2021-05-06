using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTIER.Common.Entity;
using NTIER.DAL;

namespace NTIER.BLL
{
    public partial class UserTypeModuleBLL :BaseBusinessLogic
    {

        #region > Variables


        #endregion

        #region > Properties


        #endregion

        #region > Selects

        ///// <summary>
        ///// Retrieves all the record(s) from the table.
        ///// </summary>
        ///// <returns>Returns list of UserTypeModuleEntity.</returns>
        //public static IList<UserTypeModuleEntity> GetAll()
        //{
        //    List<UserTypeModuleEntity> list = new List<UserTypeModuleEntity>();

        //    using (UserTypeModuleDAL dal =
        //        new UserTypeModuleDAL(GetConnectionInfo().ConnectionString))
        //    {
        //        list.AddRange(dal.SelectAll());
        //    }

        //    return list;
        //}


        /// <summary>
        /// Get record by userTypeModuleId.
        /// </summary>
        /// <param name="userTypeModuleId">Filter by userTypeModuleId.</param>
        /// <returns>Record(s) of UserTypeModuleList.</returns>
        //public static UserTypeModuleEntity GetById(int userTypeModuleId)
        //{
        //    using (UserTypeModuleDAL dal = new UserTypeModuleDAL(GetConnectionInfo()))
        //    {
        //        return dal.SelectById(userTypeModuleId);
        //    }
        //}


        /// <summary>
        /// Get record by moduleId.
        /// </summary>
        /// <param name="moduleId">Filter by moduleId.</param>
        /// <returns>Record(s) of UserTypeModuleList.</returns>
        //public static IList<UserTypeModuleEntity> GetByModuleId(short moduleId)
        //{
        //    using (UserTypeModuleDAL dal = new UserTypeModuleDAL(GetConnectionInfo()))
        //    {
        //        return dal.SelectByModuleId(moduleId);
        //    }
        //}


        

        #endregion

    }
}
