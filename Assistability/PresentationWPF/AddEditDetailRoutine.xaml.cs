/// <summary>
/// William Clark
/// Created: 2021/02/18
///
/// Interface for viewing of Routines
/// </summary>
///
/// <remarks>
/// </remarks>
using DataAccessFakes;
using DataAccessLayer;
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
    /// Interaction logic for AddEditDetailRoutine.xaml
    /// </summary>
    public partial class AddEditDetailRoutine : Page
    {
        private RoutineVM _routine;
        private IRoutineManager _routineManager;

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        ///
        /// Constructer that accepts an IRoutineManager and a RoutineVM
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// <param name="routineManager">The IRoutineManager Logic Layer class</param>
        /// <param name="selectedRoutine">The RoutineVM for which to view details</param>
        public AddEditDetailRoutine(IRoutineManager routineManager, RoutineVM selectedRoutine)
        {
            _routine = selectedRoutine;
            _routineManager = routineManager;

            InitializeComponent();
        }


        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        ///
        /// On page load, populate form
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void Page_Initialized(object sender, EventArgs e)
        {
            PopulatePage();
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        ///
        /// Populates the form with the Routine data
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void PopulatePage()
        {
            txtRoutineName.Text = _routine.Name;
            txtRoutineName.IsReadOnly = true;
            txtRoutineDescription.Text = _routine.Description;
            txtRoutineDescription.IsReadOnly = true;
            btnEditRoutineDescription.Visibility = Visibility.Visible;
            txtEntryDate.Text = _routine.EntryDate.ToString();
            if (_routine.EditDate != null)
            {
                lblEditDate.Visibility = Visibility.Visible;
                txtEditDate.Visibility = Visibility.Visible;
                txtEditDate.Text = _routine.EditDate.ToString();
            }
            else
            {
                lblEditDate.Visibility = Visibility.Hidden;
                txtEditDate.Visibility = Visibility.Hidden;
            }
            if (_routine.RemovalDate != null)
            {
                lblRemovalDate.Visibility = Visibility.Visible;
                txtRemovalDate.Visibility = Visibility.Visible;
                txtRemovalDate.Text = _routine.RemovalDate.ToString();
            }
            else
            {
                lblRemovalDate.Visibility = Visibility.Hidden;
                txtRemovalDate.Visibility = Visibility.Hidden;
            }
            btnActive.Visibility = Visibility.Hidden;
            btnSaveRoutineDescription.Visibility = Visibility.Hidden;
            ShowDeactivateReactivateButton(_routine.Active);

            RefreshRoutineSteps();


        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        ///
        /// Refreshes the Routines RoutineSteps list
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void RefreshRoutineSteps()
        {
            try
            {
                dgRoutineSteps.ItemsSource = _routine.Steps;
            }
            catch (Exception)
            {
                MessageBox.Show("The Steps of the routine could not be loaded.");
            }
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        ///
        /// Shows the Deactivate/Reactivate button depending on the Active status of the Routine
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void ShowDeactivateReactivateButton(bool active)
        {
            if (active)
            {
                btnActive.Visibility = Visibility.Visible;
                btnActive.Content = "Deactivate";
            }
            else
            {
                btnActive.Visibility = Visibility.Visible;
                btnActive.Content = "Reactivate";
            }
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        ///
        /// Updates interface to allow updating of Routine Description
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void btnEditRoutineDescription_Click(object sender, RoutedEventArgs e)
        {
            txtRoutineDescription.IsReadOnly = false;
            btnSaveRoutineDescription.Visibility = Visibility.Visible;
            btnEditRoutineDescription.Visibility = Visibility.Hidden;
            txtRoutineDescription.Clear();
            txtRoutineDescription.Focus();
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        ///
        /// Updates the current routine in the data store, then udpates the interface to reflect the changes
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void btnSaveRoutineDescription_Click(object sender, RoutedEventArgs e)
        {
            Routine newRoutine = new Routine(txtRoutineName.Text, txtRoutineDescription.Text, _routine.UserAccountID_Client, _routine.UserAccountID_Admin, _routine.Active, _routine.EntryDate, DateTime.Now, null);

            try
            {
                if (_routineManager.UpdateRoutine(_routine, newRoutine))
                {
                    try
                    {
                        _routine = new RoutineVM(newRoutine, _routineManager.GetRoutineStepsByRoutine(newRoutine));

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The Steps of the routine could not be loaded.");
                    }

                }
                else
                {
                    MessageBox.Show("The Routine could not be updated.");
                }
                PopulatePage();
            }
            catch (Exception)
            {
                MessageBox.Show("The routine could not be updated.");
            }
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/04
        ///
        /// Deactivates/Reactivates Routine in the data store
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void btnActive_Click(object sender, RoutedEventArgs e)
        {

            switch (btnActive.Content)
            {
                case "Deactivate":
                    try
                    {
                        Routine newRoutine = new Routine(txtRoutineName.Text, txtRoutineDescription.Text, _routine.UserAccountID_Client, _routine.UserAccountID_Admin, false, _routine.EntryDate, _routine.EditDate, DateTime.Now);
                        _routine = new RoutineVM(newRoutine, _routineManager.GetRoutineStepsByRoutine(newRoutine));
                        PopulatePage();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Routine could not be deactivated.");
                    }
                    break;
                case "Reactivate":
                    try
                    {
                        Routine newRoutine = new Routine(txtRoutineName.Text, txtRoutineDescription.Text, _routine.UserAccountID_Client, _routine.UserAccountID_Admin, false, _routine.EntryDate, _routine.EditDate, DateTime.Now);
                        _routine = new RoutineVM(newRoutine, _routineManager.GetRoutineStepsByRoutine(newRoutine));
                        PopulatePage();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Routine could not be reactivated.");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
