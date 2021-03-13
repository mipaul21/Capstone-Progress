/// <summary>
/// William Clark
/// Created: 2021/02/24
/// 
/// Interface to be used to complete routines
/// </summary>
///
/// <remarks>
/// </remarks>
using DataStorageModels;
using DataViewModels;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationWPF
{
    /// <summary>
    /// Interaction logic for CompleteRoutine.xaml
    /// </summary>
    public partial class CompleteRoutine : Page
    {
        private RoutineVM _routine;
        private IRoutineManager _routineManager;
        private int _currentRoutineStep;
        private UserAccount _user;

        public CompleteRoutine()
        {
            InitializeComponent();
            lblRoutineName.Content = _routine.Name;
            lblRoutineDescription.Content = _routine.Description;
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/24
        /// 
        /// Constructs an CompleteRoutine
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="routineManager">The RoutineManager Reference</param>
        /// <param name="routine">The Routine to be completed</param>
        /// <param name="user">The UserAccount which will complete the Routine</param>
        public CompleteRoutine(IRoutineManager routineManager, Routine routine, UserAccount user)
        {
            this._routineManager = routineManager;
            this._user = user;
            try
            {
                this._routine = new RoutineVM(routine, _routineManager.GetRoutineStepsByRoutine(routine));
            }
            catch (Exception)
            {
                MessageBox.Show("The Routine steps could not be loaded.");
            }
            _currentRoutineStep = 0;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lblRoutineName.Content = _routine.Name;
            lblRoutineDescription.Content = _routine.Description;
            UpdateRoutineStepInformation();
        }

        private void UpdateRoutineStepInformation()
        {
            lblRoutineStepName.Content = _routine.Steps[_currentRoutineStep].RoutineStepName;
            lblRoutineStepDescription.Content = _routine.Steps[_currentRoutineStep].RoutineStepDescription;
        }

        private void btnCompleteStep_Click(object sender, RoutedEventArgs e)
        {
            if ((_currentRoutineStep + 1) == _routine.Steps.Count())
            {
                // Handle completing the routine
            }
            else
            {
                if (_routineManager.CompleteRoutineStep(_routine.Steps[_currentRoutineStep], _user))
                {
                    // Handle moving to the next step
                    _currentRoutineStep++;
                    UpdateRoutineStepInformation();
                }
            }
        }
    }
}
