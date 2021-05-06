namespace NTIER.Common.Entity
{
    public partial class UserTypeModuleListEntity
    {
        #region > IValidatable Members

        public string ValidationMessage
        {
            get { return base.ErrorMessages.ToString(); }
        }

        public bool Validate()
        {
            return base.ErrorMessages.Count == 0;
        }

        #endregion
    }
}

