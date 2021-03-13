/// <summary>
/// Nathaniel Webber
/// Created: 2021/02/05
///
/// This page is what the Login page will direct to
/// which is a general dashboard of all other components
/// </summary>
///
/// <remarks>
/// Nathaniel Webber
/// Updated: 2021/02/18
/// First MVP delivered
/// </remarks>

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
using DataStorageModels;
using DataViewModels;
using DataAccessFakes;
using DataAccessLayer;

namespace PresentationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // The needed UserAccount manager
        private IUserManager _userAccountManager = new UserManager(new UserAccessor());

        // Instantiates a UserAccount with default values,
        // to be filled with proper information as an access token,
        // following true DialogResult from the CreateLoginUserAccount window
        private UserAccount _user = new UserAccount();

        // The view model of the authenticated user, which is not created until the window loads
        private UserAccountVM _userAccountVM;

        // Flag for a newly created UserAccount
        private bool _isNewUserAccount;

        /// <summary>
        /// Creator: Mitchell Paul
        /// Created: 2/16/2021
        /// Approver:
        /// Event Handler for the menu options, brings the user to the edit account screen.
        /// By navigating the MainFrame source to the PgEditUserAccount
        ///
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnUserProfileOptions_Click(object sender, RoutedEventArgs e)
        {

            var userAccountDetailWindow = new PgEditUserAccount(_user);

            frmMainFrame.Navigate(userAccountDetailWindow);
            frmMainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            btnViewUserDashboard.IsEnabled = true;


        }

        public MainWindow()
        {
            var loginWindow = new CreateLoginUserAccount(_user);
            loginWindow.ShowDialog();
            InitializeComponent();
            btnViewUserDashboard.IsEnabled = false;
        }

        public MainWindow(UserAccount _user, IUserManager _userAccountManager, bool _isNewUserAccount)
        {
            this._user = _user;
            this._userAccountManager = _userAccountManager;
            this._isNewUserAccount = _isNewUserAccount;

        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        ///
        /// Event handler for Window_Loaded event
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Check to see if the UserAccount access token is still set to the 'empty' UserAccount
            if(_user.UserAccountID == 0)
            {
                // The user has not properly authenticated, close window
                Close();
            }

            // Create the UserAccountVM from the authenticated user
            try
            {
                _userAccountVM = _userAccountManager.GetUserAccountVMByUserAccount(_user);
            }
            catch (Exception)
            {

                MessageBox.Show("Additional User Account information could not be loaded.");
            }
            txtUsername.Text = _user.UserName;
            txtUsername.IsEnabled = false;
            SelectDashboard(_userAccountVM);
        }

        /// <summary>
        /// Jory A. Wernette
        /// Created: 2021/02/26
        ///
        /// Click event to show the user thei Journals
        /// </summary>
        private void btnViewJournals_Click(object sender, RoutedEventArgs e)
        {
            var viewJournals = new pgViewJournals(_user.UserAccountID, _user);

            frmMainFrame.Navigate(viewJournals);
            frmMainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
	      }


        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        ///
        /// Selects dashboard that matches the role with the most authority that a UserAccountVM has in any of their groups
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        ///
        /// <param name="userAccountVM">The UserAccountVM for which a dashboard is to be selected</param>
        private void SelectDashboard(UserAccountVM userAccountVM)
        {
            // The interface to present
            // This defaults to the "Admin" dashboard, as UserAccounts will be an "Admin" of a group for themselves unless
            // The account was created by an "Admin"
            String interfaceRole = "Admin";
            bool searching = true;
            foreach (var membership in userAccountVM.Memberships)
            {
                while (searching)
                {
                    foreach (var role in membership.Roles)
                    {
                        if (role.Name == "Client")
                        {
                            interfaceRole = "Client";
                            searching = false;
                            break;
                        }
                        else if (role.Name == "Caregiver")
                        {
                            interfaceRole = "Caregiver";
                            searching = false;
                            break;
                        }
                    }
                    searching = false;
                }
            }
            switch (interfaceRole)
            {
                case "Admin":
                    frmMainFrame.Navigate(new AdministratorDashboard(_userAccountVM));
                    break;
                case "Caregiver":
                    break;
                case "Client":
                    frmMainFrame.Navigate(new ClientDashboard(_userAccountVM));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/02/25
        ///
        /// Event handler for Window_Loaded event
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        private void btnViewUserDashboard_Click(object sender, RoutedEventArgs e)
        {
            SelectDashboard(_userAccountVM);
            btnViewUserDashboard.IsEnabled = false;
        }
    }
}
