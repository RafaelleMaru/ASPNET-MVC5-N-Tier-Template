using NTIER.Common.Entity;
using NTIER.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTIER.Common;
using Rafaelle.Framework;


namespace NTIER.BLL
{
    public partial class UserBLL : BaseBusinessLogic
    {

        #region > Selects

        /// <summary>
        /// Retrieves all the record(s) from the table.
        /// </summary>
        /// <returns>Returns list of UserEntity.</returns>
        public static IList<UserEntity> GetAll()
        {
            List<UserEntity> list = new List<UserEntity>();

            using (UserDAL dal =
                new UserDAL(GetConnectionInfo().ConnectionString))
            {
                list.AddRange(dal.SelectAll());
            }

            return list;
        }

        public static List<UserEntity> SelectAllPagedOrderBy(int pageSize, 
            int startIndex,
            UserDAL.Column sortBy,
            SortOrderDirection sortorder,
            out int recordCountSelected,
            out int recordCount)
        {
            List<UserEntity> list = new List<UserEntity>();

            using (UserDAL dal = new UserDAL(GetConnectionInfo().ConnectionString,
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


        public static List<UserEntity> SearchAndOrderBy(int pageSize,
            int startIndex,
            UserDAL.Column sortBy,
            SortOrderDirection sortorder,
            string search,
            out int recordCountSelected,
            out int recordCount)
        {
            List<UserEntity> list = new List<UserEntity>();

            using (UserDAL dal = new UserDAL(GetConnectionInfo().ConnectionString,
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

        #region > Crud

        /// <summary>
        /// Create new User record.
        /// </summary>
        /// <param name = "data" > Record to insert.</param>
        /// <param name = "currentUser" > User who created the record.</param>
        /// <returns>ID of the new record.</returns>
        public Guid Save(UserEntity data, Guid currentUserId, string currentUser, string machineName)
        {
            using (UserDAL dal = new UserDAL(GetConnectionInfo()))
            {
                if (!((IValidatable)data).Validate())
                {
                    //-- merge error message
                    Errors.Add(data.ErrorMessages);
                    return Guid.Empty;
                }

                try
                {
                    dal.BeginTransaction();
                    Rafaelle.Framework.Action action = Rafaelle.Framework.Action.Add;



                    if (string.IsNullOrEmpty(data.Password))
                    {
                        UserEntity user = dal.SelectById(data.UserId);
                        data.Password = user.Password;
                        data.Salt = user.Salt;
                    }

                    if (IsEditMode(data.UserId))
                    {
                        action = Rafaelle.Framework.Action.Edit;
                        dal.Update(data);
                    }
                    else
                    {
                        data.UserId = Guid.NewGuid();
                        dal.Insert(data);
                    }

                    
                    AuditLog(dal.Transaction,
                        Rafaelle.Framework.Action.Add,
                        BaseXmlSerializer.Serialize(data, Encoding.UTF8, data.GetType()),
                        data.UserId.ToString(),
                        currentUserId,
                        currentUser,
                        EnumObjectSource.User,
                        machineName);

                    dal.CommitTransaction();

                    return data.UserId;
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



        public void Delete(Guid id, Guid currentUserId, string currentUser, string machineName)
        {
            using (UserDAL dal = new UserDAL(GetConnectionInfo()))
            {
                try
                {
                    dal.BeginTransaction();

                    UserEntity data = GetById(id);

                    dal.Delete(id);

                    AuditLog(dal.Transaction,
                        Rafaelle.Framework.Action.Delete,
                        BaseXmlSerializer.Serialize(data, Encoding.UTF8, data.GetType()),
                        data.UserId.ToString(),
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
