using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common.Entity
{
    public partial class PermissionEntity
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
