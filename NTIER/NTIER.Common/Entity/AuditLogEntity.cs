namespace NTIER.Common.Entity
{
    public partial class AuditLogEntity
    {

        public string ValidationMessage
        {
            get { return base.ErrorMessages.ToString(); }
        }

        public bool Validate()
        {
            //Insert Server Side Validation Here

            return base.ErrorMessages.Count == 0;
        }
        
    }
}
