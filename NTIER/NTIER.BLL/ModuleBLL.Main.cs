using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTIER.Common.Entity;
using NTIER.DAL;

namespace NTIER.BLL
{
    public partial class ModuleBLL : BaseBusinessLogic
    {
        public static IList<ModuleEntity> GetAll()
        {
            List<ModuleEntity> list = new List<ModuleEntity>();

            using (ModuleDAL dal =
                new ModuleDAL(GetConnectionInfo().ConnectionString))
            {
                list.AddRange(dal.SelectAll());
            }

            return list;
        }
    }
}
