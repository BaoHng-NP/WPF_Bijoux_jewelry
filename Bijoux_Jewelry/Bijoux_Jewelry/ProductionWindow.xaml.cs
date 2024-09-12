using Bijoux_Jewelry.BusinessLogicLayer.Services;
using Bijoux_Jewelry.DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for ProductionWindow.xaml
    /// </summary>
    public partial class ProductionWindow : Window
    {
        OrderService _orderService = new();
        ProductionProcessService _productionProcessService = new();
        ProductionStatusService _productionStatusService = new();
        public Account account { get; set; }

        public ProductionWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillOrder();
            fillComboBox();
            if(txtId.Text.IsNullOrEmpty())
            {
                btnUpdateStatus.IsEnabled = false;
            }
            else
            {
                btnUpdateStatus.IsEnabled = true;
            }
            btnUser.Content = account.Username;
        }

        private void fillOrder()
        {
            OrderDataGrid.ItemsSource = _orderService.GetAssignedProduction(account.Id);

        }
        
        private void fillComboBox()
        {
            cbStatus.ItemsSource = _productionStatusService.getAll();
            cbStatus.DisplayMemberPath = "Name";
            cbStatus.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);

        }

        private void OrderDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Order order = (Order)OrderDataGrid.SelectedItem;
            if (order == null) return;
            OrderDetail orderDetail = new();
            orderDetail.account = account;
            orderDetail.orderId = order.Id;
            orderDetail.ShowDialog();
        }

        private void OrderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order order = (Order)OrderDataGrid.SelectedItem;
            if (order == null)
            {   
                btnUpdateStatus.IsEnabled = false;
                return;
            }

            if (order.OrderStatusId != 3)
            {
                btnUpdateStatus.IsEnabled = false;
                return;
            }
            if (_productionProcessService.getProductionProcessesByOrder(order.Id).ProductionStatusId == 5)
            {
                btnUpdateStatus.IsEnabled = false;
            }
            else
            {
                btnUpdateStatus.IsEnabled = true;
            }
            txtId.Text = order.Id.ToString();
            cbStatus.SelectedValue = _productionProcessService.getProductionProcessesByOrder(order.Id).ProductionStatusId;

        }

        private void btnUpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please select an order to update status","Try again!",MessageBoxButton.OK);
                return;
            }

            ProductionProcess productionProcess = _productionProcessService.getProductionProcessesByOrder(int.Parse(txtId.Text));
            if ((int)cbStatus.SelectedValue - productionProcess.ProductionStatusId == -1 || (int)cbStatus.SelectedValue - productionProcess.ProductionStatusId == 1 || (int)cbStatus.SelectedValue - productionProcess.ProductionStatusId == 0)
            {
                productionProcess.ProductionStatusId = (int)cbStatus.SelectedValue;

                if ((int)cbStatus.SelectedValue == 5)
                {
                    ConfirmFinal confirmFinal = new();
                    confirmFinal.order = _orderService.GetOrderById(int.Parse(txtId.Text));
                    confirmFinal.ShowDialog();
                    return;
                }

                _productionProcessService.updateProductionProcess(productionProcess);
                MessageBox.Show("Update successfuly", "!", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("You can only update status by one step","Try again!",MessageBoxButton.OK);
                return;
            }
            

        }
    }
}
