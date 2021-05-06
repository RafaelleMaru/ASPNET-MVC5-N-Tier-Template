using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using NTIER.Common.Entity;
using Rafaelle.Framework;

namespace NTIER.DAL
{
    public partial class UserTypeModuleDAL : BaseDataAccess
    {



        #region > Constants

        private const string _commandSelectAll = "UserTypeModuleSelectAll";

        private const string _commandInsert = "UserTypeModuleInsert";

        private const string _commandUpdate = "UserTypeModuleUpdate";

        private const string _commandDelete = "UserTypeModuleDelete";


        #endregion


        #region > Enumerations

        public enum Column
        {
            UserTypeModuleId,
            UserTypeId,
            ModuleId,
            Permission,
            Created,
            CreatedBy,
            Updated,
            UpdatedBy

        }

        #endregion

        #region > Constructor

        /// <summary>
        /// Initializes new instance of UserTypeDAL using existing connectionString.
        /// </summary>
        /// <param name="connectionString">Connection string that will be used to connect to database.</param>
        public UserTypeModuleDAL(string connectionString)
            : base(connectionString)
        {

        }

        /// <summary>
        /// Initializes a new instance of UserTypeDAL using existing ConnectionStringSettings
        /// </summary>
        /// <param name="connectionStringSettings">ConnectionStringSettings that will be used to connect to database.</param>
        public UserTypeModuleDAL(ConnectionStringSettings connectionStringSettings)
            : base(connectionStringSettings)
        {

        }

        /// <summary>
        /// Initializes new instance of UserDAL using existing transaction.
        /// </summary>
        /// <param name="transaction">Database transaction that will be used to connect to database.</param>
        public UserTypeModuleDAL(SqlTransaction transaction)
            : base(transaction)
        {

        }

        /// <summary>
        /// Initializes new instance of UserTypeDAL using conneciton string and parameters needed in paging. 
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        public UserTypeModuleDAL(ConnectionStringSettings connectionStringSettings, int startIndex, int pageSize,
            SortOrderDirection sortOrder)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder)
        {

        }


        /// <summary>
        /// Initializes new instance of UserTypeDAL using conneciton string and parameters needed in paging. 
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        /// <param name="search">Keyword for search.</param>
        public UserTypeModuleDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder,
            string search)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder, search)
        {

        }

        /// <summary>
        /// Initializes new instance of UserTypeDAL using conneciton string and parameters needed in paging. 
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        public UserTypeModuleDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder)
        {

        }


        #endregion




        #region > Overrides

        protected override string TableName
        {
            get { return "UserTypeModule"; }
        }

        #endregion



        #region > Static Methods

        private static UserTypeModuleEntity ProcessRow(IDataReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }

            return new UserTypeModuleEntity(
                reader.GetInt32((int)Column.UserTypeModuleId),
                reader.GetByte((int)Column.UserTypeId),
                reader.GetInt16((int)Column.ModuleId),
                reader.GetInt64((int)Column.Permission),
                reader.GetDateTime((int)Column.Created),
                reader.GetString((int)Column.CreatedBy),
                reader.GetDateTime((int)Column.Updated),
                reader.GetString((int)Column.UpdatedBy)
                );
        }


        private static List<UserTypeModuleEntity> Process(SqlDataReader reader)
        {
            List<UserTypeModuleEntity> list = new List<UserTypeModuleEntity>();
            UserTypeModuleEntity item = null;

            while (true)
            {
                item = ProcessRow(reader);

                if (item == null)
                {
                    break;
                }

                list.Add(item);
            }

            return list;
        }


        #endregion


        #region > CRUD

        /// <summary>
        /// Insert the record into the database.
        /// </summary>
        /// <returns>ID of the newly created record.</returns>
        public int Insert(UserTypeModuleEntity data)
        {

            if (WithTransaction)
            {
                object retVal = SqlHelper.ExecuteScalar(
                    Transaction,
                    _commandInsert,
                    data.UserTypeId,
                    data.ModuleId,
                    data.Permission,
                    data.CreatedBy,
                    data.UpdatedBy);

                data.UserTypeModuleId = Convert.ToByte(retVal);

                return data.UserTypeModuleId;

            }
            else
            {
                object retVal = SqlHelper.ExecuteScalar(
                    ConnectionString,
                    _commandInsert,
                    data.UserTypeId,
                    data.ModuleId,
                    data.Permission,
                    data.CreatedBy,
                    data.UpdatedBy);

                data.UserTypeModuleId = Convert.ToByte(retVal);

                return data.UserTypeModuleId;

            }
        }


        /// <summary>
        /// Update a record in the database given the data and its id.
        /// </summary>
        /// <param name="data">Entity or record to update.</param>
        public void Update(UserTypeModuleEntity data)
        {

            if (WithTransaction)
            {
                SqlHelper.ExecuteNonQuery(
                    Transaction,
                    _commandUpdate,
                    data.UserTypeModuleId,
                    data.UserTypeId,
                    data.ModuleId,
                    data.Permission,
                    data.Updated);

            }
            else
            {
                SqlHelper.ExecuteNonQuery(
                    ConnectionString,
                    _commandUpdate,
                    data.UserTypeModuleId,
                    data.UserTypeId,
                    data.ModuleId,
                    data.Permission,
                    data.Updated);

            }
        }

        #endregion

    }
}
