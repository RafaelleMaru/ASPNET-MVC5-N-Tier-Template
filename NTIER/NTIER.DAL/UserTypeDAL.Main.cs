using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using NTIER.Common.Entity;
using Rafaelle.Framework;

namespace NTIER.DAL
{
    public partial class UserTypeDAL : BaseDataAccess
    {
        #region > Constants

        private const string _commandSelectAll = "UserTypeSelectAll";

        private const string _commandSelectById = "UserTypeSelectById";

        private const string _commandSearchPagedOrderBy = "UserTypeSearchPagedOrderBy";

        private const string _commandSelectAllPagedOrderBy = "UserTypeSelectAllPagedOrderBy";


        private const string _commandInsert = "UserTypeInsert";

        private const string _commandUpdate = "UserTypeUpdate";

        private const string _commandDelete = "UserTypeDelete";


        #endregion


        #region > Enumerations

        public enum Column
        {
            UserTypeId,
            UserTypeName

        }

        #endregion


        #region > Constructor

        /// <summary>
        /// Initializes new instance of UserTypeDAL using existing connectionString.
        /// </summary>
        /// <param name="connectionString">Connection string that will be used to connect to database.</param>
        public UserTypeDAL(string connectionString)
            : base(connectionString)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of UserTypeDAL using existing ConnectionStringSettings
        /// </summary>
        /// <param name="connectionStringSettings">ConnectionStringSettings that will be used to connect to database.</param>
        public UserTypeDAL(ConnectionStringSettings connectionStringSettings)
            : base(connectionStringSettings)
        {
            
        }

        /// <summary>
        /// Initializes new instance of UserDAL using existing transaction.
        /// </summary>
        /// <param name="transaction">Database transaction that will be used to connect to database.</param>
        public UserTypeDAL(SqlTransaction transaction) 
            :base(transaction)
        {
            
        }

        /// <summary>
        /// Initializes new instance of UserTypeDAL using conneciton string and parameters needed in paging. 
        /// </summary>
        /// <param name="connectionStringSettings">Connection string to connect to data source.</param>
        /// <param name="startIndex">Index of the record where the page will start in base one.</param>
        /// <param name="pageSize">Number of records to show that will show in list. This is in base one.</param>
        /// <param name="sortOrder">Direction of ordering whether ascending or descending.</param>
        public UserTypeDAL(ConnectionStringSettings connectionStringSettings, int startIndex, int pageSize,
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
        public UserTypeDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder,
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
        public UserTypeDAL(string connectionStringSettings, int startIndex, int pageSize, SortOrderDirection sortOrder)
            : base(connectionStringSettings, startIndex, pageSize, sortOrder)
        {

        }


        #endregion



        #region > Overrides

        protected override string TableName
        {
            get { return "UserType"; }
        }

        #endregion

        #region > Static Methods

        private static UserTypeEntity ProcessRow(IDataReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }
            
            return new UserTypeEntity(
                reader.GetByte((int)Column.UserTypeId),
                reader.GetString((int)Column.UserTypeName));
        }


        private static List<UserTypeEntity> Process(SqlDataReader reader)
        {
            List<UserTypeEntity> list = new List<UserTypeEntity>();
            UserTypeEntity item = null;

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
        public byte Insert(UserTypeEntity data)
        {

            if (WithTransaction)
            {
                object retVal = SqlHelper.ExecuteScalar(
                    Transaction,
                    _commandInsert,
                    data.UserTypeName);

                data.UserTypeId = Convert.ToByte(retVal);

                return data.UserTypeId;

            }
            else
            {
                object retVal = SqlHelper.ExecuteScalar(
                    ConnectionString,
                    _commandInsert,
                    data.UserTypeName);

                data.UserTypeId = Convert.ToByte(retVal);

                return data.UserTypeId;

            }
        }


        /// <summary>
        /// Update a record in the database given the data and its id.
        /// </summary>
        /// <param name="data">Entity or record to update.</param>
        public void Update(UserTypeEntity data)
        {

            if (WithTransaction)
            {
                SqlHelper.ExecuteNonQuery(
                    Transaction,
                    _commandUpdate,
                    data.UserTypeId,
                    data.UserTypeName);

            }
            else
            {
                SqlHelper.ExecuteNonQuery(
                    ConnectionString,
                    _commandUpdate,
                    data.UserTypeId,
                    data.UserTypeName);

            }
        }

        /// <summary>
        /// Delete a record in database using record id.
        /// </summary>
        /// <param name="id">Delete user by id</param>
        public void Delete(byte id)
        {
            if (WithTransaction)
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




        #region > Page Selects



        /// <summary>
        /// Retrieves all the record(s) in UserEntity Table.
        /// </summary>
        /// <returns>Returns array of UserEntity.</returns>
        public List<UserTypeEntity> SelectAll()
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
        public List<UserTypeEntity> SelectAllPagedOrderBy(Column column)
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

                    List<UserTypeEntity> retVal = Process(reader);

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
        public List<UserTypeEntity> SearchAndOrderBy(Column column)
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

                    List<UserTypeEntity> retVal = Process(reader);

                    reader.NextResult();
                    _count = Convert.ToInt32(countParameter.Value);
                    _countSelected = Convert.ToInt32(countSelectedParameter.Value);
                    return retVal;

                }



            }




        }



        #endregion











        #endregion




    }
}
