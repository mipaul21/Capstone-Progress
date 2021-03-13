/// <summary>
/// William Clark
/// Created: 2021/02/26
/// 
/// The Routine object class
/// </summary>
///
/// <remarks>
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorageModels
{
    public class RoutineStep
    {
        public int RoutineStepID { get; set; }
        public String RoutineName { get; set; }
        public String RoutineStepName { get; set; }
        public String RoutineStepDescription { get; set; }
        public DateTime RoutineStepEntryDate { get; private set; }
        public DateTime? RoutineStepEditDate { get; set; }
        public DateTime? RoutineStepRemovalDate { get; set; }
        public int StepOrderNumber { get; set; }
        public bool Active { get; set; }

        public RoutineStep(int routineStepID, string routineName, string routineStepName, string routineStepDescription, DateTime entryDate, int stepOrderNumber, bool active)
        {
            RoutineStepID = routineStepID;
            RoutineName = routineName;
            RoutineStepName = routineStepName;
            RoutineStepDescription = routineStepDescription;
            RoutineStepEntryDate = entryDate;
            StepOrderNumber = stepOrderNumber;
            Active = active;
        }

        public RoutineStep(int routineStepID, string routineName, string routineStepName, string routineStepDescription, DateTime entryDate, DateTime? editDate, DateTime? removalDate, int stepOrderNumber, bool active)
        {
            RoutineStepID = routineStepID;
            RoutineName = routineName;
            RoutineStepName = routineStepName;
            RoutineStepDescription = routineStepDescription;
            RoutineStepEntryDate = entryDate;
            RoutineStepEditDate = editDate;
            RoutineStepRemovalDate = removalDate;
            StepOrderNumber = stepOrderNumber;
            Active = active;
        }
    }
}
