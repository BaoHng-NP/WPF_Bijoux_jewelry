using Bijoux_Jewelry.BusinessLogicLayer.Services;
using Bijoux_Jewelry.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using IOPath = System.IO.Path;
using WPFPath = System.Windows.Shapes.Path;
using Microsoft.IdentityModel.Tokens;

namespace Bijoux_Jewelry
{
    /// <summary>
    /// Interaction logic for OrderDetail.xaml
    /// </summary>
    public partial class OrderDetail : Window
    {
        public OrderDetail()
        {
            InitializeComponent();
        }

        public delegate void DialogClosedHandler();
        public event DialogClosedHandler OnDialogClosed;
        private void NotifyDialogClosed()
        {
            OnDialogClosed?.Invoke();
        }
        private OrderService _orderService = new();
        private ProductMetalService _productMetalService = new();
        private ProductDiamondService _productDiamondService = new();
        private ProductService _productService = new();
        private QuoteService _quoteService = new();
        private AccountService _accountService = new();
        private ProductionProcessService _productionProcessService = new();
        public Account account { get; set; }
        private string imageUrl;
        public int orderId { get; set; }
        Order order = new();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FillData();
            if (account.Role == 1)
            {
                labelCustomerName.Visibility = Visibility.Hidden;
                lableContact.Visibility = Visibility.Hidden;
                txtCustomerName.Visibility = Visibility.Hidden;
                txtContact.Visibility = Visibility.Hidden;
                lableProfit.Visibility = Visibility.Hidden;
                txtProfit.Visibility = Visibility.Hidden;
                btnAddMetal.Visibility = Visibility.Hidden;
                btnAddDiamond.Visibility = Visibility.Hidden;
                btnSubmitPrice.Visibility = Visibility.Hidden;
                btnDeleteMetal.Visibility = Visibility.Hidden;
                btnDeleteDiamond.Visibility = Visibility.Hidden;
               
                if(order.OrderStatusId ==6)
                {
                    btnCancel.Visibility = Visibility.Hidden;
                }
                if(order.OrderStatusId == 1)
                {
                    DepositNote.Visibility = Visibility.Visible;
                    DepositNote.Content="Required deposit: " + (order.TotalPrice/2).ToString("N0");
                }
                if (order.OrderStatusId == 4)
                {
                    DepositNote.Visibility = Visibility.Visible;
                    DepositNote.Content = "Required pay the rest: " + (order.TotalPrice-order.DepositHasPaid).ToString("N0");
                }
            }
            else if (account.Role == 2)
            {

                btnAddMetal.Visibility = Visibility.Hidden;
                btnAddDiamond.Visibility = Visibility.Hidden;
                btnSubmitPrice.Visibility = Visibility.Hidden;
                btnDeleteMetal.Visibility = Visibility.Hidden;
                btnDeleteDiamond.Visibility = Visibility.Hidden;
                if (order.OrderStatusId == 6)
                {
                    btnCancel.Visibility = Visibility.Hidden;
                }
            }
            else if (account.Role == 3)
            {
                btnCancel.Visibility = Visibility.Hidden;
                btnSubmitPrice.Visibility = Visibility.Hidden;
                btnAddMetal.Visibility = Visibility.Hidden;
                btnAddDiamond.Visibility = Visibility.Hidden;
                btnDeleteDiamond.Visibility = Visibility.Hidden;
                btnDeleteMetal.Visibility = Visibility.Hidden;
                if(order.OrderStatusId == 1 || order.OrderStatusId == 4)
                {
                btnConfirmPayment.Visibility = Visibility.Visible;
                }

            }
            else if(account.Role == 4)
            {
                txtSize.IsReadOnly = false;
                txtNote.IsReadOnly = false;
                txtProductionPrice.IsReadOnly = false;
                txtProfit.IsReadOnly = false;
                btnCancel.Visibility = Visibility.Hidden;
                if(order.OrderStatusId ==1)
                {
                    btnAddMetal.Visibility = Visibility.Hidden;
                    btnAddDiamond.Visibility = Visibility.Hidden;
                    btnDeleteDiamond.Visibility = Visibility.Hidden;
                    btnDeleteMetal.Visibility = Visibility.Hidden;
                    btnImage.Visibility = Visibility.Hidden;
                    DepositNote.Visibility = Visibility.Visible;
                    DepositNote.Content="Pending deposit!";

                }
                if (order.OrderStatusId == 2)
                {
                    btnSubmitPrice.Visibility = Visibility.Visible;
                    btnImage.Visibility = Visibility.Visible;
                }
            }
            else if (account.Role == 5)
            {
                btnAddDiamond.Visibility = Visibility.Hidden;
                btnAddMetal.Visibility = Visibility.Hidden;
                btnDeleteDiamond.Visibility = Visibility.Hidden;
                btnDeleteMetal.Visibility = Visibility.Hidden;
                btnCancel.Visibility = Visibility.Hidden;

            }
        }

        private void FillData()
        {
            order = _orderService.GetOrderByIdInclude(orderId);
            txtOrderId.Text = order.Id.ToString();
            txtCustomerName.Text = order.Account.Fullname;
            txtContact.Text = order.Account.Phone;
            if(!order.Product.ImageUrl.IsNullOrEmpty()) LoadImageFromResources(order.Product.ImageUrl);
            txtproductId.Text = order.ProductId.ToString();
            txtStatus.Text = order.OrderStatus.Name;
            txtDate.Text = order.Created.ToString();
            txtNote.Text = order.Note;
            txtSize.Text = order.Product.MountingSize.ToString();
            txtDeposit.Text = order.DepositHasPaid.ToString("N0");
            txtProfit.Text = order.ProfitRate.ToString("N0");

            if (order.OrderStatusId==3)
            {
                ProductionProcess productionProcess = _productionProcessService.getProductionProcessesByOrderInclude(order.Id);
                prodStatusLable.Visibility = Visibility.Visible;
                txtprodStatus.Visibility = Visibility.Visible;
                txtprodStatus.Text = productionProcess.ProductionStatus.Name;
            }


            List<ProductMetal> productMetals = _productMetalService.GetByProductId(order.ProductId);
            metalDataGrid.ItemsSource = productMetals;
            List<ProductDiamond> productDiamonds = _productDiamondService.GetbyId(order.ProductId);
            diamondDataGrid.ItemsSource = productDiamonds;
            double productPrice = 0;
            foreach (var productMetal in productMetals)
            {
                productPrice += productMetal.Price;
            }
            foreach (var productDiamond in productDiamonds)
            {
                productPrice += productDiamond.Price;
            }

            double customerProduction;
            if (account.Role == 1){
                customerProduction = order.ProductionPrice;
                customerProduction += order.ProductPrice*order.ProfitRate/100;
                txtProductionPrice.Text= customerProduction.ToString("N0");
            }
            else txtProductionPrice.Text = order.ProductionPrice.ToString("N0");

            txtProductPrice.Text = productPrice.ToString("N0");

            double newproductPrice = double.Parse(txtProductPrice.Text, System.Globalization.NumberStyles.AllowThousands);
            double profitRate = double.Parse(txtProfit.Text, System.Globalization.NumberStyles.AllowThousands);
            double productionPrice = double.Parse(txtProductionPrice.Text, System.Globalization.NumberStyles.AllowThousands);

            // Tính toán total
            double total = newproductPrice * profitRate / 100 + newproductPrice + productionPrice;

            // Hiển thị kết quả
            txtTotal.Text = total.ToString("N0");
        }

        private void btnDeleteMetal_Click(object sender, RoutedEventArgs e)
        {
            ProductMetal productMetal = (ProductMetal)metalDataGrid.SelectedItem;
            if (productMetal != null)
            {
                _productMetalService.deleteProductMetal(productMetal);
                FillData();
            }
            else MessageBox.Show("Please select a metal to delete", "Try agian!", MessageBoxButton.OK);
        }

        private void btnDeleteDiamond_Click(object sender, RoutedEventArgs e)
        {
            ProductDiamond productDiamond = (ProductDiamond)diamondDataGrid.SelectedItem;
            if (productDiamond != null)
            {
                _productDiamondService.DeleteDiamond(productDiamond);
                FillData();
            }
            else MessageBox.Show("Please select a diamond to delete", "Try agian!", MessageBoxButton.OK);
        }

        private void btnAddMetal_Click(object sender, RoutedEventArgs e)
        {
            AddMetal addMetal = new();
            addMetal.productId = order.ProductId;
            addMetal.DialogClosed += OnAddMetalDialogClosed;

            addMetal.ShowDialog();

        }

        private void btnAddDiamond_Click(object sender, RoutedEventArgs e)
        {
            AddDiamond addDiamond = new();
            addDiamond.productId = order.ProductId;
            addDiamond.DialogClosed += OnAddDiamondDialogClosed;
            addDiamond.ShowDialog();
        }
        private void OnAddMetalDialogClosed()
        {
            FillData();
        }

        private void OnAddDiamondDialogClosed()
        {
            FillData();
        }
        private void btnSubmitPrice_Click(object sender, RoutedEventArgs e)
        {

            if (SubmitPriceValidateInputs())
            {
                try
                {
                    Product product = _productService.GetProductById(order.ProductId);
            product.MountingSize = Convert.ToDouble(txtSize.Text);
            if(imageUrl != null) product.ImageUrl = imageUrl;
            _productService.updateProduct(product);

            Order newOrder =_orderService.GetOrderById(order.Id);
            newOrder.Note = txtNote.Text;
            newOrder.ProductionPrice = Convert.ToDouble(txtProductionPrice.Text);
            newOrder.ProfitRate = Convert.ToDouble(txtProfit.Text);
            newOrder.ProductPrice = Convert.ToDouble(txtProductPrice.Text);
            newOrder.TotalPrice = newOrder.ProductionPrice + newOrder.ProductPrice*newOrder.ProfitRate/100 + newOrder.ProductPrice;
            newOrder.OrderStatusId = 3;

            _orderService.updateOrder(newOrder);

            ProductionProcess productionProcess = new();
            productionProcess.OrderId = order.Id;
            productionProcess.ProductionStatusId = 1;
            productionProcess.Created = DateTime.Now;
            productionProcess.ImageUrl = "";
            _productionProcessService.addProductionProcess(productionProcess);

            MessageBox.Show("Price submitted successfully", "Success", MessageBoxButton.OK);
            FillData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool SubmitPriceValidateInputs()
        {
            if (!double.TryParse(txtSize.Text, out double size) || size <= 0)
            {
                MessageBox.Show("Please enter a valid size greater than 0", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!double.TryParse(txtProductionPrice.Text, out double productionPrice) || productionPrice <= 0)
            {
                MessageBox.Show("Please enter a valid production price greater than 0", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!double.TryParse(txtProductPrice.Text, out double productPrice) || productPrice <= 0)
            {
                MessageBox.Show("Please enter a valid product price greater than 0", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!double.TryParse(txtProfit.Text, out double profitRate) || profitRate <= 0)
            {
                MessageBox.Show("Please enter a valid profit rate greater than 0", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                MessageBox.Show("Please enter a note", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (account.Id == 1 || account.Id==2)
            {

                Order cancelOrder =_orderService.GetOrderById(order.Id);
                cancelOrder.OrderStatusId = 6;
                _orderService.updateOrder(cancelOrder);
                MessageBox.Show("Order canceled successfully", "Success", MessageBoxButton.OK);
                FillData();
            }

        }

        private void btnConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            if(order.OrderStatusId == 1)
            {
                Order confirmOrder = _orderService.GetOrderById(order.Id);
                confirmOrder.OrderStatusId++;
                confirmOrder.DepositHasPaid = confirmOrder.TotalPrice * 0.5;
                _orderService.updateOrder(confirmOrder);

                MessageBox.Show("Payment confirmed successfully", "Success", MessageBoxButton.OK);
                FillData();
            }
            else if(order.OrderStatusId == 4)
            {
                Order confirmOrder = _orderService.GetOrderById(order.Id);
                confirmOrder.OrderStatusId++;
                confirmOrder.DepositHasPaid = confirmOrder.TotalPrice;
                _orderService.updateOrder(confirmOrder);

                MessageBox.Show("Payment confirmed successfully", "Success", MessageBoxButton.OK);
                FillData();
            }
            else
            {
                MessageBox.Show("Error", "Try again", MessageBoxButton.OK);
            }
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                AddFileToResources(filePath);
            }
        }
        private void AddFileToResources(string filePath)
        {
            string resourcesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
            Directory.CreateDirectory(resourcesPath);

            string fileName = System.IO.Path.GetFileName(filePath);
            string destinationPath = System.IO.Path.Combine(resourcesPath, fileName);

            File.Copy(filePath, destinationPath, true);
            imageUrl = destinationPath;
            MessageBox.Show($"File added to resources: {destinationPath}");
            LoadImageTepm(filePath);
        }

        private void LoadImageFromResources(string fileName)
        {
            string resourcePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", fileName);
            Uri fileUri = new Uri(resourcePath);
            image.Source = new BitmapImage(fileUri);
        }
        private void LoadImageTepm(string filePath)
        {
            Uri fileUri = new Uri(filePath);
            image.Source = new BitmapImage(fileUri);
        }

    }
}
