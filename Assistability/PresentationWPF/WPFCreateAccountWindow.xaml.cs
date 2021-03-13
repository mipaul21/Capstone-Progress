/// <summary>
/// Ryan Taylor
/// Created: 2021/02/05
/// 
/// This takes the information the user put
/// into the interface to make an user account.
/// </summary>

using DataStorageModels;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationHelpers;
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
using System.Windows.Shapes;

namespace PresentationWPF
{
    /// <summary>
    /// Interaction logic for WPFCreateAccountWindow.xaml
    /// </summary>
    public partial class WPFCreateAccountWindow : Window
    {
        private UserAccount _userAccount;
        public WPFCreateAccountWindow()
        {
            _userAccount = new UserAccount();
            InitializeComponent();
        }

        private IUserManager _userAccountsManager = new UserManager();

        /// <summary>
        /// Ryan Taylor
        /// Created: 2021/02/10
        /// 
        /// This is used to give funtion to the create account button.
        /// </summary>
        /// /// <remarks>
        /// Ryan Taylor
        /// Updated: 2021/02/17 
        /// added a message box that tells the user that the account was made
        /// </remarks>
		/// 
		/// <param name="sender">information from the user to 
        /// create their account</param>
        /// <exception> something went wrong creating the account</exception>
        private void btnAddUserAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!txtEmail.Text.IsValidEmail())
                {
                    MessageBox.Show(txtEmail.Text + " is not a valid email");
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                    return;
                }

                if (!txtFirstName.Text.IsValidFirstName())
                {
                    MessageBox.Show(txtFirstName.Text + " is not a valid first name (too long)");
                    txtFirstName.Focus();
                    txtFirstName.SelectAll();
                    return;
                }

                if (!txtLastName.Text.IsValidLastName())
                {
                    MessageBox.Show(txtLastName.Text + " is not a valid last name (too long)");
                    txtLastName.Focus();
                    txtLastName.SelectAll();
                    return;
                }

                if (!txtUsername.Text.IsValidUsername())
                {
                    MessageBox.Show(txtUsername.Text + " is not a valid username (too long)");
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                    return;
                }

                if (!txtPassword.Text.IsValidPassword())
                {
                    MessageBox.Show(txtPassword.Text + " is not a valid password");
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    return;
                }

                if (txtReEnterPassword.Text != txtPassword.Text)
                {
                    MessageBox.Show(txtReEnterPassword.Text + " does not match " + txtPassword.Text);
                    txtReEnterPassword.Focus();
                    txtReEnterPassword.SelectAll();
                    return;
                }

                var newUserAccount = new UserAccount()
                {
                    Email = txtEmail.Text,
                    Active = true,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUsername.Text
                };

                _userAccountsManager.AddNewUserAccount(newUserAccount, txtPassword.Text);
                MessageBox.Show("Account: " + newUserAccount.UserName + "\n for "
                    + newUserAccount.FirstName + " " + newUserAccount.LastName + " was created");
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }
        /// <summary>
        /// Ryan Taylor
        /// Created: 2021/02/10
        /// 
        /// This is used to give funtion to the create cancel button.
        /// </summary>
		/// 
		/// <param name="sender">closes the create acount window</param>
        private void btnCancleAddingUserAccount_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
