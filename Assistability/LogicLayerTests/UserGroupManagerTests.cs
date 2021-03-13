/// <summary>
/// William Clark
/// Created: 2021/02/04
/// 
/// Test class for the UserGroupManager
/// </summary>
///
/// <remarks>
/// </remarks>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessFakes;
using DataAccessLayer;
using DataStorageModels;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    [TestClass]
    public class UserGroupManagerTests
    {
        const int arbitraryValidUserID = 1;
        private UserGroup arbitraryValidUserGroup = new UserGroup(1, 1);
        IUserGroupManager _userGroupManager;

        /// <summary>
        /// William Clark
        /// Created: 2021/02/24
        /// 
        /// TestIntialize method that initializes an IUserGroupManager
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _userGroupManager = new UserGroupManager(new UserGroupFakes());
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/18
        /// 
        /// Tests SelectUserGroupsByUserAccountID method with an arbitrary valid UserAccountID
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestMethod]
        public void TestSelectOwnedUserGroupsByUserAccountIDReturnsUserGroupList()
        {
            // Arrange
            List<UserGroup> expectedResult = new List<UserGroup>() { new UserGroup(1, 1) };
            List<UserGroup> actualResult;

            // Act 
            actualResult = _userGroupManager.SelectOwnedUserGroupsByUserAccountID(arbitraryValidUserID);

            // Assert
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        /// 
        /// Tests GetUserAccountsByUserGroup method with an arbitrary valid UserGroup
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestMethod]
        public void TestGetUserAccountsByUserGroupReturnsUserAccountList()
        {
            // Arrange
            List<UserAccount> expectedResult = new List<UserAccount>() 
            {
                new UserAccount(1, "First", "Administrator", "firstAdmin", "first@administrator.com", true),
                new UserAccount(2, "Care", "Giver", "Caregiver", "caregiver@Assisstability.com", true),
                new UserAccount(3, "Client", "Client", "Client", "client@Assisstability.com", true)
            };
            List<UserAccount> actualResult;

            // Act 
            actualResult = _userGroupManager.GetUserAccountsByUserGroup(arbitraryValidUserGroup);

            // Assert
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        /// 
        /// Tests GetUserAccountsInUserGroupByRole method with an arbitrary valid UserGroup
        /// and arbitrary valid role
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestMethod]
        public void TestGetUserAccountsInUserGroupByRoleReturnsUserAccountList()
        {
            // Arrange
            BindingList<UserAccount> expectedResult = new BindingList<UserAccount>()
            {
                new UserAccount(1, "First", "Administrator", "firstAdmin", "first@administrator.com", true)
            };
            BindingList<UserAccount> actualResult;
            IUserManager userManager = new UserManager(new UserFakes());

            // Act 
            actualResult = _userGroupManager.GetUserAccountsInUserGroupByRole(userManager, new UserGroup(1, 1), "Admin");

            // Assert
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        /// 
        /// Tests GetUserGroupByGroupID method
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestMethod]
        public void TestGetUserGroupByGroupIDReturnsUserGroup()
        {
            // Arrange
            UserGroup expectedResult = new UserGroup(1, 1);
            UserGroup actualResult;

            // Act
            actualResult = _userGroupManager.GetUserGroupByGroupID(1);

            // Assert
            Assert.AreEqual(expectedResult.GroupID, actualResult.GroupID);
            Assert.AreEqual(expectedResult.UserID_Owner, actualResult.UserID_Owner);
        }
    }
}
