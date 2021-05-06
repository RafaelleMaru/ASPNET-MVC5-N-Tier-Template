using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTIER.BLL;
using NTIER.Common;
using NTIER.Common.Entity;

namespace NTIER.Test.Controller
{
    [TestClass]
    public class BaseControllerTest
    {
        protected const string CISERVERNAME = "CSITESTSVR";

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public UserIdentity AdministratorIdentity
        {
            get
            {
                UserIdentity identity = new UserIdentity()
                {
                    IsLoggedIn = true,
                    IsSessionActive = true,
                    UserId = GetIdentityUserID("admin"),
                    Username = "admin",
                    UserSessionID = Guid.NewGuid().ToString(),
                    UserType = EnumUserType.Administrator
                };

                return identity;
            }
        }
















        #region > Dummy Records


        public Guid GetIdentityUserID(string username)
        {
            UserEntity user = UserBLL.GetByUsername(username);
            return user.UserId;
        }
        #endregion


    }
}
