/// <summary>
/// William Clark
/// Created: 2021/02/26
/// 
/// Interface for management of Routine objects
/// </summary>
///
/// <remarks>
/// </remarks>
using DataStorageModels;
using DataViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface IRoutineManager
    {

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
        List<RoutineStep> GetRoutineStepsByRoutine(Routine routine);

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
        bool UpdateRoutine(Routine oldRoutine, Routine newRoutine);

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
        List<Routine> SelectActiveRoutinesByUserAccountIDClient(int userAccountID);

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
        bool CompleteRoutineStep(RoutineStep routineStep, UserAccount userAccount);
    }
}
