using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common.Interface
{
    public interface IUserTypeModuleEntity
    {
        int UserTypeModuleId{ get; set; }

        byte UserTypeId{ get; set; }

        short ModuleId{ get; set; }

        long Permission{ get; set; }

        DateTime Created{ get; set; }

        string CreatedBy{ get; set; }

        DateTime Updated{ get; set; }

        string UpdatedBy{ get; set; }
    }
}
