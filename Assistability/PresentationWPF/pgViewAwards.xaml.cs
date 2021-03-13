/// <summary>
/// Nathaniel Webber
/// Created: 2021/03/10
/// 
/// This page is what the View Award Page
/// will direct to when the user clicks 
/// "Add Award" or "Edit Award"
/// </summary>

/// <summary>
/// Nathaniel Webber
/// Created: 2021/03/10
/// 
/// This page is what the View Award Page
/// will direct to when the user clicks 
/// "Add Award" or "Edit Award"
/// </summary>

using DataAccessFakes;
using DataStorageModels;
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
    /// Interaction logic for pgViewAwards.xaml
    /// </summary>
    public partial class pgViewAwards : Page
    {
        private IAwardManager _awardManager = new AwardManager();
        private int userAccountID;

        public pgViewAwards(UserAccount _user)
        {
            InitializeComponent();
        }

        public pgViewAwards(int userID)
        {
            this.userAccountID = userID;
            InitializeComponent();
            OnPageLoad(userAccountID);
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// This is the logic that will happen when this page loads. It will fill the grid with the user's Awards.
        /// </summary>
        private void OnPageLoad(int userAccountID)
        {
            try
            {
                dgAwardDisplay.ItemsSource = _awardManager.RetreiveAllAwards();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// When the User double clicks an Award, it will pull the logic to show that Awards's details
        /// </summary>
        private void dgAwardDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedAward = (Award)dgAwardDisplay.SelectedItem;
            var editAward = new pgAddEditAward(userAccountID, selectedAward.AwardName, selectedAward.AwardID);
            NavigationService.Navigate(editAward);
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// This is what the user will click when they want to create a new Award
        /// </summary>
        private void btnNewAward_Click(object sender, RoutedEventArgs e)
        {
            var addAward = new pgAddEditAward(userAccountID);
            NavigationService.Navigate(addAward);
        }

        /// <summary>
        /// Nathaniel Webber
        /// Created: 2021/03/10
        /// 
        /// This is what the user will click when they want to edit an Award
        /// </summary>
        private void btnEditAward_Click(object sender, RoutedEventArgs e)
        {
            var selectedAward = (Award)dgAwardDisplay.SelectedItem;

            if (selectedAward == null)
            {
                lblError.Visibility = Visibility.Visible;
                return;
            }

            var editAward = new pgAddEditAward(userAccountID, selectedAward.AwardName, selectedAward.AwardID);
            NavigationService.Navigate(editAward);
        }

        
        
    }
}
