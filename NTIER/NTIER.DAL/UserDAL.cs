using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using NTIER.Common.Entity;

namespace NTIER.DAL
{
    public partial class UserDAL
    {

        private const string CommandUserSelectByUsername = "UserSelectByUsername";
        
        private const string CommandSelectByUserTypeId = "UserSelectByUserTypeId";


        public UserEntity SelectByUsername(string username)
        {
            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    CommandUserSelectByUsername,
                    username))
                {
                    return ProcessRow(reader);
                }

            }

            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    CommandUserSelectByUsername,
                    username))
                {
                    return ProcessRow(reader);
                }

            }
        }

        /// <summary>
        /// Select record by UserID.
        /// </summary>
        /// <param name="userId">ID of the record to retrieve.</param>
        /// <returns>Returns UserEntity object.</returns>
        public UserEntity SelectById(Guid userId)
        {

            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    CommandSelectById,
                    userId))
                {
                    return ProcessRow(reader);
                }

            }
            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    CommandSelectById,
                    userId))
                {
                    return ProcessRow(reader);
                }

            }
        }

        /// <summary>
        /// Select by UserType
        /// </summary>
        /// <param name="userTypeId">UserTypeId</param>
        /// <returns></returns>
        public List<UserEntity> SelectByUserTypeId(byte userTypeId)
        {

            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    CommandSelectByUserTypeId,
                    userTypeId))
                {
                    return Process(reader);
                }

            }
            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    CommandSelectByUserTypeId,
                    userTypeId))
                {
                    return Process(reader);
                }

            }
        }

    }
}
