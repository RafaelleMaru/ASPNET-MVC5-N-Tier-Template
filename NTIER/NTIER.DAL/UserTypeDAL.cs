using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using NTIER.Common.Entity;

namespace NTIER.DAL
{
    public partial class UserTypeDAL
    {

        public const string CommandUserTypeSelectByUserTypeName= "UserTypeSelectByUserTypeName";
        public UserTypeEntity SelectByUserTypeName(string username)
        {
            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    CommandUserTypeSelectByUserTypeName,
                    username))
                {
                    return ProcessRow(reader);
                }

            }

            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    CommandUserTypeSelectByUserTypeName,
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
        public UserTypeEntity SelectById(byte userTypeId)
        {

            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    _commandSelectById,
                    userTypeId))
                {
                    return ProcessRow(reader);
                }

            }
            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    _commandSelectById,
                    userTypeId))
                {
                    return ProcessRow(reader);
                }

            }
        }

    }
}
