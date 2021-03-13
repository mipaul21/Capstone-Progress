/// <summary>
/// Nathaniel Webber
/// Created: 2021/02/05
/// 
/// This is an interface for the management
/// of the users data
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
/// Added AddNewUserAccount
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStorageModels;
using DataViewModels;

namespace LogicLayerInterfaces
{
    
    public interface IUserManager
    {
        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/02/05
        /// 
        /// Describes what parameters are needed to authenticate 
        /// a user login
        /// </summary>
        ///
        /// <remarks>
        /// Nathaniel Webber
        /// Updated: 2021/02/18 
        /// First MVP delivered
        /// </remarks>
        UserAccount AuthenticateUser(string username, string password);

        /// <summary>
        /// William Clark
        /// Created: 2021/02/18
        /// 
        /// Selects a UserAccount from the accessor with the matching UserAccountID
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="userAccountID">The UserAccountID of the UserAccount to be selected</param>
        /// <exception cref="ApplicationException">No UserAccount found</exception>
        /// <returns>A UserAccount object</returns>
        UserAccount GetUserAccountByUserAccountID(int userAccountID);

        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        /// 
        /// Selects a UserAccountVM from the accessor with the matching UserAccount
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="user">The UserAccount of the UserAccountVM to be selected</param>
        /// <exception cref="ApplicationException">No UserAccount found</exception>
        /// <returns>A UserAccountVM object</returns>
        UserAccountVM GetUserAccountVMByUserAccount(UserAccount user);


        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/16/2021
        /// Approver: 
        /// 
        /// Logic layer method in order to update a user account. 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        bool UpdateUserAccount(UserAccount oldUserAccount, UserAccount newUserAccount);

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 3/10/2021
        /// Approver: 
        /// 
        /// Logic layer method in order to delete a user account.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        bool DeleteUserAccount(UserAccount userAccount);

        /// <summary>
        /// Ryan Taylor
        /// Created: 2021/02/05
        /// 
        /// An abstract method for adding a user account
        /// </summary>
        /// 
        ///<param name="newUserAccount">The newly created user account</param>
        ///<param name="password">The user accounts password</param>
        ///<exception></exception>
        ///<returns>A bool signifying if the account was created</returns>
        bool AddNewUserAccount(UserAccount newUserAccount, string password);
    }
}
