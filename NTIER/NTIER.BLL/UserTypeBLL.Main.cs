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
    public partial class UserTypeBLL : BaseBusinessLogic
    {


        #region > Select

        public static IList<UserTypeEntity> GetAll(out int recordCount)
        {
            List<UserTypeEntity> list = new List<UserTypeEntity>();

            using (UserTypeDAL dal =
                new UserTypeDAL(GetConnectionInfo().ConnectionString))
            {
                list.AddRange(dal.SelectAll());
                recordCount = dal.Count;
            }

            return list;
        }

        public static List<UserTypeEntity> SelectAllPagedOrderBy(int pageSize,
            int startIndex,
            UserTypeDAL.Column sortBy,
            SortOrderDirection sortorder,
            out int recordCountSelected,
            out int recordCount)
        {
            List<UserTypeEntity> list = new List<UserTypeEntity>();

            using (UserTypeDAL dal = new UserTypeDAL(GetConnectionInfo().ConnectionString,
                startIndex,
                pageSize,
                sortorder
            ))
            {
                list.AddRange(dal.SelectAllPagedOrderBy(sortBy));
                recordCount = dal.Count;
                recordCountSelected = dal.CountSelected;
            }

            return list;

        }


        public static List<UserTypeEntity> SearchAndOrderBy(int pageSize,
            int startIndex,
            UserTypeDAL.Column sortBy,
            SortOrderDirection sortorder,
            string search,
            out int recordCountSelected,
            out int recordCount)
        {
            List<UserTypeEntity> list = new List<UserTypeEntity>();

            using (UserTypeDAL dal = new UserTypeDAL(GetConnectionInfo().ConnectionString,
                startIndex,
                pageSize,
                sortorder,
                search
            ))
            {
                list.AddRange(dal.SearchAndOrderBy(sortBy));
                recordCount = dal.Count;
                recordCountSelected = dal.CountSelected;
            }

            return list;

        }

        #endregion



        #region > CRUD
        /// <summary>
        /// Create new User record.
        /// </summary>
        /// <param name = "data" > Record to insert.</param>
        /// <param name = "currentUser" > User who created the record.</param>
        /// <returns>ID of the new record.</returns>
        public Byte Save(UserTypeEntity data, Guid currentUserId, string currentUser, string machineName)
        {

            byte id = 0;
            using (UserTypeDAL dal = new UserTypeDAL(GetConnectionInfo()))
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



                   

                    if (IsEditMode(data.UserTypeId))
                    {
                        action = Rafaelle.Framework.Action.Edit;
                        dal.Update(data);
                        id = data.UserTypeId;
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

                    return data.UserTypeId;
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


        public void Delete(byte id, Guid currentUserId, string currentUser, string machineName)
        {
            using (UserTypeDAL dal = new UserTypeDAL(GetConnectionInfo()))
            {
                try
                {
                    dal.BeginTransaction();

                    UserTypeEntity data = GetById(id);

                    dal.Delete(id);

                    AuditLog(dal.Transaction,
                        Rafaelle.Framework.Action.Delete,
                        BaseXmlSerializer.Serialize(data, Encoding.UTF8, data.GetType()),
                        data.UserTypeId.ToString(),
                        currentUserId,
                        currentUser,
                        EnumObjectSource.User,
                        machineName);

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


        #endregion

    }
}
