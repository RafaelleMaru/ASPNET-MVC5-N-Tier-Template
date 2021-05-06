using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using NTIER.Common.Entity;
using Rafaelle.Framework;

namespace NTIER.DAL
{
    public partial class UserTypeModuleListDAL : BaseDataAccess
    {


        #region > Constants


        private const string _commandSelectAll = "UserTypeModuleListSelectAll";
        private const string _commandSelectById = "UserTypeModuleListSelectById";
        private const string _commandSelectByModuleId = "UserTypeModuleListSelectByModuleId";
        private const string _commandSelectByUserTypeId = "UserTypeModuleListSelectByUserTypeId";
        #endregion

        #region > Enumerations

        /// <summary>
        /// Columns definition for Column. It can be use to reference the position or order of the column in the table.
        /// </summary>
        public enum Column
        {
            UserTypeModuleId,
            ModuleId,
            UserTypeId,
            ModuleName,
            Permission,
            ValidPermission
        }

        #endregion

        #region > Constructors

        /// <summary>
        /// Initializes new instance of UserTypeModuleListDAL using existing connectionString.
        /// </summary>
        /// <param name="connectionString">Connection string that will be use to connect to database.</param>
        public UserTypeModuleListDAL(string connectionString)
             : base(connectionString)
        {

        }

        /// <summary>
        /// Initializes new instance of UserTypeModuleListDAL using existing ConnectionStringSettings.
        /// </summary>
        /// <param name="connectionStringSettings">ConnectionStringSettings that will be use to connect to database.</param>
        public UserTypeModuleListDAL(ConnectionStringSettings connectionStringSettings)
             : base(connectionStringSettings)
        {

        }

        /// <summary>
        /// Initializes new instance of UserTypeModuleListDAL using existing transaction.
        /// </summary>
        /// <param name="transaction">Database transaction that will be use to connect to database.</param>
        public UserTypeModuleListDAL(SqlTransaction transaction)
             : base(transaction)
        {

        }

        /// <summary>
        /// Initializes new instance of UserTypeModuleListDAL using connection string and parameters needed in paging.
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="endIndex">Index of the record where the page will end. This is in base one.</param>
        /// <param name="sortOrderDirection">Direction of ordering whether ascending or descending.</param>
        public UserTypeModuleListDAL(string connectionStringSettings, int startIndex, int endIndex, SortOrderDirection sortOrder)
             : base(connectionStringSettings, startIndex, endIndex, sortOrder)
        {

        }

        #endregion



        #region > Overrides

        protected override string TableName
        {
            get { return "UserTypeModuleList"; }
        }

        #endregion


        #region > Static Methods

        private static UserTypeModuleListEntity ProcessRow(IDataReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }



            return new UserTypeModuleListEntity(
                reader.GetInt32((int)Column.UserTypeModuleId),
                reader.GetInt16((int)Column.ModuleId),
                reader.GetByte((int)Column.UserTypeId),
                reader.GetString((int)Column.ModuleName),
                reader.GetInt64((int)Column.Permission),
                reader.GetInt64((int)Column.ValidPermission));
        }

        private static UserTypeModuleListEntity[] Process(SqlDataReader reader)
        {
            ArrayList list = new ArrayList();
            UserTypeModuleListEntity item = null;

            while (true)
            {
                item = ProcessRow(reader);

                if (item == null)
                {
                    break;
                }

                list.Add(item);
            }

            return (UserTypeModuleListEntity[])list.ToArray(typeof(UserTypeModuleListEntity));
        }


        #endregion



        #region > Selects

        /// <summary>
        /// Retrieves all the record(s) in UserTypeModuleListEntity Table.
        /// </summary>
        /// <returns>Returns array of UserTypeModuleListEntity.</returns>
        public UserTypeModuleListEntity[] SelectAll()
        {

            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    _commandSelectAll))
                {
                    return Process(reader);
                }

            }
            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    _commandSelectAll))
                {
                    return Process(reader);
                }

            }
        }

        /// <summary>
        /// Select record by UserTypeModuleID.
        /// </summary>
        /// <param name="userTypeModuleID">ID of the record to retrieve.</param>
        /// <returns>Returns UserTypeModuleListEntity object.</returns>
        public UserTypeModuleListEntity SelectByID(int userTypeModuleID)
        {

            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    _commandSelectById,
                    userTypeModuleID))
                {
                    return ProcessRow(reader);
                }

            }
            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    _commandSelectById,
                    userTypeModuleID))
                {
                    return ProcessRow(reader);
                }

            }
        }

        /// <summary>
        /// Select record by ModuleID.
        /// </summary>
        /// <param name="moduleID">ID of the record to retrieve.</param>
        /// <returns>Returns array of UserTypeModuleListEntity.</returns>
        public UserTypeModuleListEntity[] SelectByModuleID(short moduleID)
        {

            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    _commandSelectByModuleId,
                    moduleID))
                {
                    return Process(reader);
                }

            }
            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    _commandSelectByModuleId,
                    moduleID))
                {
                    return Process(reader);
                }

            }
        }

        /// <summary>
        /// Select record by UserTypeID.
        /// </summary>
        /// <param name="userTypeID">ID of the record to retrieve.</param>
        /// <returns>Returns array of UserTypeModuleListEntity.</returns>
        public UserTypeModuleListEntity[] SelectByUserTypeID(byte userTypeID)
        {

            if (WithTransaction)
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    Transaction,
                    _commandSelectByUserTypeId,
                    userTypeID))
                {
                    return Process(reader);
                }

            }
            else
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(
                    ConnectionString,
                    _commandSelectByUserTypeId,
                    userTypeID))
                {
                    return Process(reader);
                }

            }
        }


        #endregion

    }
}
