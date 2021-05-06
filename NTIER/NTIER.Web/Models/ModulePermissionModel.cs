using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTIER.Web.Models
{
    public class ModulePermissionModel
    {
        public Int16 ModuleId { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
        public bool ListView { get; set; }
        public bool Approve { get; set; }
        public bool Download { get; set; }
        public bool Upload { get; set; }
    }
}