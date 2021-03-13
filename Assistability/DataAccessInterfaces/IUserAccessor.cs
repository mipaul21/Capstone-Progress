/// <summary>
/// Nathaniel Webber
/// Created: 2021/02/05
/// 
/// This is an interface for data access of the users
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
/// Added InsertNewUserAccount
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStorageModels;
using DataViewModels;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Nathaniel Webber
    /// Created: 2021/02/05
    /// 
    /// This interface has the methods that will be
    /// used in the UserAccessor class
    /// </summary>
    ///
    /// <remarks>
    /// Nathaniel Webber
    /// Updated: 2021/02/18 
    /// First MVP delivered
    /// </remarks>
    public interface IUserAccessor
    {
        UserAccount SelectUserByUserName(string userName);
        int VerifyUserNameAndPassword(string userName, string passwordHash);

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
        UserAccount SelectUserAccountByUserAccountID(int userAccountID);

        
        UserAccountVM SelectUserAccountVMByUserAccount(UserAccount user);


        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/03/2021
        /// Approver: 
        /// 
        /// a data access method for updating an account
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>
        int UpdateUserAccount(UserAccount oldUserAccount, UserAccount newUserAccount);

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/23/2021
        /// Approver: 
        /// 
        /// a data access method for deactivating an account
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>
        /// 
        int DeactivateUserAccount(int userAccountID);

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/23/2021
        /// Approver: 
        /// 
        /// a data access method for reactivating an account
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>
        /// 
        int ReactivateUserAccount(int userAccountID);
		
		/// <summary>
        /// Ryan Taylor
        /// Created: 2021/02/05
        /// 
        /// an abstract method to support UserAccountAccessor in 
        /// creating a new user account.
        /// </summary>
        /// 
        ///<param name="newUserAccount">The newly crated account</param>
        ///<param name="password">the accounts password</param>
        ///<exception></exception>
        ///<returns>int userID</returns>
        int InsertNewUserAccount(UserAccount newUserAccount, string password);

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/23/2021
        /// Approver: 
        /// 
        /// a data access method for safely deleting a UserAccount with no roles
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>an int</returns>
        /// 
        int DeleteUserAccount(int userAccountID);



    }
}
