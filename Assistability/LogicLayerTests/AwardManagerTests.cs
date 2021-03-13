/// <summary>
/// Nathaniel Webber
/// Created: 2021/03/09
/// 
/// This is the Class containing the Award Manager Test methods
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessFakes;
using DataAccessInterfaces;
using DataStorageModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    [TestClass]
    public class AwardManagerTests
    {
        IAwardAccessor awardAccessor;

        [TestInitialize]
        public void setUp()
        {
            awardAccessor = new AwardFake();
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/09
        /// 
        /// This tests the CreateAward Method
        /// </summary>
        [TestMethod]
        public void TestCreateAward()
        {
            // Arrange
            int userID = 1;
            int awardID = 5;
            string awardName = "Test Award";
            string awardDescription = "Test Description";
            int goalID = 3;
            int goalTypeID = 3;

            // Act
            int createAward = awardAccessor.CreateNewAward(userID, awardName, awardDescription);

            // Assert
            Assert.IsTrue(createAward == 0);
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/09
        /// 
        /// This tests the RetreiveAwardByAwardID method
        /// </summary>
        [TestMethod]
        public void TestRetreiveAwardByAwardID()
        {
            // Arrange
            int awardID = 1;
            const int expectedCount = 4;
            int actualCount;
            List<Award> award;

            // Act
            award = awardAccessor.SelectAwardByAwardID(awardID);
            actualCount = award.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/09
        /// 
        /// This tests the RetreiveAllAwards method
        /// </summary>
        [TestMethod]
        public void TestRetreiveAllAwards()
        {
            // Arrange
            const int expectedCount = 4;
            int actualCount;
            List<Award> award;

            // Act
            award = awardAccessor.SelectAllAwards();
            actualCount = award.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/09
        /// 
        /// This tests the UpdateAward method
        /// </summary>
        [TestMethod]
        public void TestUpdateAward()
        {
            // Arrange
            Award newAward = new Award
            {
                AwardID = 2,
                AwardName = "Test Award",
                AwardDescription = "Test Description",
                GoalID = 2,
                GoalTypeID = 2
            };
            Award oldAward = new Award
            {
                AwardID = 2,
                AwardName = "Rewritten Test Award",
                AwardDescription = "Test Description",
                GoalID = 2,
                GoalTypeID = 2
            };

            // Act
            int changed = awardAccessor.UpdateAward(newAward, oldAward);

            // Assert
            Assert.IsTrue(changed == 0);
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/09
        /// 
        /// This tests the SafelyDeactivateAward method
        /// </summary>
        [TestMethod]
        public void TestDeactivateAward()
        {
            // Arrange
            Award newAward = new Award
            {
                AwardID = 2,
                AwardName = "Test Award",
                AwardDescription = "Test Description",
                GoalID = 2,
                GoalTypeID = 2,
                Active = true
            };

            // Act
            int deactivated = awardAccessor.SafelyDeactivateAwardByAwardName(2);

            // Assert
            Assert.IsTrue(deactivated == 0);
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/09
        /// 
        /// This tests the DeleteAward method
        /// </summary>
        [TestMethod]
        public void TestDeleteAward()
        {
            // Arrange
            Award newAward = new Award
            {
                AwardID = 2,
                AwardName = "Test Award",
                AwardDescription = "Test Description",
                GoalID = 2,
                GoalTypeID = 2,
                Active = true
            };

            // Act
            int delete = awardAccessor.DeleteAward(2);

            // Assert
            Assert.IsTrue(delete == 0);
        }
    }
}
