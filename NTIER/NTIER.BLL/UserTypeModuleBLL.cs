using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTIER.Common;
using NTIER.Common.Entity;
using NTIER.DAL;
using Rafaelle.Framework;

namespace NTIER.BLL
{
    public partial class UserTypeModuleBLL
    {

        /// <summary>
        /// Get record by userTypeId.
        /// </summary>
        /// <param name="userTypeId">Filter by userTypeId.</param>
        /// <returns>Record(s) of UserTypeModuleList.</returns>
        public static IList<UserTypeModuleEntity> GetByUserTypeId(byte userTypeModuleId)
        {
            using (UserTypeModuleDAL dal = new UserTypeModuleDAL(GetConnectionInfo()))
            {
                return dal.SelectByUserTypeId(userTypeModuleId);
            }
        }

        public static IList<UserTypeModuleEntity> GetByUserTypeIdAndModuleId(byte userTypeModuleId, short moduleId)
        {
            using (UserTypeModuleDAL dal = new UserTypeModuleDAL(GetConnectionInfo()))
            {
                return dal.SelectByUserTypeIdAndModuleid(userTypeModuleId, moduleId);
            }
        }


        public static PermissionEntity GetBitwisePermission(long permission)
        {
            
            PermissionEntity entity = new PermissionEntity();

            entity.Add = (permission & (long) EnumPermission.Add) == (long) EnumPermission.Add;
            entity.Edit = (permission & (long) EnumPermission.Edit) == (long) EnumPermission.Edit;
            entity.Delete = (permission & (long)EnumPermission.Delete) == (long)EnumPermission.Delete;
            entity.View = (permission & (long)EnumPermission.View) == (long)EnumPermission.View;
            entity.ListView = (permission & (long)EnumPermission.ListView) == (long)EnumPermission.ListView;
            entity.Approve = (permission & (long)EnumPermission.Approve) == (long)EnumPermission.Approve;
            entity.Download = (permission & (long)EnumPermission.Download) == (long)EnumPermission.Download;
            entity.Upload = (permission & (long)EnumPermission.Upload) == (long)EnumPermission.Upload;

            return entity;

        }

        public int SavePermission(UserTypeModuleEntity data, Guid currentUserId, string currentUser, string machineName)
        {

            int id = 0;
            using (UserTypeModuleDAL dal = new UserTypeModuleDAL(GetConnectionInfo()))
            {
                if (!((IValidatable)data).Validate())
                {
                    //-- merge error message
                    Errors.Add(data.ErrorMessages);
                    return 0;
                }

                try
                {
                    dal.BeginTransaction();
                    Rafaelle.Framework.Action action = Rafaelle.Framework.Action.Add;





                    if (IsEditMode(data.UserTypeModuleId))
                    {
                        action = Rafaelle.Framework.Action.Edit;
                        dal.Update(data);
                        id = data.UserTypeModuleId;
                    }
                    else
                    {
                        id = dal.Insert(data);
                    }


                    AuditLog(dal.Transaction,
                        Rafaelle.Framework.Action.Add,
                        BaseXmlSerializer.Serialize(data, Encoding.UTF8, data.GetType()),
                        id.ToString(),
                        currentUserId,
                        currentUser,
                        EnumObjectSource.User,
                        machineName);

                    dal.CommitTransaction();

                    return data.UserTypeModuleId;
                }

                catch (Exception ex)
                {
                    dal.RollBackTransaction();

                    throw ex;
                }

                finally
                {
                    dal.Dispose();
                }
            }
        }


    }
}
