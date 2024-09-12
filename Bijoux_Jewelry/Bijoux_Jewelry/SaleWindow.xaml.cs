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

    public partial class SaleWindow : Window
    {
        private OrderService _orderService = new();
        private QuoteService _quoteService = new();
        public Account account { get; set;}
        public SaleWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillQuote();
            fillOrder();
            btnUser.Content = account.Username;

        }

        private void fillQuote()
        {
            QuoteDataGrid.ItemsSource= _quoteService.GetAllQuote();
        }

        private void fillOrder()
        {
            OrderDataGrid.ItemsSource = _orderService.GetAllOrderInclude();
        }

        private void QuoteDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Quote quote = (Quote)QuoteDataGrid.SelectedItem;
            if (quote == null) return;
            QuoteDetail quoteDetail = new();
            quoteDetail.account = account;
            quoteDetail.quoteId = quote.Id;
            quoteDetail.ShowDialog();
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
