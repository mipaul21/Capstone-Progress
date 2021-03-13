/// <summary>
/// William Clark
/// Created: 2021/02/26
///
/// Interface to view UserGroup members
/// </summary>
///
/// <remarks>
/// </remarks>
using DataAccessFakes;
using DataAccessLayer;
using DataStorageModels;
using DataViewModels;
using LogicLayer;
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
    /// Interaction logic for UserGroupMemberEditDetail.xaml
    /// </summary>
    public partial class UserGroupMemberEditDetail : Page
    {
        private UserAccountVM _selectedUser;

        /// <summary>
        /// William Clark
        /// Created: 2021/02/26
        ///
        /// Constructor that accepts a UserAccount
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        ///
        /// <param name="selectedUser">The UserAccountVM for which to view active routines</param>
        public UserGroupMemberEditDetail(UserAccountVM selectedUser)
        {
            _selectedUser = selectedUser;
            InitializeComponent();
            lblUserGroupMemberName.Content = _selectedUser.FirstName + " " + _selectedUser.LastName;
        }

        private void btnCompleteRoutines_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new ActiveRoutines(new RoutineManager(new RoutineAccessor()), _selectedUser));
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/26
        ///
        /// Event Handler to view all routines for a UserAccount
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void btnViewRoutines_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to View All Routines
        }
    }
}
