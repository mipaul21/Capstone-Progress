/// Nathaniel Webber
/// Created: 2021/03/08
/// All necessary Fakes for testing 
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
    public class AwardFake : IAwardAccessor
    {
        int rowsAffected;
        private List<Award> fakeAward = new List<Award>();
        private Award fakeSingleAward = new Award();

        public AwardFake()
        {
            fakeAward.Add(new Award() 
            { 
                AwardID = 1,
                AwardName = "Fake Award 1",
                AwardDescription = "Fake Award Description 1",
                GoalID = 1,
                GoalTypeID = 1
            });

            fakeAward.Add(new Award()
            {
                AwardID = 2,
                AwardName = "Fake Award 2",
                AwardDescription = "Fake Award Description 2",
                GoalID = 1,
                GoalTypeID = 1
            });

            fakeAward.Add(new Award()
            {
                AwardID = 3,
                AwardName = "Fake Award 3",
                AwardDescription = "Fake Award Description 3",
                GoalID = 2,
                GoalTypeID = 1
            });

            fakeAward.Add(new Award()
            {
                AwardID = 4,
                AwardName = "Fake Award 4",
                AwardDescription = "Fake Award Description 4",
                GoalID = 2,
                GoalTypeID = 2
            });

            fakeSingleAward.AwardID = 1;
            fakeSingleAward.AwardName = "Fake Award 1";
            fakeSingleAward.AwardDescription = "Fake Award Description 1";
            fakeSingleAward.GoalID = 1;
            fakeSingleAward.GoalTypeID = 1;

        }

        public int CreateNewAward(int userID, string awardName, string awardDescription)
        {
            return rowsAffected;
        }

        public int DeleteAward(int awardID)
        {
            return rowsAffected;
        }

        public int SafelyDeactivateAwardByAwardName(int awardID)
        {
            return rowsAffected;
        }

        public List<Award> SelectAllAwards(bool active = true)
        {
            return this.fakeAward;
        }

        public List<Award> SelectAwardByAwardID(int awardID)
        {
            return this.fakeAward;
        }

        public Award SelectAwardByUserIDAndAwardName(int userID, string awardName)
        {
            return fakeSingleAward;
        }

        public int UpdateAward(Award newAward, Award oldAward)
        {
            return rowsAffected;
        }
    }
}
