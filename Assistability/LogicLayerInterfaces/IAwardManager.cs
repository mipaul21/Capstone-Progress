/// Nathaniel Webber
/// Updated: 2021/03/08
/// All necessary functions for the Award Object
/// </remarks>

using DataStorageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IAwardManager
    {
        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// This method will allow the user to create a new award
        /// </summary>
        /// <param name="userID">The UserID of the User who created this Award</param>
        /// <param name="awardName">The Name of this Award</param>
        /// <param name="awardDescription">The Description of this Award</param>
        /// <exception>No Award created</exception>
        /// <returns>Count of rows affected</returns>
        int CreateAward(int userID, string awardName, string awardDescription);

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// This is the interface of the method that will grab every Award in the Database, 
        /// which will require a UserID.
        /// </summary>
        /// <param name="userID">The UserID of the User who created this Award</param>
        /// <exception>No Award created</exception>
        /// <returns>Count of rows affected</returns>
        List<Award> RetreiveAwardByAwardID(int awardID);

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/11
        /// 
        /// This is the interface of the method that will grab a specific Award in the Database
        /// </summary>
        /// <param name="userID">The UserID of the User who created this Award</param>
        /// <param name="awardName">The name of the award the user created</param>
        /// <exception>No Award found</exception>
        /// <returns>Count of rows affected</returns>
        Award RetreiveAwardByUserIDAndAwardName(int userID, string awardName);

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// This is the interface of the method that will grab every Award in the Database, 
        /// that is attached to the account.
        /// </summary>
        /// <exception>No Award created</exception>
        /// <returns>Count of rows affected</returns>
        List<Award> RetreiveAllAwards(bool active = true);

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// This method will update an Award
        /// </summary>
        /// <param name="newAward">The newly edited Award</param>
        /// <param name="oldAward">The old award of this Award</param>
        /// <exception>Could not Edit</exception>
        /// <returns>Count of rows affected</returns>
        int UpdateAward(Award newAward, Award oldAward);

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// This method will deactivate an Award no longer in use
        /// </summary>
        /// <param name="userID">The UserID of the User who created this Award</param>
        /// <param name="awardName">The Name of this Award</param>
        /// <exception>No Award deactivated</exception>
        /// <returns>Count of rows affected</returns>
        int DeactivateAwardByUserIDAndAwardName(int awardID);

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// This method will delete an Award no longer in use
        /// </summary>
        /// <param name="userID">The UserID of the User who created this Award</param>
        /// <param name="awardName">The Name of this Award</param>
        /// <exception>No Award deleted</exception>
        /// <returns>Count of rows affected</returns>
        int DeleteAward(int awardID);
    }
}
