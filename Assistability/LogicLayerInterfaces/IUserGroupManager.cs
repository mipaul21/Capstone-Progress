/// <summary>
/// William Clark
/// Created: 2021/02/24
/// 
/// Interface for management of UserGroup objects
/// </summary>
///
/// <remarks>
/// </remarks>
using DataStorageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IUserGroupManager
    {
        /// <summary>
        /// William Clark
        /// Created: 2021/02/24
        /// 
        /// Selects a List of UserGroups of which the UserAccount owns
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="userAccountID">The UserAccountID of the UserAccount for which to select all UserGroups of which the UserAccount owns</param>
        /// <exception cref="ApplicationException">No UserAccount found</exception>
        /// <returns>A List of UserGroup</returns>
        List<UserGroup> SelectOwnedUserGroupsByUserAccountID(int userAccountID);

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
        BindingList<UserAccount> GetUserAccountsInUserGroupByRole(IUserManager userManager, UserGroup group, String roleName);

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
        UserGroup GetUserGroupByGroupID(int groupID);

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
        /// <returns>A List of UserGroup</returns>
        List<UserAccount> GetUserAccountsByUserGroup(UserGroup group);


    }
}
