using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using NTIER.BLL;
using NTIER.Common;
using NTIER.Common.Entity;
using NTIER.DAL;
using NTIER.Web.Models;
using Rafaelle.Framework;
using WebGrease;

namespace NTIER.Web.Controllers
{
    public class UserTypeController : BaseController
    {

        protected override EnumModule CurrentModule
        {
            get { return EnumModule.UserType; }
        }


        //GET: UserType
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Saves the record to data repository.
        /// </summary>
        /// <param name="id">Unique identifier of the record.</param>
        /// <param name="form">Contains the data posted by form.</param>
        /// <returns>MessageResult in JSON format.</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(byte id, FormCollection form)
        {
            ErrorMessage = new ErrorMessageCollection();
            string errorMessage = String.Empty;
            Form = form;
            ID = id;

            try
            {
                if (ValidateBeforeSave())
                {
                    
                    UserTypeEntity entity = new UserTypeEntity(
                        id,
                        form["userTypeName"].ToString()
                    );


                    if (entity.Validate())
                    {
                      
                        if (!UserTypeBLL.UserTypeNameExist(entity.UserTypeName, id))
                        {
                            UserTypeBLL bll = new UserTypeBLL();
                            bll.Save(entity,
                                CurrentUser.UserId,
                                CurrentUser.Username,
                                Environment.MachineName);

                            if (bll.HasError)
                            {
                                errorMessage = bll.Errors.FirstErrorMessage.Message;
                            }

                            ID = id = entity.UserTypeId;

                        }
                    }


                }
                else if (ErrorMessage.Count > 0)
                {
                    errorMessage = ErrorMessage.FirstErrorMessage.Message;
                }
                else
                {
                    errorMessage = ErrorMessage.ToString();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }

            MessageResult result = new MessageResult(errorMessage,
                errorMessage != String.Empty,
                id);

            return Json(result);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(byte id)
        {
            ErrorMessage = new ErrorMessageCollection();
            string errorMessage = String.Empty;
            ID = id;

            try
            {
                if (ValidateBeforeDelete())
                {
                    if (!CheckUserByUserType(id))
                    {
                        UserTypeBLL bll = new UserTypeBLL();
                        bll.Delete(id, CurrentUser.UserId, CurrentUser.Username, IP);
                    }
                    else
                    {
                        errorMessage = Constants.UserTypeUserDependency;
                    }
                    
                    
                }
                else if (ErrorMessage.Count > 0)
                {
                    errorMessage = ErrorMessage.FirstErrorMessage.Message;
                }
                else
                {
                    errorMessage = ErrorMessage.ToString();
                }
                

            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                
            }

            MessageResult result = new MessageResult(errorMessage,
                errorMessage != String.Empty,
                id);

            return Json(result);


        }


        /// <summary>
        /// Key-Value result.
        /// </summary>
        /// <returns>MessageResult in JSON format.</returns>
        /// <remarks>
        /// This is used for populating dropdowns/combobox controls.
        /// </remarks>
        [HttpPost]
        public ActionResult KeyValueList()
        {
            
            int recordCount = 0;
            string message = "";
            bool error = false;
            object result;
            IList<KeyValuePair<string, string>> listResult =
                new List<KeyValuePair<string, string>>();

            try
            {
                IList<UserTypeEntity> list = UserTypeBLL.GetAll(out recordCount);

                listResult.Add(new KeyValuePair<string, string>("", "-- Select User Type --"));
                //listResult.Add(new KeyValuePair<string, string>("0", "None"));

                //removed Unknown
                list = list.Where(x => x.UserTypeId != 0).ToList();

                foreach (UserTypeEntity item in list)
                {
                    listResult.Add(new KeyValuePair<string, string>(item.UserTypeId.ToString(), item.UserTypeName));
                }

                //TODO: Create Error Log Handler
                //throw new NotImplementedException();
            }

            catch (Exception ex)
            {
                //TODO: LogManager
                //LogManager.LogException(ex);
                //TODO: Throw
                
                return Json(result = new
                {
                    message = ex.Message,
                    error = true,
                    data = listResult
                });
            }



            result = new
            {
                message,
                error = false,
                data = listResult
            };
            
            return Json(result);
        }




        /// <summary>
        /// Gets a record by its unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier of the record.</param>
        /// <returns>MessageResult in JSON format.</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Initialize(byte id)
        {
            ErrorMessage = new ErrorMessageCollection();
            string errorMessage = String.Empty;
            ID = id;
            UserTypeEntity entity = null;

            try
            {
                if (ValidateBeforeInitialize())
                {
                    entity = UserTypeBLL.GetById(id);

                }

                else
                {
                    errorMessage = ErrorMessage.ToString();
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
            }

            MessageResult result = new MessageResult(errorMessage,
                errorMessage != String.Empty,
                entity

            );

            return Json(result);
        }



        private bool CheckUserByUserType(byte userType)
        {
            IList<UserEntity> userEntities = new List<UserEntity>();
            userEntities = UserBLL.GetByUserTypeId(userType);

            if (userEntities.Count > 0)
            {
                return true;
            }
            
            return false;
        }



    }
}