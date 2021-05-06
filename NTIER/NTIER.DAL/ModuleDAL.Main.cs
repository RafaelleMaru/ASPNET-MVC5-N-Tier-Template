using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using NTIER.Common.Entity;
using Rafaelle.Framework;

namespace NTIER.DAL
{
    public partial class ModuleDAL : BaseDataAccess
    {

        #region > Constants

        public const string _commandSelectAll = "ModuleSelectAll";


        #endregion



        #region > Enumerations

        /// <summary>
        /// Columns definition for Column. It can be use to reference the position or order of the column in the table.
        /// </summary>
        public enum Column
        {
             ModuleId,
             ModuleName,
             ValidPermission
        }

        #endregion

        /// <summary>
        /// Initializes new instance of ModulelDAL using existing connectionString.
        /// </summary>
        /// <param name="connectionString">Connection string that will be used to connect to database.</param>
        public ModuleDAL(string connectionString)
            : base(connectionString)
        {

        }


        /// <summary>
        /// Initializes new instance of ModulelDAL using existing ConnectionStringSettings.
        /// </summary>
        /// <param name="connectionStringSettings">ConnectionStringSettings that will be used to connect to database.</param>
        public ModuleDAL(ConnectionStringSettings connectionStringSettings)
            : base(connectionStringSettings)
        {

        }

        /// <summary>
        /// Initializes new instance of ModulelDAL using existing transaction.
        /// </summary>
        /// <param name="transaction">Database transaction that will be used to connect to database.</param>
        public ModuleDAL(SqlTransaction transaction)
            : base(transaction)
        {

        }

        /// <summary>
        /// Initializes new instance of ModulelDAL using connection string and parameters needed in paging.
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        public ModuleDAL(ConnectionStringSettings connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder)
        {

        }


        /// <summary>
        /// Initializes new instance of ModulelDAL using connection string and parameters needed in paging.
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        /// <param name="search">Keyword for search.</param>
        public ModuleDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder, string search)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder, search)
        {

        }

        /// <summary>
        /// Initializes new instance of ModulelDAL using connection string and parameters needed in paging.
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        public ModuleDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder)
        {

        }

        protected override string TableName
        {
            get { return "Module"; }
        }


        #region Static Methods


        private static ModuleEntity ProcessRow(IDataReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }

           
            return new ModuleEntity(
                reader.GetInt16((int)Column.ModuleId),
                reader.GetString((int)Column.ModuleName),
                reader.GetInt64((int)Column.ValidPermission));
        }


        private static List<ModuleEntity> Process(SqlDataReader reader)
        {
            List<ModuleEntity> list = new List<ModuleEntity>();
            ModuleEntity item = null;

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


        #region > Paged Selects

        /// <summary>
        /// Retrieves all the record(s) in UserEntity Table.
        /// </summary>
        /// <returns>Returns array of UserEntity.</returns>
        public List<ModuleEntity> SelectAll()
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

        #endregion

    }
}
