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
    /// Interaction logic for DesignerWindow.xaml
    /// </summary>
    public partial class DesignerWindow : Window
    {
        public DesignerWindow()
        {
            InitializeComponent();
        }
        private OrderService _orderService = new();
        public Account account { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillOrder();
            btnUser.Content = account.Username;

        }
        private void fillOrder()
        {
            OrderDataGrid.ItemsSource = _orderService.GetAssignedDesign(account.Id);
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


    }
}
