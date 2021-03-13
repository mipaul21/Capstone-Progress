/// <summary>
/// William Clark
/// Created: 2021/02/26
/// 
/// Test class for the UserGroupManager
/// </summary>
///
/// <remarks>
/// </remarks>
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataStorageModels;
using LogicLayer;
using LogicLayerInterfaces;
using DataAccessFakes;

namespace LogicLayerTests
{
    [TestClass]
    public class RoutineManagerTests
    {
        Routine arbitraryValidRoutine = new Routine("FirstRoutine", "First Routine", new DateTime(2021, 2, 26), 3, 1, true);
        IRoutineManager _routineManager;

        /// <summary>
        /// William Clark
        /// Created: 2021/02/26
        /// 
        /// TestIntialize method that initializes an IRoutineManager
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _routineManager = new RoutineManager(new RoutineFakes());
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/18
        /// 
        /// Tests GetRoutineStepsByRoutine method
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestMethod]
        public void TestGetRoutineStepsByRoutineReturnsRoutineStepList()
        {
            // Arrange
            int expectedResult = 3;
            List<RoutineStep> actualResult;

            // Act 
            actualResult = _routineManager.GetRoutineStepsByRoutine(arbitraryValidRoutine);

            // Assert
            Assert.AreEqual(expectedResult, actualResult.Count);
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        /// 
        /// Tests UpdateRoutine method
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestMethod]
        public void TestUpdateRoutineReturnsBool()
        {
            // Arrange
            bool expectedResult = true;
            bool actualResult;

            // Act
            actualResult = _routineManager.UpdateRoutine(arbitraryValidRoutine, new Routine("FirstRoutine", "A change has been made", new DateTime(2021, 2, 26), 3, 1, false));

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Tests SelectActiveRoutinesByUserAccountIDClient method
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestMethod]
        public void TestSelectActiveRoutinesByUserAccountIDClientReturnsList()
        {
            // Arrange
            List<Routine> expectedResult = new List<Routine>() {
                new Routine("FirstRoutine", "First Routine", new DateTime(2021, 2, 26), 3, 1, true)
            };
            List<Routine> actualResult = new List<Routine>();
            int validUserAccountID = 3;

            // Act
            actualResult = _routineManager.SelectActiveRoutinesByUserAccountIDClient(validUserAccountID);

            // Assert
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Tests CompleteRoutineStep method
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        [TestMethod]
        public void TestCompleteRoutineStepReturnsBool()
        {
            // Arrange
            bool expectedResult = true;
            bool actualResult;
            RoutineStep routineStep = new RoutineStep(1, "FirstRoutine", "FirstStep", "The First Step", new DateTime(2021, 2, 26), 1, true);

            // Act
            actualResult = _routineManager.CompleteRoutineStep(routineStep, new UserAccount(3, "Client", "Client", "Client", "client@Assisstability.com", true));

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
