/// <summary>
/// Nathaniel Webber
/// Created: 2021/02/05
/// 
/// This class is the 'fakes' class that I use
/// to test my code
/// </summary>
///
/// <remarks>
/// Nathaniel Webber
/// Updated: 2021/02/18
/// First MVP delivered
/// </remarks>
/// 
/// <remarks>
/// Ryan Taylor
/// Updated: 2021/03/06
/// Added InsertNewUserAccount fakes
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataStorageModels;
using DataViewModels;

namespace DataAccessFakes
{
    /// <summary>
    /// Nathaniel Webber
    /// Created: 2021/02/05
    /// 
    /// This class creates a 'fake' account to be used
    /// in the UserObjectTest class
    /// </summary>
    ///
    /// <remarks>
    /// Nathaniel Webber
    /// Updated: 2021/02/18 
    /// First MVP delivered
    /// </remarks>
    public class UserFakes : IUserAccessor
    {
        private UserAccount fakeAdmin = new UserAccount(1, "First", "Administrator", "firstAdmin", "first@administrator.com", true);
        
        private List<MembershipVM> fakeAdminMemberships = new List<MembershipVM>()
        {
            new MembershipVM(1, 1, new List<Role>()
            {
                new Role(1, "Admin", "User Administrator")
            })

        };

        private UserAccount fakeCaregiver = new UserAccount(2, "Care", "Giver", "Caregiver", "caregiver@Assisstability.com", true);

        private List<MembershipVM> fakeCaregiverMemberships = new List<MembershipVM>()
        {
            new MembershipVM(1, 1, new List<Role>()
            {
                new Role(1, "Caregiver", "Caregiver User")
            })

        };

        private UserAccount fakeClient = new UserAccount(3, "Client", "Client", "Client", "client@Assisstability.com", true);

        private List<MembershipVM> fakeClientMemberships = new List<MembershipVM>()
        {
            new MembershipVM(1, 1, new List<Role>()
            {
                new Role(1, "Client", "Client User")
            })

        };

        /// <summary>
        /// William Clark
        /// Created: 2021/02/18
        /// 
        /// Selects a UserAccount from the database with the matching UserAccountID field
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="userAccountID">The UserAccountID of the UserAccount to be selected</param>
        /// <exception>No UserAccount found</exception>
        /// <returns>A UserAccount object</returns>
        public UserAccount SelectUserAccountByUserAccountID(int userAccountID)
        {
            return fakeAdmin;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/04
        /// 
        /// Deletes a UserAccount from the database
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="userAccountID">The UserAccountID of the UserAccount to be deleted</param>
        /// <returns>1, indicating a UserAccount has been successfully deleted</returns>
        public int DeleteUserAccountByUserAccountID(int userAccountID)
        {
            if (userAccountID == fakeAdmin.UserAccountID)
            {
                return 1;
            }
            return 0;
        }


        public UserAccount SelectUserByUserName(string userName)
        {
            return fakeAdmin;
        }

        public int VerifyUserNameAndPassword(string userName, string passwordHash)
        {
            return passwordHash.ToUpper().Equals("9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E") ? 1 : 0;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        /// 
        /// Selects a UserAccountVM from the database from a UserAccount
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="user">The UserAccount of the UserAccountVM to be selected</param>
        /// <exception>No UserAccountVM found</exception>
        /// <returns>A UserAccountVM object</returns>
        public UserAccountVM SelectUserAccountVMByUserAccount(UserAccount user)
        {
            UserAccountVM result = null;
            List<UserAccountVM> users = new List<UserAccountVM>()
            {
                 new UserAccountVM(fakeAdmin, fakeAdminMemberships),
                 new UserAccountVM(fakeCaregiver, fakeCaregiverMemberships),
                 new UserAccountVM(fakeClient, fakeClientMemberships)
            };
            foreach (var useraccount in users)
            {
                if (useraccount.UserAccountID == user.UserAccountID)
                {
                    result = useraccount;
                }
            }
            return result;
        }

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/16/2021
        /// Approver: 
        /// 
        /// a fake data access method for testing UpdateUserAccount
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>
        public int UpdateUserAccount(UserAccount oldUserAccount, UserAccount newUserAccount)
        {
            int rows = 1;
            return rows;
        }

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/16/2021
        /// Approver: 
        /// 
        /// a fake data access method for testing DeactivateUserAccount
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>
        public int DeactivateUserAccount(int userAccountID)
        {
            int rows = 1;
            return rows;
        }

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/16/2021
        /// Approver: 
        /// 
        /// a fake data access method for testing Reactivate User Account.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>
        public int ReactivateUserAccount(int userAccountID)
        {
            int rows = 1;
            return rows;
        }
		
		public List<UserAccount> userAccounts = new List<UserAccount>();
        /// <summary>
        /// Ryan Taylor
        /// Created: 2021/02/05
        /// 
        /// a fake method for testing perposes.
        /// </summary>
        ///<param name="newUserAccount">
        ///The user account the 
        ///user has created
        ///</param>
        ///<param name="password">The users password</param>
        ///<exception></exception>
        ///<returns>the users userID</returns>
        public int InsertNewUserAccount(UserAccount
            newUserAccount, string password)
        {
            int startingAmount = userAccounts.Count;
            if (newUserAccount.FirstName != "")
            {
                newUserAccount.UserAccountID = userAccounts.Count + 1;
                userAccounts.Add(newUserAccount);
            }
            return newUserAccount.UserAccountID;
		}

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/16/2021
        /// Approver: 
        /// 
        /// a fake data access method for testing delete User Account
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>

        public int DeleteUserAccount(int userAccountID)
        {
            int rows = 1;
            return rows;
        }
    }
}
