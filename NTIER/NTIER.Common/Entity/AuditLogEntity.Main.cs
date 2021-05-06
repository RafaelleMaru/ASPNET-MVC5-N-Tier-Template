using System;
using System.Collections.Specialized;
using NTIER.Common.Interface;
using Rafaelle.Framework;

namespace NTIER.Common.Entity
{
    public partial class AuditLogEntity : ModelBase, IAuditLogEntity
    {

        #region > Variables


        private long _auditLogId;
        private Guid _userId;
        private string _ipAddress;
        private byte _objectSourceType;
        private string _objectSourceId;
        private byte _action;
        private DateTime _created;
        private string _createdBy;

        #endregion


        #region > Constructors

        public AuditLogEntity()
        {

        }

        public AuditLogEntity(int auditLogId,
        Guid userId,
         string ipAddress,
         byte objectSourceType,
         string objectSourceId,
         byte action,
         DateTime created,
         string createdBy)
        {
            _auditLogId = auditLogId;
            _userId = userId;
            _ipAddress = ipAddress;
            _objectSourceId = objectSourceId;
            _objectSourceType = objectSourceType;
            _action = action;
            _created = created;
            _createdBy = createdBy;
        }

        public AuditLogEntity(NameValueCollection form)
        {
            AuditLogId = Convert.ToInt32(form["auditLogId"]);
            UserId = new Guid(form["userId"]);
            IPAddress = form["ipAddress"];
            ObjectSourceType = Convert.ToByte(form["objectSourceType"]);
            ObjectSourceId = form["objectSourceId"];
            Action = Convert.ToByte(form["action"]);
            Created = Convert.ToDateTime(form["created"]);
            CreatedBy = form["createdBy"];
        }

        #endregion




        #region Properties


        public long AuditLogId
        {
            get => _auditLogId;

            set => _auditLogId = value;
        }

        public Guid UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public string IPAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }


        public byte ObjectSourceType
        {
            get { return _objectSourceType; }
            set { _objectSourceType = value; }
        }

        public string ObjectSourceId
        {
            get { return _objectSourceId; }
            set { _objectSourceId = value; }
        }

        public byte Action
        {
            get { return _action; }
            set { _action = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        #endregion


    }
}
