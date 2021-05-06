namespace NTIER.Common
{
    public class Constants
    {

        public const string Namespace = "http://localhost:54770/";

        public static readonly string ProjectName = "NTIER";

        public static readonly string AccessDenied = "Access is denied. Contact system administrator.";
        public static readonly string CommonAccessDenied = "Access denied. Contact system administrator.";
        public static readonly string KeyUser = "D70E718D2591";


        public static readonly int SaltCount = 4;
        public static readonly int UniqueKeyCount = 8;


        #region > User

        public static readonly string UserUsernameRequired = "Username is required.";
        public static readonly string UserNameRequired = "Firstname and Lastname is required.";
        public static readonly string UserEmailRequired = "Email is required.";
        public static readonly string UserUsertypeRequired = "User Type is required.";

        public static readonly string UserUsernameAlreadyExist = "Username already taken.";

        public static readonly string UserUsernameExceed = "Username maximum length exceeded.";
        public static readonly string UserPasswordExceed = "Password maximum length exceeded.";
        public static readonly string UserFirstnameExceed = "Firstname maximum length exceeded.";
        public static readonly string UserLastnameExceed = "Lastname maximum length exceeded.";
        public static readonly string UserEmailExceed = "Email maximum length exceeded.";
        public static readonly string UserEmailInvalid = "Invalid email format.";


        #endregion

        #region > UserType

        public static readonly string UserTypeUserTypeNameRequired = "Usertype name is required.";

        public static readonly string UserTypeUserDependency = "One or more user is using this usertype.";


        #endregion


        #region > UserTypeModule

        public static readonly string UserTypeModuleMultipleRecord = "UserTypeModule row is more than one in database.";

        #endregion
    }
}
