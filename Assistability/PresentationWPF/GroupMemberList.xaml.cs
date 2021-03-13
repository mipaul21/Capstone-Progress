/// <summary>
/// William Clark
/// Created: 2021/02/24
/// 
/// Interface to list all of the users in a list of UserGroups
/// </summary>
///
/// <remarks>
/// </remarks>
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
using DataStorageModels;
using DataViewModels;
using LogicLayerInterfaces;

namespace PresentationWPF
{
    /// <summary>
    /// Interaction logic for GroupMemberList.xaml
    /// </summary>
    public partial class GroupMemberList : Page
    {
        private List<UserGroup> _userGroups;
        private BindingList<UserAccount> _adminList = new BindingList<UserAccount>();
        private BindingList<UserAccount> _clientList = new BindingList<UserAccount>();
        private BindingList<UserAccount> _caregiverList = new BindingList<UserAccount>();
        private IUserGroupManager _userGroupManager;
        private IUserManager _userManager;
        private UserAccountVM _user;

        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Constructs a GroupMember list
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="userGroups">The UserGroups for which this list will display</param>
        /// <param name="userGroupManager">The UserGroupManager reference</param>
        /// <param name="userManager">The UserManager reference</param>
        /// <param name="role">The role for which this list will display. "Admin", "Client"</param>
        public GroupMemberList(List<UserGroup> userGroups, IUserGroupManager userGroupManager, IUserManager userManager, UserAccountVM user, String role)
        {
            InitializeComponent();

            _userGroups = userGroups;
            _userGroupManager = userGroupManager;
            _userManager = userManager;
            _user = user;

            switch (role)
            {
                case "Admin":
                    _clientList = PopulateList("Client");
                    dgFirstList.ItemsSource = _clientList;

                    _caregiverList = PopulateList("Caregiver");
                    dgSecondList.ItemsSource = _caregiverList;
                    break;
                case "Client":
                    _adminList = PopulateList("Admin");
                    dgFirstList.ItemsSource = _adminList;

                    _caregiverList = PopulateList("Caregiver");
                    dgSecondList.ItemsSource = _caregiverList;
                    break;
                default:
                    break;
            }
            frmSelectedUser.Navigate(new UserGroupMemberEditDetail(_user));
        }

        /// <summary>
        /// William Clark
        /// Created: 2021/03/11
        /// 
        /// Retrieves a BindingList of UserAccounts with the role provided
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        /// 
        /// <param name="role">The role for which this list will display. "Admin", "Client"</param>
        /// <returns>A BindingList of UserAccount"</returns>
        private BindingList<UserAccount> PopulateList(String role)
        {
            foreach (var group in _userGroups)
            {
                try
                {
                    return _userGroupManager.GetUserAccountsInUserGroupByRole(_userManager, group, role);
                }
                catch (Exception)
                {
                    MessageBox.Show("No " + role + "s found.");
                }

            }
            return null;
        }


        private void dgFirstList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedUser = (UserAccount)dgFirstList.SelectedItem;
            GroupMemberClicked(selectedUser);
        }

        private void dgSecondList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            var selectedUser = (UserAccount)dgSecondList.SelectedItem;
            GroupMemberClicked(selectedUser);
            
        }

        private void GroupMemberClicked(UserAccount userAccount)
        {
            if (userAccount != null)
            {
                try
                {
                    frmSelectedUser.Navigate(new UserGroupMemberEditDetail(_userManager.GetUserAccountVMByUserAccount(userAccount)));
                }
                catch (Exception)
                {
                    // Do not navigate
                }
            }
        }
    }
}
