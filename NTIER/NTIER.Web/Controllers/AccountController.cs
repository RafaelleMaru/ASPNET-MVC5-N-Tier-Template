using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using NTIER.BLL;
using NTIER.Common.Entity;
using NTIER.Web.Models;
using Rafaelle.Framework;

namespace NTIER.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private AuthenticationMode _authenticationMode = AuthenticationMode.None;
        protected FormCollection Form;
        private string _username = String.Empty;
        private string _ip;


        

        protected string GetUsername
        {
            get
            {
                string username = this.User.Identity.Name;
                if (!String.IsNullOrEmpty(username) && username.Contains('\\'))
                {
                    string[] user = this.User.Identity.Name.Split('\\');
                    username = user[1];
                }

                return username;
            }
        }


        private bool ValidateUser(string userName, string password)
        {
            UserEntity user = null;
            user = UserBLL.GetByUsername(userName);

            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("", "Username is required.");
                return false;
            }


            if (user == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return false;
            }

            bool _isValidPassword = user != null && PasswordHelper.PasswordChecker(password, user.Password, user.Salt);

            
                if (!_isValidPassword)
                {
                    ModelState.AddModelError("", "Incorrect Password.");
                    return false;
                }
            


            if (user != null)
            {
                if (!user.Active)
                {
                    ModelState.AddModelError("", "User account not active. Please contact the administrator.");
                    return false;
                }
            }


            return true;
        }


        /// <summary>
        /// Since we are only using Forms and Windows authentication, 
        /// </summary>
        protected bool IsWindowsAuthentication
        {
            get
            {
                if (_authenticationMode == AuthenticationMode.None)
                {
                    Configuration configuration =
                        WebConfigurationManager.OpenWebConfiguration("~/");
                    _authenticationMode =
                    (configuration.SectionGroups["system.web"].Sections["authentication"]
                        as AuthenticationSection).Mode;
                }

                return _authenticationMode == AuthenticationMode.Windows;
            }
        }


        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }



        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {

            if (IsWindowsAuthentication)
            {
                ViewBag.DisabledHide = true;
            }

            _username = GetUsername;
            ViewBag.Username = _username;
            ////PopulateFacility();

            if (ModelState.IsValid)
            {
                if (ValidateUser(model.Username, model.Password))
                {
                    Session.Abandon();
                    FormsAuthentication.SignOut();

                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    string currentURL = HttpContext.Request.UrlReferrer.AbsoluteUri;

                    //check usertype
                    UserEntity user = UserBLL.GetByUsername(model.Username);

                    if (currentURL.Contains("ReturnUrl="))
                    {
                        currentURL = currentURL.Replace("ReturnUrl=%2f", "");

                        string newURL = currentURL.Replace("Account/Login?", "");
                        newURL = Server.UrlDecode(newURL);
                        if (newURL.Contains("&id"))
                            newURL = newURL.Remove(newURL.IndexOf("&id"));

                        return Redirect(newURL);
                    }
                    else
                    {
                        //if (user.UserTypeId == (byte)EnumUserType.ProviderUser)
                        //    return RedirectToAction("List", "QuotationRequest");
                        //if (user.UserTypeID == (byte)EnumUserType.PublicUser)
                        //    return RedirectToAction("List", "Form");
                        //else
                            return RedirectToAction("Index", "Dashboard");
                    }
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult JsonLogin(LoginModel model, string returnUrl)
        {
            //if (IsWindowsAuthentication)
            //{
            //    ViewBag.DisabledHide = true;
            //}

            _username = GetUsername;
            ViewBag.Username = _username;
            //PopulateFacility();

            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    return Json(new { success = true, redirect = returnUrl });
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed
            return Json(new { errors = GetErrorsFromModelState() });
        }




        //
        // GET: /Account/LogOut

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            if (Session != null)
            {
                Session.Abandon();
                //Session.Clear();
                //Session.RemoveAll();
            }


            //InstanceMonitorBLL.DeleteByUsername(GetUsername);

            return RedirectToAction("Index", "Home");
        }


        private IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }




        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }


    }
}