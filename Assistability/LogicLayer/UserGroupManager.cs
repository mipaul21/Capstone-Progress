/// <summary>
/// William Clark
/// Created: 2021/02/24
/// 
/// Interface for management of UserGroup objects
/// </summary>
///
/// <remarks>
/// </remarks>
using DataAccessFakes;
using DataAccessInterfaces;
using DataAccessLayer;
using DataStorageModels;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class UserGroupManager : IUserGroupManager
    {
        private IUserGroupAccessor _userGroupAccessor;

        public UserGroupManager(IUserGroupAccessor userGroupAccessor)
        {
            _userGroupAccessor = userGroupAccessor;
        }

        public UserGroupManager()
        {
            _userGroupAccessor = new UserGroupAccessor(); ;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/24
        /// 
        /// Selects a List of UserGroups of which the UserAccount has an active membership
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="userAccountID">The UserAccountID of the UserAccount for which to select all UserGroups of which the UserAccount has an active membership</param>
        /// <exception cref="ApplicationException">No UserAccount found</exception>
        /// <returns>A List of UserGroup</returns>
        public List<UserGroup> SelectOwnedUserGroupsByUserAccountID(int userAccountID)
        {
            List<UserGroup> result;
            try
            {
                result = _userGroupAccessor.SelectOwnedUserGroupsByUserAccountID(userAccountID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("No Groups found for this user" + ex.InnerException.Message);
            }
            return result;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        /// 
        /// Selects a List of UserAccounts of which are members in the UserGroup
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="group">The UserGroup for which to select all UserAccounts that are members</param>
        /// <exception cref="ApplicationException">No UserAccount found</exception>
        /// <returns>A List of UserAccount</returns>
        public List<UserAccount> GetUserAccountsByUserGroup(UserGroup group)
        {
            List<UserAccount> result;
            try
            {
                result = _userGroupAccessor.SelectUserAccountsByUserGroup(group);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("No Users found in this group" + ex.InnerException.Message);
            }
            return result;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        /// 
        /// Selects a List of UserAccounts of which are caregivers in the UserGroup
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="group">The UserGroup for which to select all UserAccounts that are caregivers</param>
        /// <param name="userManager">The IUserManager which will handle UserAccount management</param>
        /// <exception cref="ApplicationException">No UserAccount found</exception>
        /// <returns>A List of UserGroup</returns>
        public BindingList<UserAccount> GetUserAccountsInUserGroupByRole(IUserManager userManager, UserGroup group, string roleName)
        {
            BindingList<UserAccount> result = new BindingList<UserAccount>();
            BindingList<UserAccount> allUsers = new BindingList<UserAccount>(GetUserAccountsByUserGroup(group));
            foreach (var user in allUsers)
            {
                foreach (var membership in userManager.GetUserAccountVMByUserAccount(user).Memberships)
                {
                    if (membership.GroupID == group.GroupID)
                    {
                        foreach (var role in membership.Roles)
                        {
                            if (role.Name == roleName)
                            {
                                result.Add(user);
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Selects a UserGroup by it's unique identifier
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="groupID">The UserGroupID for which to select the UserGroup</param>
        /// <exception cref="ApplicationException">No UserGroup found</exception>
        /// <returns>A UserGroup</returns>
        public UserGroup GetUserGroupByGroupID(int groupID)
        {
            UserGroup group = null;
            try
            {
                group = _userGroupAccessor.SelectUserGroupByGroupID(groupID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("User Group could not be found." + ex.InnerException.Message);
            }
            return group;
        }
    }
}
