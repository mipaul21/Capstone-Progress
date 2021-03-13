/// <summary>
/// William Clark
/// Created: 2021/02/24
/// 
/// Fake UserGroupAccessor for testing
/// </summary>
///
/// <remarks>
/// </remarks>
using DataAccessInterfaces;
using DataStorageModels;
using DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class UserGroupFakes : IUserGroupAccessor
    {
        private UserGroup fakeUserGroup = new UserGroup(1, 1);
        private Membership fakeMembership = new Membership(1, 1);
        private Role fakeRole = new Role(1, "Admin", "User Administrator");
        private List<MembershipVM> fakeMemberships;
        private List<Role> fakeRoles;
        public UserGroupFakes()
        {
            fakeRoles = new List<Role>()
            {
                fakeRole
            };
            fakeMemberships = new List<MembershipVM>()
            {
                new MembershipVM(fakeMembership, fakeRoles)
            };
        }

        public List<Role> SelectAllMembershipRolesByMembership(Membership membership)
        {
            return fakeRoles;
        }

        public List<MembershipVM> SelectAllMembershipsByUserAccountID(int userAccountID)
        {
            return fakeMemberships;
        }

        public List<UserGroup> SelectOwnedUserGroupsByUserAccountID(int userAccountID)
        {
            return new List<UserGroup> { fakeUserGroup };
        }


        public List<UserAccount> SelectUserAccountsByUserGroup(UserGroup group)
        {
            return new List<UserAccount>()
            {
                new UserAccount(1, "First", "Administrator", "firstAdmin", "first@administrator.com", true),
                new UserAccount(2, "Care", "Giver", "Caregiver", "caregiver@Assisstability.com", true),
                new UserAccount(3, "Client", "Client", "Client", "client@Assisstability.com", true)
            };
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
        public UserGroup SelectUserGroupByGroupID(int groupID)
        {
            return new UserGroup(1, 1);
        }
    }
}
