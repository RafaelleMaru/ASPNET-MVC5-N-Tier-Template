using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafaelle.Framework
{
    public enum Action : byte
    {
        None = 0,
        Add = 1,
        Edit = 2,
        Delete = 3,
        View = 4,
        Refresh = 5,
        LogIn = 6,
        LogOut = 7,
        Upload = 8,
        Download = 9
    }
}
