using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common.Interface
{
    public interface IPermission
    {
        bool Add { get; set; }
        bool Edit { get; set; }
        bool Delete { get; set; }
        bool View { get; set; }
        bool ListView { get; set; }
        bool Approve { get; set; }
        bool Download { get; set; }
        bool Upload { get; set; }
    }
}
