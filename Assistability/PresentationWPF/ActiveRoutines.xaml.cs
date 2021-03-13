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
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ActiveRoutines.xaml
    /// </summary>
    public partial class ActiveRoutines : Page
    {
        private RoutineManager _routineManager;
        private UserAccountVM _user;
        private List<Routine> _routineList;

        public ActiveRoutines()
        {
            InitializeComponent();
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Constructs an ActiveRoutines page
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="routineManager">The RoutineManager Reference</param>
        /// <param name="selectedUser">The UserAccountVM for which to view active routines</param>
        public ActiveRoutines(RoutineManager routineManager, UserAccountVM selectedUser)
        {
            _routineManager = routineManager;
            _user = selectedUser;
            InitializeComponent();
            PopulateRoutineList();
        }

        private void PopulateRoutineList()
        {
            try
            {
                _routineList = _routineManager.SelectActiveRoutinesByUserAccountIDClient(_user.UserAccountID);
                dgActiveRoutines.ItemsSource = _routineList;
            }
            catch (Exception)
            {
                MessageBox.Show("Routines could not be found.");
            }
        }

        private void dgActiveRoutines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Routine routine = (Routine)dgActiveRoutines.SelectedItem;
            this.NavigationService.Navigate(new CompleteRoutine(_routineManager, routine, _user));
        }
    }
}
