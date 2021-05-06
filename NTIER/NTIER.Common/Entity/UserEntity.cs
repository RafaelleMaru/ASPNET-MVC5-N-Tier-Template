using System;


namespace NTIER.Common.Entity
{
    public partial class UserEntity
    {


        #region > IValidatable Members

        public string ValidationMessage
        {
            get { return base.ErrorMessages.ToString(); }
        }

        public bool Validate()
        {

            if (String.IsNullOrEmpty(Username.Trim()) && Username.Trim().Length == 0)
                ErrorMessages.Add(Constants.UserUsernameRequired);

            if (String.IsNullOrEmpty(Firstname.Trim()) && Firstname.Trim().Length == 0)
                ErrorMessages.Add(Constants.UserNameRequired);

            if (String.IsNullOrEmpty(Lastname.Trim()) && Lastname.Trim().Length == 0)
                ErrorMessages.Add(Constants.UserNameRequired);

            if (String.IsNullOrEmpty(Email.Trim()) && Email.Trim().Length == 0)
                ErrorMessages.Add(Constants.UserEmailRequired);

            if (UserTypeId == 0)
                ErrorMessages.Add(Constants.UserUsertypeRequired);

            string validEmail = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; // ^\w+([\.\-_]\w+)*\w*@\w+([\.\-_]?\w+)*\w*(\.\w{1,16}){1,8}$
            if (!System.Text.RegularExpressions.Regex.IsMatch(Email, validEmail) && Email.Trim().Length > 0)
            {
                ErrorMessages.Add(Constants.UserEmailInvalid);
            }

            if (!String.IsNullOrEmpty(Username) && Username.Length > UsernameMaxLength) ErrorMessages.Add(Constants.UserUsernameExceed);

            if (!String.IsNullOrEmpty(Password) && Password.Length > PasswordMaxLength) ErrorMessages.Add(Constants.UserPasswordExceed);

            if (!String.IsNullOrEmpty(Email) && Email.Length > EmailMaxLength) ErrorMessages.Add(Constants.UserEmailExceed);

            if (!String.IsNullOrEmpty(Firstname) && Firstname.Length > FirstnameMaxLength) ErrorMessages.Add(Constants.UserFirstnameExceed);

            if (!String.IsNullOrEmpty(Lastname) && Lastname.Length > LastnameMaxLength) ErrorMessages.Add(Constants.UserLastnameExceed);

            return base.ErrorMessages.Count == 0;
        }

        #endregion




    }
}
