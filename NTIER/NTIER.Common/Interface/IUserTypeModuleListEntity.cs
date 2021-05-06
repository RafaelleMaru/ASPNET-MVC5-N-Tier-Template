using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common.Interface
{
    public interface IUserTypeModuleListEntity
    {

        int UserTypeModuleId { get; set; }
        short ModuleId { get; set; }
        byte UserTypeId { get; set; }
        string ModuleName { get; set; }
        long Permission { get; set; }
        long ValidPermission { get; set; }


    }
}
