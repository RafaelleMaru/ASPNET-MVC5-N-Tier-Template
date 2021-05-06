using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTIER.BLL;
using NTIER.Common;
using NTIER.Common.Entity;
using NTIER.Web.Models;
using Rafaelle.Framework;

namespace NTIER.Web.Controllers
{
    /// <summary>
    /// UserTypeModule changed into Permission to avoid confusion to users since it is accessing permissions on modules. 
    /// </summary>
    public class PermissionController : BaseController
    {

        //UserTypeModule


        // GET: Permission
        


        protected override EnumModule CurrentModule
        {
            get { return EnumModule.UserTypeModule; }
        }
        

        public ActionResult Index()
        {
            IList<ModuleEntity> entity = ModuleBLL.GetAll();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Index(byte id)
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

                    entity.UserTypeModuleList = UserTypeModuleBLL.GetByUserTypeId(id);

                    foreach (UserTypeModuleEntity userTypeModuleEntity in entity.UserTypeModuleList)
                    {
                        userTypeModuleEntity.BitwisePermission =
                            UserTypeModuleBLL.GetBitwisePermission(userTypeModuleEntity.Permission);
                    }
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







        [HttpPost]
        public ActionResult SavePermission(byte id, IList<ModulePermissionModel> modelList)
        {

            ErrorMessage = new ErrorMessageCollection();
            string errorMessage = String.Empty;

            ID = id;

            try
            {
                if (ValidateBeforeSave())
                {

                    UserTypeEntity UserTypeEntity = UserTypeBLL.GetById(id);


                    if (UserTypeEntity.Validate())
                    {


                        IList<UserTypeModuleEntity> entity = null;




                        var enumPermission = Enum.GetNames(typeof(EnumPermission)).Length;
                        long permissionValue = 0;


                        foreach (var model in modelList)
                        {



                            entity = UserTypeModuleBLL.GetByUserTypeIdAndModuleId(id, model.ModuleId);


                            if (entity.Count > 1)
                            {
                                errorMessage = Constants.UserTypeModuleMultipleRecord;
                            }
                            else
                            {

                                //Add new instance in entity
                                if (entity.Count == 0)
                                {
                                    entity.Insert(0, new UserTypeModuleEntity(0, id, model.ModuleId, GetPermissionValue(model), DateTime.MinValue, "", DateTime.MinValue, ""));
                                }


                                //Save Permission
                                UserTypeModuleBLL bll = new UserTypeModuleBLL();
                                entity.First().Permission = GetPermissionValue(model);
                                bll.SavePermission(entity.First(), CurrentUser.UserId, CurrentUser.Username,
                                    Environment.MachineName);

                            }


                        }

                        //End of Validate

                        //if (!UserTypeBLL.UserTypeNameExist(entity.UserTypeName, id))
                        //{
                        //    UserTypeBLL bll = new UserTypeBLL();
                        //    bll.Save(entity,
                        //        CurrentUser.UserId,
                        //        CurrentUser.Username,
                        //        Environment.MachineName);

                        //    if (bll.HasError)
                        //    {
                        //        errorMessage = bll.Errors.FirstErrorMessage.Message;
                        //    }

                        //    ID = id = entity.UserTypeId;

                        //}
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



        public long GetPermissionValue(ModulePermissionModel model)
        {


            var enumPermission = Enum.GetNames(typeof(EnumPermission)).Length;
            long permissionValue = 0;



            if (model.Add) permissionValue += (long)EnumPermission.Add;
            if (model.Edit) permissionValue += (long)EnumPermission.Edit;
            if (model.Delete) permissionValue += (long)EnumPermission.Delete;
            if (model.View) permissionValue += (long)EnumPermission.View;
            if (model.ListView) permissionValue += (long)EnumPermission.ListView;
            if (model.Approve) permissionValue += (long)EnumPermission.Approve;
            if (model.Download) permissionValue += (long)EnumPermission.Download;
            if (model.Upload) permissionValue += (long)EnumPermission.Upload;





            return permissionValue;
        }

    }
}