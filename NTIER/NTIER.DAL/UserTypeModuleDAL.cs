using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using NTIER.Common.Entity;

namespace NTIER.DAL
{
    public partial class UserTypeModuleDAL
    {
        #region > Constants

        private const string _commandSelectByUserTypeId = "UserTypeModuleSelectByUserTypeId";
        private const string _commandUserTypeModuleSelectByUserTypeIdAndModuleId = "UserTypeModuleSelectByUserTypeIdAndModuleId";

        #endregion



        /// <summary>
        /// Select record by UserTypeId.
        /// </summary>
        /// <param name="userTypeId">UserTypeId of the record to retrieve.</param>
        /// <returns>Returns UserTypeModuleEntity object.</returns>
        public List<UserTypeModuleEntity> SelectByUserTypeId(byte userTypeId)
        {

            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    _commandSelectByUserTypeId,
                    userTypeId))
                {
                    return Process(reader);
                }

            }
            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    _commandSelectByUserTypeId,
                    userTypeId))
                {
                    return Process(reader);
                }

            }
        }



       /// <summary>
       /// Select record by UserTypeId and ModuleId
       /// </summary>
       /// <param name="userTypeId"></param>
       /// <param name="moduleId"></param>
       /// <returns></returns>
        public List<UserTypeModuleEntity> SelectByUserTypeIdAndModuleid(byte userTypeId, short moduleId)
        {

            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    _commandUserTypeModuleSelectByUserTypeIdAndModuleId,
                    userTypeId, moduleId))
                {
                    return Process(reader);
                }

            }
            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    _commandUserTypeModuleSelectByUserTypeIdAndModuleId,
                    userTypeId, moduleId))
                {
                    return Process(reader);
                }

            }
        }
    }
}
