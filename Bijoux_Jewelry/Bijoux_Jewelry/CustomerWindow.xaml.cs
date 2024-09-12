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

    public partial class CustomerWindow : Window
    {
        private QuoteService _quoteService = new();
        private OrderService _orderService = new();
        private ProductService _productService = new();
        private ProductTypeService _productTypeService = new();
        public Account account {  get; set; }
        public CustomerWindow()
        {
            InitializeComponent();
        }

        public void fillComboBox()
        {
            cbProductType.ItemsSource = _productTypeService.GetAllProductType();
            cbProductType.DisplayMemberPath= "Name";
            cbProductType.SelectedValuePath = "Id";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillComboBox();
            fillQuote();
            fillOrder();
            btnUser.Content = account.Username;
        }
        private void fillQuote()
        {
            QuoteDataGrid.ItemsSource = _quoteService.GetAllQuoteCustomer(account.Id);
        }
        private void fillOrder()
        {
            OrderDataGrid.ItemsSource = _orderService.GetCustomerOrder(account.Id);
        }
        private bool ValidateInputs()
        {
            if (cbProductType.SelectedValue == null || string.IsNullOrEmpty(txtNote.Text))
            {
                return false;
            }
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    int productTypeId = (int)cbProductType.SelectedValue;
                    Product product = new();

                    product.ImageUrl = "";
                    product.ProductTypeId = int.Parse(cbProductType.SelectedValue.ToString());
                    product.MountingSize = 0;
                    Product newProduct = _productService.CreateProduct(product);

                    int productId = newProduct.Id;
                    int accountId = account.Id;
                    int quoteStatusId = 1;
                    double productPrice = 0;
                    double productionPrice = 0;
                    double profitRate = 0;
                    string note = txtNote.Text;
                    DateTime created = DateTime.Now;

                    Quote quote = new();
                    quote.ProductId = productId;
                    quote.AccountId = accountId;
                    quote.QuoteStatusId = quoteStatusId;
                    quote.ProductPrice = productPrice;
                    quote.ProductionPrice = productionPrice;
                    quote.ProfitRate = profitRate;
                    quote.Created = created;
                    quote.Note = note;

                    _quoteService.CreateQuote(quote);
                    MessageBox.Show("Quote is created successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
