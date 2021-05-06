using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common
{
    public enum EnumObjectSource : byte
    {
        Unknown,
        Module,
        User,
        UserType,
        UserTypeModule
    }

    public enum EnumModule : int
    {
        None = 0,
        User,
        UserType,
        UserTypeModule
    }

    public enum EnumPermission : long
    {
        None = 0x00000000,          //0
        Add = 0x00000001,           //1
        Edit = 0x00000002,          //2
        Delete = 0x00000004,        //4
        View = 0x00000008,          //8
        ListView = 0x000000010,     //16        
        Approve = 0x000000020,      //32
        Download = 0x000000040,     //64
        Upload = 0x000000080,     //128
        
        //Cancel = 0x000002000,           //8192

        All = 0x00003FFF            //-- all 16383
    }

    public enum EnumUserType
    {
        // Don't edit the equivalent value of this UserType. SP's, Conditions and Validation may affected.
        Unknown = 0,
        Administrator,
        PublicUser

    }


    public enum EnumAuditAction : int
    {
        Unknown = 0,
        Create = 1,
        Read,
        Update,
        Delete,
        ListView,
        Upload,
        Download,
        Approve,
        Reject,
        Login = 101,
        Logout
            
    }


}
