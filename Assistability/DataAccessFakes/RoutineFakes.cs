/// <summary>
/// William Clark
/// Created: 2021/02/26
/// 
/// Fake UserGroupAccessor for testing
/// </summary>
///
/// <remarks>
/// </remarks>
using DataAccessInterfaces;
using DataStorageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class RoutineFakes : IRoutineAccessor
    {
        private Routine fakeRoutine = new Routine("FirstRoutine", "First Routine", new DateTime(2021, 2, 26), 3, 1, true);
        private RoutineStep fakeRoutineStep1 = new RoutineStep(1, "FirstRoutine", "FirstStep", "The First Step", new DateTime(2021, 2, 26), 1, true);
        private RoutineStep fakeRoutineStep2 = new RoutineStep(2, "FirstRoutine", "SecondStep", "The Second Step", new DateTime(2021, 2, 26), 2, true);
        private RoutineStep fakeRoutineStep3 = new RoutineStep(3, "FirstRoutine", "ThirdStep", "The Third Step", new DateTime(2021, 2, 26), 3, true);

        public List<Routine> SelectActiveRoutinesByUserAccountIDClient(int userAccountID)
        {
            return new List<Routine>() {
                new Routine("FirstRoutine", "First Routine", new DateTime(2021, 2, 26), 3, 1, true)
            };
        }
        public List<RoutineStep> SelectRoutineStepsByRoutine(Routine routine)
        {
            List<RoutineStep> steps = new List<RoutineStep>();
            steps.Add(fakeRoutineStep1);
            steps.Add(fakeRoutineStep2);
            steps.Add(fakeRoutineStep3);
            return steps;
        }

        public bool UpdateRoutine(Routine oldRoutine, Routine newRoutine)
        {
            bool result = false;
            if (oldRoutine.Name == "FirstRoutine")
            {
                fakeRoutine.Description = newRoutine.Description;
                fakeRoutine.EditDate = newRoutine.EditDate;
                fakeRoutine.Active = newRoutine.Active;
                if (!fakeRoutine.Active)
                {
                    fakeRoutine.RemovalDate = DateTime.Now;
                }
                result = true;
            }
            return result;
        }


        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Creates a RoutineStepCompletion
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="routineStep">The RoutineStep to complete</param>
        /// <param name="userAccount">The User who completed the step</param>
        /// <exception cref="ApplicationException">RoutineStep could not be completed</exception>
        /// <returns>True if completion stored</returns>
        public bool CreateRoutineStepCompletion(RoutineStep routineStep, UserAccount userAccount)
        {
            return routineStep.StepOrderNumber < 4;
        }
    }
}
