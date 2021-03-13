/// <summary>
/// Nathaniel Webber
/// Created: 2021/03/08
/// 
/// This class has the methods that will be used
/// </summary>

using DataAccessFakes;
using DataAccessInterfaces;
using DataAccessLayer;
using DataStorageModels;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class AwardManager : IAwardManager
    {
        private IAwardAccessor _awardAccessor;

        public AwardManager()
        {
            // _awardAccessor = new AwardFake();
            _awardAccessor = new AwardAccessor();
        }

        public AwardManager(IAwardAccessor awardAccessor )
        {
            _awardAccessor = awardAccessor;
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// This method grabs the corresponding stored procedure from the sql
        /// and uses it to create an award in the database
        /// </summary>
        public int CreateAward(int userID, string awardName, string awardDescription)
        {
            int rowsAffected;

            try
            {
                rowsAffected = _awardAccessor.CreateNewAward(userID, awardName, awardDescription);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Award could not be created" + ex.InnerException);
            }

            return rowsAffected;
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// This method grabs the corresponding stored procedure from the sql
        /// and uses it to deactivate an award in the database
        /// </summary>
        public int DeactivateAwardByUserIDAndAwardName(int awardID)
        {
            int rowsAffected;

            try
            {
                rowsAffected = _awardAccessor.SafelyDeactivateAwardByAwardName(awardID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Award could not be Deactivated" + ex.InnerException);
            }

            return rowsAffected;
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// This method grabs the corresponding stored procedure from the sql
        /// and uses it to delete an award in the database
        /// </summary>
        public int DeleteAward(int awardID)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = _awardAccessor.DeleteAward(awardID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Award could not be deleted" + ex.InnerException);
            }

            return rowsAffected;
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// This method grabs the corresponding stored procedure from the sql
        /// and uses it to retreive all awards in the database
        /// </summary>
        public List<Award> RetreiveAllAwards(bool active = true)
        {
            List<Award> awards;

            try
            {
                awards = _awardAccessor.SelectAllAwards(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Awards not found" + ex.InnerException);
            }

            return awards;
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// This method grabs the corresponding stored procedure from the sql
        /// and uses it to retreive all of a specific users awards in the database
        /// </summary>
        public List<Award> RetreiveAwardByAwardID(int awardID)
        {
            List<Award> awards;

            try
            {
                awards = _awardAccessor.SelectAwardByAwardID(awardID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Awards not found" + ex.InnerException);
            }

            return awards;
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/11
        /// 
        /// This method grabs the corresponding stored procedure from the sql
        /// and uses it to retreive all of a specific awardName in the database
        /// </summary>
        public Award RetreiveAwardByUserIDAndAwardName(int userID, string awardName)
        {
            Award award;
            try
            {
                award = _awardAccessor.SelectAwardByUserIDAndAwardName(userID, awardName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Award not found" + ex.InnerException);
            }
            return award;
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// This method grabs the corresponding stored procedure from the sql
        /// and uses it to update an award in the database
        /// </summary>
        public int UpdateAward(Award newAward, Award oldAward)
        {
            int rowsAffected;

            try
            {
                rowsAffected = _awardAccessor.UpdateAward(newAward, oldAward);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Award could not be edited" + ex.InnerException);
            }

            return rowsAffected;
        }
    }
}
