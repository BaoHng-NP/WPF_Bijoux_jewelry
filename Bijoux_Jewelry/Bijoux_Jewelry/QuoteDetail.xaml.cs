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
    /// Interaction logic for Quote_detail.xaml
    /// </summary>
    public partial class QuoteDetail : Window
    {
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
        public Account account { get; set; }
        //public Quote quote { get; set; }
        public int quoteId { get; set; }
        Quote quote = new();
        public QuoteDetail()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            fillComboBox();
            FillData(); 
            if(account.Role == 1)
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
                btnApprove.Visibility = Visibility.Hidden;
                btnDeleteMetal.Visibility = Visibility.Hidden;
                btnDeleteDiamond.Visibility = Visibility.Hidden;
                if (quote.QuoteStatusId >= 4)
                {
                    btnCancel.Visibility = Visibility.Hidden;
                }

            }
            else if (account.Role == 2)
            {
                cbDesign.IsEnabled = true;
                cbProduction.IsEnabled = true;
                btnAddMetal.Visibility = Visibility.Hidden;
                btnAddDiamond.Visibility = Visibility.Hidden;
                btnSubmitPrice.Visibility = Visibility.Hidden;
                btnDeleteMetal.Visibility = Visibility.Hidden;
                btnDeleteDiamond.Visibility = Visibility.Hidden;
                if (quote.QuoteStatusId != 2)
                {
                    btnApprove.Visibility = Visibility.Hidden;
                    btnCancel.Visibility = Visibility.Hidden;
                }
            }
            else if(account.Role == 3)
            {
                txtSize.IsReadOnly = false;
                txtNote.IsReadOnly = false;
                txtProductionPrice.IsReadOnly = false;
                txtProfit.IsReadOnly = false;
                btnApprove.Visibility = Visibility.Hidden;
                btnCancel.Visibility = Visibility.Hidden;

                if (quote.QuoteStatusId > 2)
                {
                    btnSubmitPrice.Visibility = Visibility.Hidden;
                }

                //metalDataGrid.IsReadOnly = false;
                //diamondDataGrid.IsReadOnly = false;

            }
        }
        public void fillComboBox()
        {
            cbDesign.ItemsSource = _accountService.GetDesignStaff();
            cbDesign.DisplayMemberPath = "Fullname";
            cbDesign.SelectedValuePath = "Id";
            cbProduction.ItemsSource = _accountService.GetProductionStaff();
            cbProduction.DisplayMemberPath = "Fullname";
            cbProduction.SelectedValuePath = "Id";


        }
        private void FillData()
        {
            quote = _quoteService.GetQuoteById(quoteId);
            txtQuoteId.Text = quote.Id.ToString();
            txtCustomerName.Text = quote.Account.Fullname;
            txtContact.Text = quote.Account.Phone;
            cbDesign.SelectedValue= quote.DesignStaffId;
            cbProduction.SelectedValue = quote.ProductionStaffId;
            txtproductId.Text = quote.ProductId.ToString();
            txtStatus.Text = quote.QuoteStatus.Name;
            txtDate.Text = quote.Created.ToString();
            txtNote.Text = quote.Note;
            txtSize.Text = quote.Product.MountingSize.ToString();
            //double productPrice = _productMetalService.getMetalPrice(quote.ProductId) + _productDiamondService.getDiamondPrice(quote.ProductId); 
            
            txtProfit.Text = quote.ProfitRate.ToString("N0");
            //txtTotal.Text = quote.TotalPrice.ToString("N0");

            List<ProductMetal> productMetals= _productMetalService.GetByProductId(quote.ProductId);
            metalDataGrid.ItemsSource = productMetals;
            List<ProductDiamond> productDiamonds = _productDiamondService.GetbyId(quote.ProductId);
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
            txtProductPrice.Text = productPrice.ToString("N0");
            double customerProduction;
            if (account.Role == 1)
            {
                customerProduction = quote.ProductionPrice;
                customerProduction += productPrice*quote.ProfitRate/100;
                txtProductionPrice.Text = customerProduction.ToString("N0");
            }else txtProductionPrice.Text = quote.ProductionPrice.ToString("N0");

            double newproductPrice = double.Parse(txtProductPrice.Text, System.Globalization.NumberStyles.AllowThousands);
            double profitRate = double.Parse(txtProfit.Text, System.Globalization.NumberStyles.AllowThousands);
            double productionPrice = double.Parse(txtProductionPrice.Text, System.Globalization.NumberStyles.AllowThousands);

            // Tính toán total
            double total = newproductPrice * profitRate/100 + newproductPrice + productionPrice;

            // Hiển thị kết quả
            txtTotal.Text = total.ToString("N0");
        }

        private void btnDeleteMetal_Click(object sender, RoutedEventArgs e)
        {
            ProductMetal productMetal = (ProductMetal)metalDataGrid.SelectedItem;
            if(productMetal != null)
            {
                _productMetalService.deleteProductMetal(productMetal);
                FillData();
            }else MessageBox.Show("Please select a metal to delete", "Try agian!", MessageBoxButton.OK);
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
            addMetal.productId = quote.ProductId;
            addMetal.DialogClosed += OnAddMetalDialogClosed;

            addMetal.ShowDialog();

        }

        private void btnAddDiamond_Click(object sender, RoutedEventArgs e)
        {
            AddDiamond addDiamond = new();
            addDiamond.productId = quote.ProductId;
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
                    Product product = _productService.GetProductById(quote.ProductId);
            product.MountingSize = Convert.ToDouble(txtSize.Text);
            _productService.updateProduct(product);

            Quote newQuote = _quoteService.GetQuoteByIdUpdate(quote.Id);
            newQuote.ProductionPrice = Convert.ToDouble(txtProductionPrice.Text);
            newQuote.ProductPrice = Convert.ToDouble(txtProductPrice.Text);
            newQuote.ProfitRate = Convert.ToDouble(txtProfit.Text);
            newQuote.Note = txtNote.Text;
            newQuote.QuoteStatusId = 2;

            _quoteService.UpdateQuote(newQuote);
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


        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            if (ApproveValidateInputs())
            {
                try
                {
                    Quote approvedQuote= _quoteService.GetQuoteByIdUpdate(quote.Id);
            approvedQuote.QuoteStatusId = 4;
            approvedQuote.DesignStaffId = Convert.ToInt32(cbDesign.SelectedValue);
            approvedQuote.ProductionStaffId = Convert.ToInt32(cbProduction.SelectedValue);
            _quoteService.UpdateQuote(approvedQuote);

            quote = _quoteService.GetQuoteById(quoteId);
            
            Order order =new Order();
            order.ProductId = quote.ProductId;
            order.AccountId = quote.AccountId;
            order.ProductPrice = quote.ProductPrice;
            order.ProfitRate = quote.ProfitRate;
            order.ProductionPrice = quote.ProductionPrice;
            order.DepositHasPaid = 0;
            order.TotalPrice = quote.TotalPrice;
            order.OrderStatusId = 1;
            order.Note = quote.Note;
            order.DesignStaffId = quote.DesignStaffId;
            order.ProductionStaffId = quote.ProductionStaffId;
            order.Created = DateTime.Now;
            
            _orderService.AddOrder(order);


            MessageBox.Show("Quote approved successfully", "Success", MessageBoxButton.OK);
            FillData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private bool ApproveValidateInputs()
        {
            if (cbDesign.SelectedValue == null || !int.TryParse(cbDesign.SelectedValue.ToString(), out _))
            {
                MessageBox.Show("Please select a valid design staff", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (cbProduction.SelectedValue == null || !int.TryParse(cbProduction.SelectedValue.ToString(), out _))
            {
                MessageBox.Show("Please select a valid production staff", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if(account.Id == 1)
            {
                Quote cancelQuote = _quoteService.GetQuoteByIdUpdate(quote.Id);
                cancelQuote.QuoteStatusId = 5;
                _quoteService.UpdateQuote(cancelQuote);
                MessageBox.Show("Quote canceled successfully", "Success", MessageBoxButton.OK);
                FillData();
            }
            else if(account.Id==2)
            {
                Product product = _productService.GetProductById(quote.ProductId);
                product.MountingSize = 0;
                _productService.updateProduct(product);

                Quote newQuote = _quoteService.GetQuoteByIdUpdate(quote.Id);
                newQuote.ProductionPrice = 0;
                newQuote.ProductPrice = 0;
                newQuote.ProfitRate = 0;
                newQuote.QuoteStatusId = 1;

                _quoteService.UpdateQuote(newQuote);


                List<ProductMetal> productMetals = _productMetalService.GetByProductId(quote.ProductId);
                metalDataGrid.ItemsSource = productMetals;
                List<ProductDiamond> productDiamonds = _productDiamondService.GetbyId(quote.ProductId);
                diamondDataGrid.ItemsSource = productDiamonds;

                foreach (var productMetal in productMetals)
                {
                    _productMetalService.deleteProductMetal(productMetal);
                }
                foreach (var productDiamond in productDiamonds)
                {
                    _productDiamondService.DeleteDiamond(productDiamond);
                }
                MessageBox.Show("Pricing was not approve", "Sending back to Sale staff", MessageBoxButton.OK);
                FillData();
            }
        }

        private void txtProductionPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<ProductMetal> productMetals = _productMetalService.GetByProductId(quote.ProductId);
            metalDataGrid.ItemsSource = productMetals;
            List<ProductDiamond> productDiamonds = _productDiamondService.GetbyId(quote.ProductId);
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


            if (double.TryParse(txtProductionPrice.Text, out double productionPrice) && double.TryParse(txtProfit.Text, out double profit))
            {
                txtTotal.Text=(productPrice + productPrice*profit/100 + productPrice).ToString("N0");
            }
        }


    }
}
