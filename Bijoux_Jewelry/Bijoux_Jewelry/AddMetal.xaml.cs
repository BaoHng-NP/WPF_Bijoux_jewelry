using Bijoux_Jewelry.BusinessLogicLayer.Services;
using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
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
    /// Interaction logic for AddMetal.xaml
    /// </summary>
    public partial class AddMetal : Window
    {
        public delegate void DialogClosedHandler();
        public event DialogClosedHandler DialogClosed;
        ProductMetalService _productMetalService = new();
        MetalRepository _repo=new();
        public int productId { get; set;}
        private List<object> _selectedItems = new List<object>(); public AddMetal()
        {
            InitializeComponent();
        }

        private void OnDialogClosed()
        {
            DialogClosed?.Invoke();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    Metal metal = metalDataGrid.SelectedItem as Metal;
                    double weight = double.Parse(txtWeight.Text);
                    if (metal == null)
                    {
                        MessageBox.Show("Please select a metal");
                        return;
                    }
                    ProductMetal productMetal = new ProductMetal
                    {
                        ProductId = productId,
                        MetalId = metal.Id,
                        Weight = weight,
                        Price = metal.SalePricePerGram * weight,
                        Status = 1

                    };

                    _productMetalService.addProductMetal(productMetal);
                    OnDialogClosed();
                    MessageBox.Show("Add metal successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtWeight.Text) || !double.TryParse(txtWeight.Text, out _))
            {
                MessageBox.Show("Please enter a valid weight", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (metalDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a metal", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            metalDataGrid.ItemsSource = _repo.GetAll();
        }

        private void metalDataGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            // Lưu các mục được chọn khi DataGrid mất focus
            _selectedItems.Clear();
            foreach (var item in metalDataGrid.SelectedItems)
            {
                _selectedItems.Add(item);
            }
        }
        private void metalDataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            // Khôi phục lại các mục được chọn khi DataGrid lấy lại focus
            metalDataGrid.SelectedItems.Clear();
            foreach (var item in _selectedItems)
            {
                metalDataGrid.SelectedItems.Add(item);
            }
        }
        private void metalDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedItems = metalDataGrid.SelectedItems.Cast<object>().ToList();
        }
    }
}
