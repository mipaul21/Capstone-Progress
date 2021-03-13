/// <summary>
/// Nathaniel Webber
/// Created: 2021/03/08
/// 
/// This interface has the methods that will be
/// used in the AwardAccessor class
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStorageModels;

namespace DataAccessInterfaces
{
    public interface IAwardAccessor
    {
        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// Creates a new award
        /// </summary>
        /// 
        /// <param name="userID"> The UserID of the user who creates the award</param>
        /// <param name="awardName"> The name of the Award being created</param>
        /// <param name="awardDescription"> The description of the Award being created</param>
        /// <param name="goalID"> the GoalID of the type of goal the award is set to</param>
        /// <exception>No Award found</exception>
        /// <returns>A List of Award objects</returns>
        int CreateNewAward(int userID, string awardName, string awardDescription);

        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// Selects an award by userID
        /// </summary>
        /// 
        /// <param name="userID"> The UserID of the user whose awards I'm viewing</param>
        /// <exception>No Award found</exception>
        /// <returns>A List of Award objects</returns>
        List<Award> SelectAwardByAwardID(int awardID);

        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// Selects all awards
        /// </summary>
        /// 
        /// <exception>No Award found</exception>
        /// <returns>A List of Award objects</returns>
        List<Award> SelectAllAwards(bool active = true);

        /// Nathaniel Webber
        /// Created: 2021/03/11
        /// 
        /// Selects award by awardName
        /// </summary>
        /// 
        /// <exception>No Award found</exception>
        /// <returns>An Award object</returns>
        Award SelectAwardByUserIDAndAwardName(int userID, string awardName);

        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// Updates an award
        /// </summary>
        /// 
        /// <param name="newAward"> The new, edited award</param>
        /// <param name="oldAward"> The oldAward record</param>
        /// <exception>No Award found</exception>
        /// <returns>Rows affected</returns>
        int UpdateAward(Award newAward, Award oldAward);

        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// Safely deactivates an award
        /// </summary>
        /// 
        /// <param name="userID"> The UserID of the user whose award will be deactivated</param>
        /// <param name="awardName"> The name of the award to be deactivated</param>
        /// <exception>No Award found</exception>
        /// <returns>Rows affected</returns>
        int SafelyDeactivateAwardByAwardName(int awardID);

        /// Nathaniel Webber
        /// Created: 2021/03/08
        /// 
        /// Safely deletes an award
        /// </summary>
        /// 
        /// <param name="userID"> The UserID of the user whose award will be deleted</param>
        /// <param name="awardName"> The name of the award to be deleted</param>
        /// <exception>No Award found</exception>
        /// <returns>Rows affected</returns>
        int DeleteAward(int awardID);
    }
}
