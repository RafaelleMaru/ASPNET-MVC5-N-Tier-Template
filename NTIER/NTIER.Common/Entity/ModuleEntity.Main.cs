using NTIER.Common.Interface;
using Rafaelle.Framework;
using System;

namespace NTIER.Common.Entity
{
    public partial class ModuleEntity : ModelBase, IModuleEntity
    {

        private Int16 _moduleId;
        private string _moduleName;
        private long _validPermission;

        public short ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }



        public string ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }



        public long ValidPermission
        {
            get { return _validPermission; }
            set { _validPermission = value; }
        }

        #region > Constructor
        public ModuleEntity()
        {

        }

        public ModuleEntity(Int16 moduleId, string moduleModuleName, long validPermission)
        {
            _moduleId = moduleId;
            _moduleName = moduleModuleName;
            _validPermission = validPermission;

        }




        #endregion

    }
}
