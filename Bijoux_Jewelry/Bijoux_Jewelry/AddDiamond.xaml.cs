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
    /// Interaction logic for AddDiamond.xaml
    /// </summary>
    public partial class AddDiamond : Window
    {
        public delegate void DialogClosedHandler();
        public event DialogClosedHandler DialogClosed;
        private DiamondRepository _diamondRepo = new();
        private ProductDiamondRepository _repo = new();
        private ProductDiamondService _productDiamondService = new();
        private List<object> _selectedItems;
        public int productId { get; set; }
        private void OnDialogClosed()
        {
            DialogClosed?.Invoke();
        }
        public AddDiamond()
        {
            InitializeComponent();
            _selectedItems = new List<object>();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
        }
        private void FillData()
        {
            diamondDataGrid.ItemsSource = _diamondRepo.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Diamond diamond = diamondDataGrid.SelectedItem as Diamond;
            if (diamond == null)
            {
                MessageBox.Show("Please select a diamond");
                return;
            }
            ProductDiamond productDiamond = new ProductDiamond
            {
                ProductId = productId,
                DiamondId = diamond.Id,
                Count = 1,
                Price=diamond.Price,
                Status = 1
            };

            _productDiamondService.AddDiamond(productDiamond);
            OnDialogClosed();
            MessageBox.Show("Add metal successfully");

        }

        private void diamondDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedItems = diamondDataGrid.SelectedItems.Cast<object>().ToList();

        }

        private void diamondDataGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            foreach (var item in _selectedItems)
            {
                if (!diamondDataGrid.SelectedItems.Contains(item))
                {
                    diamondDataGrid.SelectedItems.Add(item);
                }
            }
        }
    }
}
