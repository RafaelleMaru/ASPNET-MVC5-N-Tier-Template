using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NTIER.BLL;
using NTIER.Common.Entity;
using NTIER.Common.Interface;

namespace NTIER.Test.BLL
{
    [TestClass]
    public partial class UserBLLTest : BaseBLLTest
    {
        public UserBLLTest()
        {

        }

        private TestContext testContextInstance;

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


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        #region > CRUD Test Cases 

        [TestMethod]
        public void UserSaveTest()
        {

            UserBLL userBLL = new UserBLL();
            //Create new ID because Insert does not create NewID if id is empty.
            UserEntity entity = GetEntity(Guid.Empty);
            Guid id = Guid.Empty;

            try
            {
                id = userBLL.Save(entity, Guid.Empty, TEST_USERNAME, Environment.MachineName);
                
                UserEntity testUserEntity = UserBLL.GetById(id);

                AssertData(entity, testUserEntity, "Save-Update");


                
                #region Modify Data to simulate edit

                entity.UserTypeId = 1;/*TODO [Test]: be sure the foreign key is correct.*/
                entity.Username = "UsernameX";
                //entity.Password = "PasswordX";
                //entity.SecurityStamp = "SecurityStampX";
                //entity.Salt = "SaltX";
                entity.Email = "test@cerquit.com";
                entity.Firstname = "FirstnameX";
                entity.Lastname = "LastnameX";
                entity.Middlename = "MiddlenameX";
                entity.Active = false;
                entity.Created = DateTime.Now;
                //entity.CreatedBy = "CreatedByX";
                entity.Updated = DateTime.Now;
                entity.UpdatedBy = "UpdatedByX";


                #endregion


                userBLL.Save(entity, Guid.Empty, TEST_USERNAME, Environment.MachineName);
                testUserEntity = UserBLL.GetById(id);
                AssertData(entity, testUserEntity, "Save-Update");

                userBLL.Delete(id, Guid.Empty, TEST_USERNAME, Environment.MachineName);
                testUserEntity = UserBLL.GetById(id);

                Assert.IsNull(testUserEntity, "Record should not exist because its already deleted.");
                id = Guid.Empty; //-- set empty to prevent delete on finally



            }
            finally
            {
                if (Guid.Empty.CompareTo(id) != 0)
                {
                    userBLL.Delete(id, Guid.Empty, TEST_USERNAME, Environment.MachineName);
                }
            }

        }





        private void AssertData(UserEntity expected, UserEntity actual, string action)
        {
            Assert.AreEqual(expected.UserId, actual.UserId,
                action + ": Data are not equal it should be " + expected.UserId.ToString());
            Assert.AreEqual(expected.UserTypeId, actual.UserTypeId,
                action + ": Data are not equal it should be " + expected.UserTypeId.ToString());
            Assert.AreEqual(expected.Username, actual.Username,
                action + ": Data are not equal it should be " + expected.Username);
            Assert.AreEqual(expected.SecurityStamp.Trim(), actual.SecurityStamp.Trim(),
                action + ": Data are not equal it should be " + expected.SecurityStamp);
            Assert.AreEqual(expected.Password.Trim(), actual.Password.Trim(),
                action + ": Data are not equal it should be " + expected.Password);
            Assert.AreEqual(expected.Salt.Trim(), actual.Salt.Trim(),
                action + ": Data are not equal it should be " + expected.Salt);
            Assert.AreEqual(expected.Email, actual.Email,
                action + ": Data are not equal it should be " + expected.Email);
            Assert.AreEqual(expected.Firstname, actual.Firstname,
                action + ": Data are not equal it should be " + expected.Firstname);
            Assert.AreEqual(expected.Lastname, actual.Lastname,
                action + ": Data are not equal it should be " + expected.Lastname);
            Assert.AreEqual(expected.Middlename, actual.Middlename,
                action + ": Data are not equal it should be " + expected.Middlename);
            Assert.AreEqual(expected.Active, actual.Active,
                action + ": Data are not equal it should be " + expected.Active.ToString());
            //TODO [Test]: Check date validation.
            Assert.AreEqual(expected.Created.ToShortDateString(), actual.Created.ToShortDateString(),
                action + ": Data are not equal it should be " + expected.Created);
            Assert.AreEqual(expected.CreatedBy, actual.CreatedBy,
                action + ": Data are not equal it should be " + expected.CreatedBy);
            //TODO [Test]: Check date validation.
            Assert.AreEqual(expected.Updated.ToShortDateString(), actual.Updated.ToShortDateString(),
                action + ": Data are not equal it should be " + expected.Updated);
            Assert.AreEqual(expected.UpdatedBy, actual.UpdatedBy,
                action + ": Data are not equal it should be " + expected.UpdatedBy);
        }

        private UserEntity GetEntity(Guid userId)
        {
            return new UserEntity(
                userId,
                1,
                "Username",
                "Password",
                "Salt",
                "SecurityStamp",
                "test@cerquit.com",
                "Firstname",
                "Lastname",
                "Middlename",
                true,
                DateTime.Now,
                "CreatedBy",
                DateTime.Now,
                "UpdatedBy",
                null);
        }


        #endregion
    }
}
