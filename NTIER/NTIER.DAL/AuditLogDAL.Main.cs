using System;
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
    public partial class AuditLogDAL : BaseDataAccess
    {

        #region > Constants



        private const string _commandInsert = "AuditLogInsert";


        #endregion



        #region Enumerations

        /// <summary>
        /// Columns definition for Column. It can be use to reference the position or order of the column in the table.
        /// </summary>
        public enum Column
        {
            AuditLogId,
            UserId,
            IPAddress,
            ObjectSourceType,
            ObjectSourceId,
            Action,
            Created,
            CreatedBy
        }

        #endregion



        #region Constructors


        /// <summary>
        /// Initializes new instance of UserDAL using existing connectionString.
        /// </summary>
        /// <param name="connectionString">Connection string that will be used to connect to database.</param>
        public AuditLogDAL(string connectionString)
            : base(connectionString)
        {

        }


        /// <summary>
        /// Initializes new instance of UserDAL using existing ConnectionStringSettings.
        /// </summary>
        /// <param name="connectionStringSettings">ConnectionStringSettings that will be used to connect to database.</param>
        public AuditLogDAL(ConnectionStringSettings connectionStringSettings)
            : base(connectionStringSettings)
        {

        }

        /// <summary>
        /// Initializes new instance of UserDAL using existing transaction.
        /// </summary>
        /// <param name="transaction">Database transaction that will be used to connect to database.</param>
        public AuditLogDAL(SqlTransaction transaction)
            : base(transaction)
        {

        }

        /// <summary>
        /// Initializes new instance of UserDAL using connection string and parameters needed in paging.
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        public AuditLogDAL(ConnectionStringSettings connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder)
        {

        }


        /// <summary>
        /// Initializes new instance of UserDAL using connection string and parameters needed in paging.
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        /// <param name="search">Keyword for search.</param>
        public AuditLogDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder, string search)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder, search)
        {

        }

        /// <summary>
        /// Initializes new instance of UserDAL using connection string and parameters needed in paging.
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        public AuditLogDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder)
        {

        }


        #endregion


        #region > Overrides

        protected override string TableName
        {
            get { return "User"; }
        }

        #endregion


        #region Static Methods


        private static AuditLogEntity ProcessRow(IDataReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }

            
            return new AuditLogEntity(
                reader.GetInt32((int)Column.AuditLogId),
                reader.GetGuid((int)Column.UserId),
                reader.GetString((int)Column.IPAddress),
                reader.GetByte((int)Column.ObjectSourceType),
                reader.GetString((int)Column.ObjectSourceId),
                reader.GetByte((int)Column.Action),
                reader.GetDateTime((int)Column.Created),
                reader.GetString((int)Column.CreatedBy));
        }


        private static List<AuditLogEntity> Process(SqlDataReader reader)
        {
            List<AuditLogEntity> list = new List<AuditLogEntity>();
            AuditLogEntity item = null;

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



        #region CRUD


        /// <summary>
        /// Insert the record into the database.
        /// </summary>
        /// <returns>ID of the newly created record.</returns>
        public Guid Insert(AuditLogEntity data)
        {

            if (WithTransaction)
            {
                object retVal = SqlHelper.ExecuteScalar(
                    Transaction,
                    _commandInsert,
                    data.UserId,
                    data.IPAddress,
                    data.ObjectSourceType,
                    data.ObjectSourceId,
                    data.Action,
                    data.CreatedBy);

                data.AuditLogId = Convert.ToInt64(retVal);

                return data.UserId;

            }
            else
            {
                object retVal = SqlHelper.ExecuteScalar(
                    ConnectionString,
                    _commandInsert,
                    data.UserId,
                    data.IPAddress,
                    data.ObjectSourceType,
                    data.ObjectSourceId,
                    data.Action,
                    data.CreatedBy);

                data.AuditLogId = Convert.ToInt64(retVal);

                return data.UserId;

            }
        }



        #endregion



        #endregion

    }
}
