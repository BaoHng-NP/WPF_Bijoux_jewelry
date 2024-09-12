using Bijoux_Jewelry.BusinessLogicLayer.Services;
using Bijoux_Jewelry.DataAccess.Models;
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

namespace Bijoux_Jewelry
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        AccountService _accountService = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Account? acc = _accountService.Authenticate(txtUserName.Text, pass.Password);

            if (acc == null)
            {
                MessageBox.Show("Wrrong username or password", "Try again!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (acc.Role == 1)
            {
                CustomerWindow customerWindow = new();
                customerWindow.account = acc;
                customerWindow.Show();
            }
            else if (acc.Role == 3)
            {
                SaleWindow saleWindow = new();
                saleWindow.account = acc;
                saleWindow.Show();
            }
            else if (acc.Role == 2)
            {
                ManagerWindow managerWindow = new();
                managerWindow.account = acc;
                managerWindow.Show();
            }
            else if (acc.Role == 4)
            {
                DesignerWindow designWindow = new();
                designWindow.account = acc;
                designWindow.Show();
            }
            else if (acc.Role == 5)
            {
                ProductionWindow productionWindow = new();
                productionWindow.account = acc;
                productionWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid role", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
