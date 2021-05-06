using System;
using System.Configuration;
using System.Data.SqlClient;
using NTIER.Common;
using NTIER.Common.Entity;
using NTIER.DAL;
using Rafaelle.Framework;

namespace NTIER.BLL
{
    public abstract class BaseBusinessLogic
    {
        protected static ErrorMessageCollection _errors = new ErrorMessageCollection();

        protected static ConnectionStringSettings GetConnectionInfo()
        {
            ConnectionStringSettings connectionInfo =
                ConfigurationManager.ConnectionStrings["Default" + Environment.MachineName];

            if (connectionInfo == null)
            {
                connectionInfo = ConfigurationManager.ConnectionStrings["Default"];
            }

            if (connectionInfo == null)
            {
                throw new ApplicationException(
                    "Please indicate default connection string in the application configuration file.");
            }

            return connectionInfo;
        }

        public static bool IsEditMode(object value)
        {
            if (value is Int32 || value is Int16 || value is byte || value is Int64)
            {
                return Convert.ToInt64(value) > 0;
            }

            else if (value is Guid)
            {
                return new Guid(value.ToString()).CompareTo(Guid.Empty) != 0;
            }

            return value != null;
        }

        public ErrorMessageCollection Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
            }
        }



        protected static void AuditLog(SqlTransaction transaction,
            Rafaelle.Framework.Action action,
            string data,
            string id,
            Guid currentUserId,
            string currentUser,
            EnumObjectSource objectSourceType,
            string machineName)
        {
            AuditLogEntity entity = new AuditLogEntity();
            entity.UserId = currentUserId;
            entity.ObjectSourceId = id;
            entity.ObjectSourceType = (byte)objectSourceType;
            entity.Action = Convert.ToByte(action);
            entity.CreatedBy = currentUser;
            entity.ObjectSourceId = id;
            entity.IPAddress = machineName;

            using (AuditLogDAL dal = new AuditLogDAL(transaction))
            {
                dal.Insert(entity);
            }
        }

        public bool HasError
        {
            get { return Errors != null && Errors.Count > 0; }
        }

    }
}
