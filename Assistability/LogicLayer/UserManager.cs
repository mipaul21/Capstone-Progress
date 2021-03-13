/// <summary>
/// Nathaniel Webber
/// Created: 2021/02/05
/// 
/// Implements the User Manager interface
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccessFakes;
using DataAccessInterfaces;
using DataAccessLayer;
using DataStorageModels;
using DataViewModels;
using LogicLayerInterfaces;

namespace LogicLayer
{
    public class UserManager : IUserManager
    {
        private IUserAccessor _userAccessor = null;

        /// <summary>
        /// William Clark
        /// Created: 2021/02/18
        /// 
        /// Default constructor initializes an accessor
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        public UserManager()
        {
            //_userAccessor = new UserFakes();
            _userAccessor = new UserAccessor();
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/18
        /// 
        /// Takes an IUserAccountAccessor and constructs a UserAccountManager with the specified accessor
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// /// 
        /// <param name="userAccountAccessor">The IUserAccountAccessor to be used as the accessor by this instance</param>
        public UserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/02/05
        /// 
        /// This method grabs the corresponding stored procedure from the sql
        /// and uses it to validate a user login
        /// </summary>
        ///
        /// <remarks>
        /// Nathaniel Webber
        /// Updated: 2021/02/18 
        /// First MVP delivered
        /// </remarks>
        public UserAccount AuthenticateUser(string username, string password)
        {
            UserAccount user = null;

            password = hashSHA256(password);

            try
            {
                if (1 == _userAccessor.VerifyUserNameAndPassword(username, password))
                {
                    user = _userAccessor.SelectUserByUserName(username);
                }
                else
                {
                    throw new ApplicationException("Bad Username or Password");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login Failed", ex);
            }

            return user;
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/02/05
        /// 
        /// This method allows for the translation of Hashed passwords
        /// </summary>
        ///
        /// <remarks>
        /// Nathaniel Webber
        /// Updated: 2021/02/18 
        /// First MVP delivered
        /// </remarks>
        private string hashSHA256(string password)
        {
            string result = "";

            // Create a byte array - cryptography is byte oriented
            byte[] data;

            // Create a .NET hash provider object
            using (SHA256 sha256hash = SHA256.Create())
            {
                // Hash the source
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            // Now to build the result string
            var s = new StringBuilder();

            // Loop through the byte array
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // Convert the string builder to a string
            result = s.ToString();

            return result;
        }

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
        public UserAccount GetUserAccountByUserAccountID(int userAccountID)
        {
            UserAccount userAccount;
            try
            {
                userAccount = _userAccessor.SelectUserAccountByUserAccountID(userAccountID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("User not found" + ex.InnerException);
            }
            return userAccount;
        }

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
        public UserAccountVM GetUserAccountVMByUserAccount(UserAccount user)
        {
            UserAccountVM userAccountVM;
            try
            {
                userAccountVM = _userAccessor.SelectUserAccountVMByUserAccount(user);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("User view model could not be created" + ex.InnerException.Message);
            }
            return userAccountVM;
        }

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/16/2021
        /// Approver: 
        /// 
        /// Manager method to Update the User Account while also implementing Reactivate and Deactivate user account if
        /// those options are chosen through the edit interface.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public bool UpdateUserAccount(UserAccount oldUserAccount, UserAccount newUserAccount)
        {
            bool result = false;
            try
            {
                result = (1 == _userAccessor.UpdateUserAccount(oldUserAccount, newUserAccount));


                if (result == false)
                {
                    throw new ApplicationException("Data not updated.");
                }
            
                if (oldUserAccount.Active != newUserAccount.Active)
            {
                if (newUserAccount.Active)
                {
                    _userAccessor.ReactivateUserAccount(oldUserAccount.UserAccountID);
                }
                else
                {
                    if (_userAccessor.DeactivateUserAccount(oldUserAccount.UserAccountID) != 1)
                    {
                        throw new ApplicationException("The user could not be deactivated.");
                    }
                }
            }
        }
            
        
            catch (Exception ex)
            {
                throw new ApplicationException("User Account not updated.", ex);
            }
            return result;

        }

        /// <summary>
        /// Ryan Taylor
        /// Created: 2021/02/05
        /// 
        /// This method helps make sure a new user account is 
        /// passed into the data base.
        /// </summary>
        /// 
        ///<param name="newUserAccount">The newly created user account</param>
        ///<param name="password">The pasword for that user account</param>
        ///<exception></exception>
        ///<returns>A list of Journal Entries for the journal</returns>
        public bool AddNewUserAccount(UserAccount newUserAccount, string password)
        {
            password = password.SHA256Value();
            bool result = false;
            int NewUserID = 0;
            try
            {
                NewUserID = _userAccessor.InsertNewUserAccount(newUserAccount, password);
                if (NewUserID == 0)
                {
                    throw new ApplicationException("New user account was not added.");
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Adding New User Account Faild.", ex);
            }   
			return result;
        }
		
        /// Creator: Mitchell Paul
        /// Created: 3/10/2021
        /// Approver: 
        /// 
        /// Manager method to Delete the User Account.
        /// 
        /// Right now this is dependent upon if the account is active. Eventually this will depend on roles.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public bool DeleteUserAccount(UserAccount userAccount)
        {
            bool result = false;

            if (userAccount.Active == false)
                try
                {
                    result = (1 == _userAccessor.DeleteUserAccount(userAccount.UserAccountID));

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("User Account not deleted. No roles can be assigned.", ex);
                }
            return result;
        }
    }
}
