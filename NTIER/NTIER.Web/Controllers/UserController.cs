using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using NTIER.BLL;
using NTIER.Common;
using NTIER.Common.Entity;
using Rafaelle.Framework;
using WebGrease;


namespace NTIER.Web.Controllers
{
    
    public class UserController : BaseController
    {

        protected override EnumModule CurrentModule
        {
            get { return EnumModule.User; }
        }
        // GET: User
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
        public ActionResult Save(Guid id, FormCollection form)
        {
            ErrorMessage = new ErrorMessageCollection();
            string errorMessage = String.Empty;
            Form = form;
            ID = id;

            try
            {
                if (ValidateBeforeSave())
                {
                    string saltKey = string.Empty;
                    saltKey = PasswordHelper.CreateSalt(Constants.SaltCount);
                    bool isActive = false;
                    if (!string.IsNullOrEmpty(form["active"]))
                    {
                        if (form["active"].ToString() == "on")
                            isActive = true;
                    }

                    UserEntity entity = new UserEntity(
                        id,
                        Convert.ToByte(form["userTypeId"]),
                        form["username"].ToString(),
                        form["password"].ToString(),
                        saltKey,
                        null,
                        form["email"].ToString(),
                        form["firstname"].ToString(),
                        form["lastname"].ToString(),
                        "",
                        isActive,
                        DateTime.Now,
                        CurrentUser.Username,
                        DateTime.Now,
                        CurrentUser.Username,
                        null
                    );


                    if (entity.Validate())
                    {
                        if (!string.IsNullOrEmpty(entity.Password))
                            entity.Password =
                                Rafaelle.Framework.PasswordHelper.GenerateSha256Hash(entity.Password, saltKey);

                        if (!UserBLL.UserNameExist(entity.Username, id))
                        {
                            UserBLL bll = new UserBLL();
                            bll.Save(entity,
                                CurrentUser.UserId,
                                CurrentUser.Username,
                                Environment.MachineName);

                            if (bll.HasError)
                            {
                                errorMessage = bll.Errors.FirstErrorMessage.Message;
                            }

                            ID = id = entity.UserId;

                        }
                    }


                }
                else if (ErrorMessage.Count > 0)
                {
                    errorMessage = ErrorMessage.FirstErrorMessage.Message;
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




        /// <summary>
        /// Gets a record by its unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier of the record.</param>
        /// <returns>MessageResult in JSON format.</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Initialize(Guid id)
        {
            ErrorMessage = new ErrorMessageCollection();
            string errorMessage = String.Empty;
            ID = id;
            UserEntity entity = null;
           
            try
            {
                if (ValidateBeforeInitialize())
                {
                    entity = UserBLL.GetById(id);
                  
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

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            ErrorMessage = new ErrorMessageCollection();
            string errorMessage = String.Empty;
            ID = id;

            try
            {
                if (ValidateBeforeDelete())
                {
                    UserBLL bll = new UserBLL();
                    bll.Delete(id, CurrentUser.UserId, CurrentUser.Username, IP);

                }
                else
                {
                    errorMessage = ErrorMessage.ToString();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                //LogManager.LogException(ex);
            }


            MessageResult result = new MessageResult(errorMessage,
                errorMessage != String.Empty,
                id);

            return Json(result);
        }



        protected override bool ValidateBeforeInitialize()
        {
            try
            {
                if (base.ValidateBeforeInitialize())
                {
                    //TODO [Controller]: Add view validation
                    return true;
                }
            }

            catch (Exception ex)
            {

                ErrorMessage.Add(ex.Message);
            }

            return false;
        }

        protected override bool ValidateBeforeSave()
        {
            try
            {
                if (base.ValidateBeforeSave())
                {
                    //TODO [Controller]: Add Save validation
                    return true;
                }
            }

            catch (Exception ex)
            {
                //LogManager.LogException(ex);
                ErrorMessage.Add(ex.Message);
            }

            return false;
        }

        protected override bool ValidateBeforeDelete()
        {
            try
            {
                if (base.ValidateBeforeDelete())
                {
                    //TODO [Controller]: Add Delete Validation'
                    return true;
                }
            }
            catch (Exception ex)
            {
                //LogManager.LogException(ex);
                ErrorMessage.Add(ex.Message);
            }

            return false;
        }

        protected override bool ValidateBeforeListView()
        {
            try
            {
                if (base.ValidateBeforeListView())
                {
                    //TODO [Controller]: Add Delete Validation'
                    return true;
                }
            }
            catch (Exception ex)
            {
                //LogManager.LogException(ex);
                ErrorMessage.Add(ex.Message);
            }

            return false;
        }

    }
}