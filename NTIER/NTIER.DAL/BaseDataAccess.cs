using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NTIER.Common;
using Rafaelle.Framework;


namespace NTIER.DAL
{
    public abstract class BaseDataAccess : IDisposable
    {
        private const string DEFAULT_CONNECTION_NAME =
            "Default";


        #region DataTablesFields

        //Get parameters
        // get Start (paging start index) and length (page size for paging)
        private int _pageSize;
        private int _startIndex;

        //Get Sort columns value
        private SortOrderDirection _sortOrder;
        private string _search;
        

        private SqlTransaction _transaction;
        private SqlConnection _connection;
        private bool _autoCommit = true;
        private bool _withTransaction = false;
        private bool _isCommitted = false;
        private bool _isRolledBack = false;

        protected int _countSelected;
        protected int _count;
        #endregion


        private readonly ConnectionStringSettings _connectionString;


        //protected BaseDataAccess(string connectionString)
        //{
        //    _connectionString = new ConnectionStringSettings(
        //        DEFAULT_CONNECTION_NAME,
        //        connectionString);

        //    _startIndex = 0;
        //    _pageSize = 10;
        //    _sortOrder = SortOrderDirection.Ascending;
        //}

        protected BaseDataAccess(string connectionString)
        {
            _connectionString = new ConnectionStringSettings(
                DEFAULT_CONNECTION_NAME,
                connectionString);

            _startIndex = 0;
            //_endIndex = 0;
            _sortOrder = SortOrderDirection.Ascending;
        }

        protected BaseDataAccess(ConnectionStringSettings connectionString)
            : this(connectionString, 0, 0, SortOrderDirection.Ascending)
        {
            _connectionString = connectionString;
        }

        protected BaseDataAccess(ConnectionStringSettings connectionString,
            int startIndex,
            int pageSize,
            SortOrderDirection sortOrder)
        {
            _connectionString = connectionString;
            _startIndex = startIndex;
            _pageSize = pageSize;
            _sortOrder = sortOrder;
        }
        protected BaseDataAccess(string connectionString,
            int startIndex,
            int pageSize,
            SortOrderDirection sortOrder)
            : this(connectionString)
        {
            _startIndex = startIndex;
            _pageSize = pageSize;
            _sortOrder = sortOrder;
        }


        protected BaseDataAccess(string connectionString,
            int startIndex,
            int pageSize,
            SortOrderDirection sortOrder,
            string search)
            : this(connectionString)
        {
            _startIndex = startIndex;
            _pageSize = pageSize;
            _sortOrder = sortOrder;
            _search = search;
        }


        protected BaseDataAccess(SqlTransaction transaction)
        {
            _transaction = transaction ?? throw new Exception("Transaction must not be null.");
            _withTransaction = true;
            _autoCommit = false;  //-- do not flush transaction in Dispose
        }


        protected ConnectionStringSettings ConnectionStringSettings
        {
            get
            {
                return _connectionString;
            }
        }

        protected string ConnectionString
        {
            get
            {
                return _connectionString.ConnectionString;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = value;
            }
        }
        

        public int StartIndex
        {
            get
            {
                return _startIndex;
            }

            set
            {
                _startIndex = value;
            }
        }

        protected SortOrderDirection SortOrder
        {
            get
            {
                return _sortOrder;
            }

            set
            {
                _sortOrder = value;
            }
        }
        public string Search
        {
            get
            {
                return _search;
            }

            set
            {
                _search = value;
            }
        }
        

        public int CountSelected
        {
            get
            {
                return _countSelected;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public virtual bool IsPaged
        {
            get
            {
                return (_startIndex > 0);
            }
        }

        public DataSet ExecuteDataSet(
            SqlCommand command,
            string tableName)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                command.Connection = conn;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet retVal = new DataSet();

                conn.Open();

                if (IsPaged)
                {
                    adapter.Fill(retVal,
                        StartIndex - 1, //base zero start index. Since our start index is base one we need to subract 1
                        PageSize, // numbers of records
                        tableName);
                }

                else
                {
                    adapter.Fill(retVal, tableName);
                }

                adapter.Dispose();
                command.Dispose();
                conn.Close();

                return retVal;
            }
        }






        protected static byte[] GetBinary(IDataReader reader, int index)
        {
            if (reader.IsDBNull(index))
                return null;

            long length = reader.GetBytes(index,
                0,
                null,
                0,
                0);
            byte[] buffer = new byte[length];

            reader.GetBytes(index,
                0,
                buffer,
                0,
                (int)length);

            return buffer;
        }



        #region Dynamic Columns

        protected virtual string TableName
        {
            get { return String.Empty; }
        }

        #endregion


        #region > Transaction Management


        #region > Properties

            public SqlTransaction Transaction
            {
                get
                {
                    return _transaction;
                }
            }

            /// <summary>
            /// Check if the data access is using transaction
            /// </summary>
            public bool WithTransaction
            {
                get
                {
                    return _withTransaction;
                }
            }


        #endregion



        #region > Methods

        public void BeginTransaction()
        {
            InitializeTransaction();
        }


        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            InitializeTransaction(isolationLevel);
        }
        protected void InitializeTransaction()
        {
            //-- allow not to reinitalize transaction that already exist
            if (_transaction == null)
            {
                if (_connection == null ||
                    _connection.State == ConnectionState.Closed)
                {
                    _connection = new SqlConnection(ConnectionString);
                    _connection.Open();
                }

                _transaction = _connection.BeginTransaction();
                _withTransaction = true;
            }
        }


        protected void InitializeTransaction(IsolationLevel isolationLevel)
        {
            //-- allow not to reinitalize transaction that already exist
            if (_transaction == null)
            {
                if (_connection == null ||
                    _connection.State == ConnectionState.Closed)
                {
                    _connection = new SqlConnection(ConnectionString);
                    _connection.Open();
                }

                _transaction = _connection.BeginTransaction(isolationLevel);
                _withTransaction = true;
            }
        }

        public virtual void CommitTransaction()
        {
            if (_withTransaction &&
                _transaction != null &&
                !_isCommitted &&
                !_isRolledBack)
            {
                _transaction.Commit();
                _isCommitted = true;
            }
        }

        public virtual void RollBackTransaction()
        {
            if (_withTransaction &&
                _transaction != null &&
                !_isCommitted &&
                !_isRolledBack)
            {
                _transaction.Rollback();
                _isRolledBack = true;
            }
        }

        #endregion



        #endregion


        public void Dispose()
        {
            if (_transaction != null && _autoCommit)
            {
                //auto commit
                CommitTransaction();
                _transaction.Dispose();
            }

            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

                _connection.Dispose();
            }
        }
    }

    
}
