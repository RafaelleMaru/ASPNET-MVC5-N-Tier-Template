using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTIER.Common.Entity;
using Microsoft.ApplicationBlocks.Data;
using Rafaelle.Framework;

namespace NTIER.DAL
{
    public partial class UserDAL : BaseDataAccess
    {

        #region > Constants

        private const string _commandSelectAll = "UserSelectAll";

        private const string CommandSelectById = "UserSelectById";

        private const string _commandSearchPagedOrderBy = "UserSearchPagedOrderBy";

        private const string _commandSelectAllPagedOrderBy = "UserSelectAllPagedOrderBy";

        private const string _commandInsert = "UserInsert";

        private const string _commandUpdate = "UserUpdate";

        private const string _commandDelete = "UserDelete";

        #endregion

        #region > Enumerations

        /// <summary>
        /// Columns definition for Column. It can be use to reference the position or order of the column in the table.
        /// </summary>
        public enum Column
        {
            UserId,
            UserTypeId,
            Username,
            Password,
            Salt,
            SecurityStamp,
            Email,
            Firstname,
            Lastname,
            Middlename,
            Active,
            Created,
            CreatedBy,
            Updated,
            UpdatedBy,
            Timestamp
        }

        #endregion


        #region Constructors


        /// <summary>
        /// Initializes new instance of UserDAL using existing connectionString.
        /// </summary>
        /// <param name="connectionString">Connection string that will be used to connect to database.</param>
        public UserDAL(string connectionString)
            : base(connectionString)
        {

        }


        /// <summary>
        /// Initializes new instance of UserDAL using existing ConnectionStringSettings.
        /// </summary>
        /// <param name="connectionStringSettings">ConnectionStringSettings that will be used to connect to database.</param>
        public UserDAL(ConnectionStringSettings connectionStringSettings)
            : base(connectionStringSettings)
        {

        }

        /// <summary>
        /// Initializes new instance of UserDAL using existing transaction.
        /// </summary>
        /// <param name="transaction">Database transaction that will be used to connect to database.</param>
        public UserDAL(SqlTransaction transaction)
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
        public UserDAL(ConnectionStringSettings connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder)
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
        public UserDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder, string search)
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
        public UserDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder)
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


        private static UserEntity ProcessRow(IDataReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }

            byte[] timestamp = GetBinary(reader, (int)Column.Timestamp);

            return new UserEntity(
                reader.GetGuid((int)Column.UserId),
                reader.GetByte((int)Column.UserTypeId),
                reader.GetString((int)Column.Username),
                reader.GetString((int)Column.Password),
                reader.GetString((int)Column.Salt),
                reader.IsDBNull((int)Column.SecurityStamp) ? "" : reader.GetString((int)Column.SecurityStamp) ,
                reader.GetString((int)Column.Email),
                reader.GetString((int)Column.Firstname),
                reader.GetString((int)Column.Lastname),
                reader.GetString((int)Column.Middlename),
                reader.GetBoolean((int)Column.Active),
                reader.GetDateTime((int)Column.Created),
                reader.GetString((int)Column.CreatedBy),
                reader.GetDateTime((int)Column.Updated),
                reader.GetString((int)Column.UpdatedBy),
                timestamp);
        }


        private static List<UserEntity> Process(SqlDataReader reader)
        {
            List<UserEntity> list = new List<UserEntity>();
            UserEntity item = null;

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


        #region CRUD

        /// <summary>
        /// Insert the record into the database.
        /// </summary>
        /// <returns>ID of the newly created record.</returns>
        public Guid Insert(UserEntity data)
        {

            if (WithTransaction)
            {
                object retVal = SqlHelper.ExecuteScalar(
                    Transaction,
                    _commandInsert,
                    data.UserId,
                    data.UserTypeId,
                    data.Username,
                    data.Password,
                    data.Salt,
                    data.SecurityStamp,
                    data.Email,
                    data.Firstname,
                    data.Lastname,
                    data.Middlename,
                    data.Active,
                    data.CreatedBy,
                    data.UpdatedBy);

                data.UserId = new Guid(retVal.ToString());

                return data.UserId;

            }
            else
            {
                object retVal = SqlHelper.ExecuteScalar(
                    ConnectionString,
                    _commandInsert,
                    data.UserId,
                    data.UserTypeId,
                    data.Username,
                    data.Password,
                    data.Salt,
                    data.SecurityStamp,
                    data.Email,
                    data.Firstname,
                    data.Lastname,
                    data.Middlename,
                    data.Active,
                    data.CreatedBy,
                    data.UpdatedBy);

                data.UserId = new Guid(retVal.ToString());

                return data.UserId;

            }
        }


        /// <summary>
        /// Update a record in the database given the data and its id.
        /// </summary>
        /// <param name="data">Entity or record to update.</param>
        public void Update(UserEntity data)
        {

            if (WithTransaction)
            {
                SqlHelper.ExecuteNonQuery(
                    Transaction,
                    _commandUpdate,
                    data.UserId,
                    data.UserTypeId,
                    data.Username,
                    data.Password,
                    data.Salt,
                    data.SecurityStamp,
                    data.Email,
                    data.Firstname,
                    data.Lastname,
                    data.Middlename,
                    data.Active,
                    data.UpdatedBy,
                    data.Timestamp);

            }
            else
            {
                SqlHelper.ExecuteNonQuery(
                    ConnectionString,
                    _commandUpdate,
                    data.UserId,
                    data.UserTypeId,
                    data.Username,
                    data.Password,
                    data.Salt,
                    data.SecurityStamp,
                    data.Email,
                    data.Firstname,
                    data.Lastname,
                    data.Middlename,
                    data.Active,
                    data.UpdatedBy,
                    data.Timestamp);

            }
        }

        /// <summary>
        /// Delete a record in database using record id.
        /// </summary>
        /// <param name="id">Delete user by id</param>
        public void Delete(Guid id)
        {
            if(WithTransaction)
            {
                SqlHelper.ExecuteNonQuery(
                    Transaction,
                    _commandDelete,
                    id);
            }
            else
            {
                SqlHelper.ExecuteNonQuery(
                    ConnectionString,
                    _commandDelete,
                    id);
            }
        }

        #endregion


        #region > Paged Selects

        /// <summary>
        /// Retrieves all the record(s) in UserEntity Table.
        /// </summary>
        /// <returns>Returns array of UserEntity.</returns>
        public List<UserEntity> SelectAll()
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
        /// Select records, and table record count.
        /// </summary>
        /// <param name="column">Index column for sorting.</param>
        /// <returns>result in List/<UserEntity/> </returns>
        public List<UserEntity> SelectAllPagedOrderBy(Column column)
        {


            SqlParameter countSelectedParameter = new SqlParameter("@CountSelected", SqlDbType.Int);
            SqlParameter countParameter = new SqlParameter("@Count", SqlDbType.Int);


            countSelectedParameter.Direction = ParameterDirection.Output;
            countParameter.Direction = ParameterDirection.Output;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(conn,
                    CommandType.StoredProcedure,
                    _commandSelectAllPagedOrderBy,
                    new SqlParameter("@DisplayLength", PageSize),
                    new SqlParameter("@DisplayStart", StartIndex),
                    new SqlParameter("@SortCol", column),
                    new SqlParameter("@SortDir", SortOrder == SortOrderDirection.Ascending ? true : false),
                    countParameter,
                    countSelectedParameter))
                {

                    List<UserEntity> retVal = Process(reader);

                    reader.NextResult();
                    _count = Convert.ToInt32(countParameter.Value);
                    _countSelected = Convert.ToInt32(countSelectedParameter.Value);
                    return retVal;

                }



            }




        }



        /// <summary>
        /// Select records, and table record count.
        /// </summary>
        /// <param name="column">Index column for sorting.</param>
        /// <returns>result in List/<UserEntity/> </returns>
        public List<UserEntity> SearchAndOrderBy(Column column)
        {
            
            
            SqlParameter countSelectedParameter = new SqlParameter("@CountSelected", SqlDbType.Int);
            SqlParameter countParameter = new SqlParameter("@Count", SqlDbType.Int);


            countSelectedParameter.Direction = ParameterDirection.Output;
            countParameter.Direction = ParameterDirection.Output;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(conn,
                    CommandType.StoredProcedure,
                    _commandSearchPagedOrderBy,
                    new SqlParameter("@DisplayLength", PageSize),
                    new SqlParameter("@DisplayStart", StartIndex),
                    new SqlParameter("@SortCol", column),
                    new SqlParameter("@SortDir", SortOrder == SortOrderDirection.Ascending ? true : false),
                    new SqlParameter("@Search", string.IsNullOrEmpty(Search) ? null : Search),
                    countParameter,
                    countSelectedParameter))
                {
                    
                    List<UserEntity> retVal = Process(reader);

                    reader.NextResult();
                    _count = Convert.ToInt32(countParameter.Value);
                    _countSelected = Convert.ToInt32(countSelectedParameter.Value);
                    return retVal;

                }



            }




        }



        #endregion
    }
}
