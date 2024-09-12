using Bijoux_Jewelry.BusinessLogicLayer.Services;
using Bijoux_Jewelry.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Xml.Linq;

namespace Bijoux_Jewelry
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private OrderService _orderService = new();
        private QuoteService _quoteService = new();
        private AccountService _accountService = new();
        private MetalService _metalService = new();
        private DiamondService _diamondService = new();
        public Account account { get; set; }
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillCustomer();
            fillStaff();
            fillQuote();
            fillOrder();
            fillMetal();
            fillDiamond();
            fillComboBox();
            btnUser.Content = account.Username;

        }
        private void fillCustomer()
        {
            CustomerDataGrid.ItemsSource = _accountService.GetCustomer();
            dpDob.SelectedDate = null;
            txtId.Text = "";
            txtUsername.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtFullname.Text = "";
            dpCreated.SelectedDate = null;
        }
        private void fillStaff()
        {
            StaffDataGrid.ItemsSource = _accountService.GetStaff();
            dpSDob.SelectedDate = null;
            txtSId.Text = "";
            txtSUsername.Text = "";
            txtSPhone.Text = "";
            txtSEmail.Text = "";
            txtSFullname.Text = "";
            dpSCreated.SelectedDate = null;
            txtRole.Text = "";

        }
        private void fillQuote()
        {
            QuoteDataGrid.ItemsSource = _quoteService.GetAllQuote();
        }

        private void fillOrder()
        {
            OrderDataGrid.ItemsSource = _orderService.GetAllOrderInclude();
        }
        private void fillMetal()
        {
            MetalDataGrid.ItemsSource = _metalService.GetAll();
            txtMId.Text = "";
            txtMName.Text = "";
            txtMBuyPrice.Text = "";
            txtMSalePrice.Text = "";
            txtSpecifixWeight.Text = "";
            dpMCreated.SelectedDate = null; 


        }
        private void fillDiamond()
        {
            DiamondDataGrid.ItemsSource = _diamondService.GetAll();
            txtDId.Text = "";
            txtSize.Text = "";
            cbColor.SelectedValue = null;
            cbOrigin.SelectedValue = null;
            cbClarity.SelectedValue = null;
            txtPrice.Text = "";
            dpDCreated.SelectedDate = null;

        }
        private void fillComboBox()
        {
            cbColor.ItemsSource = _diamondService.GetAllColor();
            cbColor.DisplayMemberPath = "Name";
            cbColor.SelectedValuePath = "Id";
            cbOrigin.ItemsSource = _diamondService.GetAllOrigin();
            cbOrigin.DisplayMemberPath = "Name";
            cbOrigin.SelectedValuePath = "Id";
            cbClarity.ItemsSource = _diamondService.GetAllClarity();
            cbClarity.DisplayMemberPath = "Name";
            cbClarity.SelectedValuePath = "Id";
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

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CustomerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CustomerDataGrid.SelectedItem is Account selected)
            {
                DateTime.TryParse(selected.Dob.ToString(), out DateTime dob);
                DateTime.TryParse(selected.Created.ToString(), out DateTime created);
                txtId.Text = selected.Id.ToString();
                txtUsername.Text = selected.Username;
                txtPhone.Text = selected.Phone;
                dpDob.SelectedDate = dob;
                txtEmail.Text = selected.Email;
                txtFullname.Text = selected.Fullname;
                dpCreated.SelectedDate = created;
                chkStatus.IsChecked = selected.Status != 0;
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                Account account = _accountService.GetbyId(id);
                if (account != null)
                {
                    //DateOnly.TryParse(dpDob.SelectedDate.Value.ToString(), out DateOnly date);
                    account.Username = txtUsername.Text;
                    account.Phone = txtPhone.Text;
                    account.Dob = DateOnly.FromDateTime(dpDob.SelectedDate.Value);
                    account.Email = txtEmail.Text;
                    account.Fullname = txtFullname.Text;
                    account.Status = (byte)(chkStatus.IsChecked == true ? 1 : 0);

                    _accountService.Update(account);
                    MessageBox.Show("Update thành cổng");
                    fillCustomer();
                }
            }
        }

        private void StaffDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StaffDataGrid.SelectedItem is Account selected)
            {
                DateTime.TryParse(selected.Dob.ToString(), out DateTime dob);
                DateTime.TryParse(selected.Created.ToString(), out DateTime created);
                txtSId.Text = selected.Id.ToString();
                txtSUsername.Text = selected.Username;
                txtSPhone.Text = selected.Phone;
                dpSDob.SelectedDate = dob;
                txtSEmail.Text = selected.Email;
                txtSFullname.Text = selected.Fullname;
                dpSCreated.SelectedDate = created;
                txtRole.Text = GetRoleText(selected.Role);
                chkSStatus.IsChecked = selected.Status != 0;
            }
        }
        private void EditStaff(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtSId.Text, out int id))
            {
                Account account = _accountService.GetbyId(id);
                if (account != null)
                {
                    //DateOnly.TryParse(dpDob.SelectedDate.Value.ToString(), out DateOnly date);
                    account.Username = txtSUsername.Text;
                    account.Phone = txtSPhone.Text;
                    account.Dob = DateOnly.FromDateTime(dpSDob.SelectedDate.Value);
                    account.Email = txtSEmail.Text;
                    account.Fullname = txtSFullname.Text;
                    account.Status = (byte)(chkStatus.IsChecked == true ? 1 : 0);

                    _accountService.Update(account);
                    MessageBox.Show("Update thành cổng");
                    fillStaff();
                }
            }
        }
        private string GetRoleText(int role)
        {
            switch (role)
            {
                case 3:
                    return "Sale";
                case 4:
                    return "Support";
                case 5:
                    return "Production";
                default:
                    return "Unknown";
            }
        }

        private void MetalDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MetalDataGrid.SelectedItem is Metal selected)
            {
                DateTime.TryParse(selected.Created.ToString(), out DateTime created);
                txtMId.Text = selected.Id.ToString();
                txtMName.Text = selected.Name;
                txtMBuyPrice.Text = selected.BuyPricePerGram.ToString();
                txtMSalePrice.Text = selected.SalePricePerGram.ToString();
                txtSpecifixWeight.Text = selected.SpecificWeight.ToString();
                dpMCreated.SelectedDate = created;
                chkDeactivate.IsChecked = selected.Deactivated != 0;
            }
        }

        private void EditMetal(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtMId.Text, out int id))
            {
                Metal metal = _metalService.GetById(id);
                if (metal != null)
                {
                    //DateOnly.TryParse(dpDob.SelectedDate.Value.ToString(), out DateOnly date);
                    double.TryParse(txtMBuyPrice.Text, out double buyPricePerGram);
                    double.TryParse(txtMSalePrice.Text, out double salePricePerGram);
                    double.TryParse(txtSpecifixWeight.Text, out double SpecificWeight);
                    metal.Name = txtMName.Text;
                    metal.BuyPricePerGram = buyPricePerGram;
                    metal.SalePricePerGram = salePricePerGram;
                    metal.SpecificWeight = SpecificWeight;
                    metal.Deactivated = (byte)(chkDeactivate.IsChecked == true ? 1 : 0);

                    _metalService.Update(metal);
                    MessageBox.Show("Update thành cổng");
                    fillMetal();
                }
            }
        }

        private void AddMetal(object sender, RoutedEventArgs e)
        {
            Metal metal = new Metal();
            double.TryParse(txtMBuyPrice.Text, out double buyPricePerGram);
            double.TryParse(txtMSalePrice.Text, out double salePricePerGram);
            double.TryParse(txtSpecifixWeight.Text, out double SpecificWeight);
            metal.Name = txtMName.Text;
            metal.BuyPricePerGram = buyPricePerGram;
            metal.SalePricePerGram = salePricePerGram;
            metal.SpecificWeight = SpecificWeight;
            metal.Deactivated = (byte)(chkDeactivate.IsChecked == true ? 1 : 0);
            metal.ImageUrl = "main.jpg";
            metal.Created = DateTime.Now;

            _metalService.Add(metal);
            MessageBox.Show("Add thành cổng", "alert", MessageBoxButton.OK, MessageBoxImage.Information);
            fillMetal();
        }

        private void EditDiamond(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtDId.Text, out int id))
            {
                Diamond diamond = _diamondService.GetById(id);
                if (diamond != null)
                {
                    //DateOnly.TryParse(dpDob.SelectedDate.Value.ToString(), out DateOnly date);
                    double.TryParse(txtSize.Text, out double size);
                    double.TryParse(txtPrice.Text, out double Price);
                    diamond.Size = size;
                    diamond.DiamondColorId = Convert.ToInt32(cbColor.SelectedValue);
                    diamond.DiamondOriginId = Convert.ToInt32(cbOrigin.SelectedValue);
                    diamond.DiamondClarityId = Convert.ToInt32(cbClarity.SelectedValue);
                    diamond.Price = Price;
                    diamond.Status = (byte)(chkDStatus.IsChecked == true ? 1 : 0);

                    _diamondService.update(diamond);
                    MessageBox.Show("Update successfully!");
                    fillDiamond();
                }
            }
        }

        private void AddDiamond(object sender, RoutedEventArgs e)
        {
            Diamond diamond = new Diamond();

            double.TryParse(txtSize.Text, out double size);
            double.TryParse(txtPrice.Text, out double Price);
            diamond.Size = size;
            diamond.DiamondColorId = Convert.ToInt32(cbColor.SelectedValue);
            diamond.DiamondOriginId = Convert.ToInt32(cbOrigin.SelectedValue);
            diamond.DiamondClarityId = Convert.ToInt32(cbClarity.SelectedValue);
            diamond.Price = Price;
            diamond.Status = (byte)(chkDStatus.IsChecked == true ? 1 : 0);
            diamond.ImageUrl = "main.jpg";
            diamond.Created = DateTime.Now;

            _diamondService.add(diamond);
            MessageBox.Show("Add successfully!", "alert", MessageBoxButton.OK, MessageBoxImage.Information);
            fillDiamond();
        }

        private void DiamondDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DiamondDataGrid.SelectedItem is Diamond selected)
            {
                DateTime.TryParse(selected.Created.ToString(), out DateTime created);
                txtDId.Text = selected.Id.ToString();
                txtSize.Text = selected.Size.ToString();
                cbColor.SelectedValue = selected.DiamondColorId;
                cbOrigin.SelectedValue = selected.DiamondOriginId;
                cbClarity.SelectedValue = selected.DiamondClarityId;
                txtPrice.Text = selected.Price.ToString();
                dpDCreated.SelectedDate = created;
                chkDStatus.IsChecked = selected.Status != 0;
            }
        }
    }
}
