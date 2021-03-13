/// <summary>
/// William Clark
/// Created: 2021/02/24
/// 
/// Interface for management of UserGroup objects
/// </summary>
///
/// <remarks>
/// </remarks>
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
    public class RoutineManager : IRoutineManager
    {
        private IRoutineAccessor _routineAccessor;

        public RoutineManager()
        {
            _routineAccessor = new RoutineAccessor();
        }

        public RoutineManager(IRoutineAccessor routineAccessor)
        {
            this._routineAccessor = routineAccessor;
        }

        

        /// <summary>
        /// William Clark
        /// Created: 2021/02/26
        /// 
        /// Selects a List of RoutineSteps of which the Routine is composed
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="routine">The Routine for which to select all RoutineSteps</param>
        /// <exception cref="ApplicationException">No RoutineSteps found</exception>
        /// <returns>A List of RoutineStep</returns>
        public List<RoutineStep> GetRoutineStepsByRoutine(Routine routine)
        {
            List<RoutineStep> routineSteps = new List<RoutineStep>();
            try
            {
                routineSteps = _routineAccessor.SelectRoutineStepsByRoutine(routine);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Routine Steps could not be found" + ex.InnerException.Message);
            }
            return routineSteps;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        /// 
        /// Updates a specific Routine
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="oldRoutine">The Routine to update</param>
        /// <param name="newRoutine">The New Routine</param>
        /// <exception cref="ApplicationException">Routine could not be udpated</exception>
        /// <returns>If the routine was successfully updated</returns>
        public bool UpdateRoutine(Routine oldRoutine, Routine newRoutine)
        {
            bool result = false;
            try
            {
                result = _routineAccessor.UpdateRoutine(oldRoutine, newRoutine);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Routine could not be updated." + ex.InnerException.Message);
            }
            return result;
        }


        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Selects all active routines for a UserAccount listed as the Client
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="userAccountID">The UserAccountId of the client</param>
        /// <exception cref="ApplicationException">Routines could not be found</exception>
        /// <returns>A list of Routines</returns>
        public List<Routine> SelectActiveRoutinesByUserAccountIDClient(int userAccountID)
        {
            List<Routine> routines = null;
            try
            {
                routines = _routineAccessor.SelectActiveRoutinesByUserAccountIDClient(userAccountID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Routines could not be found" + ex.InnerException.Message);
            }
            return routines;
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
        /// <param name="userAccount">The User who has completed the routine step</param>
        /// <exception cref="ApplicationException">RoutineStep could not be completed</exception>
        /// <returns>True if completion stored</returns>
        public bool CompleteRoutineStep(RoutineStep routineStep, UserAccount userAccount)
        {
            bool result = false;
            try
            {
                result = _routineAccessor.CreateRoutineStepCompletion(routineStep, userAccount);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Routine step could not be completed" + ex.InnerException.Message);
            }
            return result;
        }
    }
}
