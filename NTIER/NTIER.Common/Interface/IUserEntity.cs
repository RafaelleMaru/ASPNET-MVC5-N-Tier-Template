using System;

namespace NTIER.Common.Interface
{
    public interface IUserEntity
    {
        Guid UserId { get; set; }
        byte UserTypeId { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Salt { get; set; }
        string SecurityStamp { get; set; } 
        string Email { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Middlename { get; set; }
        bool Active { get; set; }
        DateTime Created { get; set; }
        string CreatedBy { get; set; }
        DateTime Updated { get; set; }
        string UpdatedBy { get; set; }
        byte[] Timestamp { get; set; }
    }
}
