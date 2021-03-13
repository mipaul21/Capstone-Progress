/// <summary>
/// Nathaniel Webber
/// Created: 2021/02/05
/// 
/// This is the main page for the Login screen
/// </summary>
///
/// <remarks>
/// Nathaniel Webber
/// Updated: 2021/02/18
/// First MVP delivered
/// </remarks>

using DataStorageModels;
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
using System.Windows.Shapes;

namespace PresentationWPF
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        private UserAccount _user;
        private IUserManager _userManager;
        private bool _isNewAccount;


        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/02/05
        /// 
        /// So far this class is empty, as it is more or less a placeholder
        /// for the actual dashboard
        /// </summary>
        ///
        /// <remarks>
        /// </remarks>
        public HomeScreen(UserAccount user, IUserManager userManager, bool isNewAccount = false)
        {
            _user = user;
            _userManager = userManager;
            _isNewAccount = isNewAccount;

            InitializeComponent();
        }

    }
}
