using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common.Interface
{
    public interface IAuditLogEntity
    {
        long AuditLogId { get; set; }
        Guid UserId { get; set; }
        string IPAddress { get; set; }
        byte ObjectSourceType { get; set; }
        string ObjectSourceId { get; set; }
        byte Action { get; set; }
        DateTime Created { get; set; }
        string CreatedBy { get; set; }
    }
}
