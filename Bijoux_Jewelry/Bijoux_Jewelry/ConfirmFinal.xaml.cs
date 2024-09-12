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
using Bijoux_Jewelry.BusinessLogicLayer.Services;
using Bijoux_Jewelry.DataAccess.Models;
using Microsoft.Win32;
using IOPath = System.IO.Path;

namespace Bijoux_Jewelry
{
    /// <summary>
    /// Interaction logic for ConfirmFinal.xaml
    /// </summary>
    public partial class ConfirmFinal : Window
    {
        public ConfirmFinal()
        {
            InitializeComponent();
        }
        private string imageUrl;
        private OrderService _orderService = new();
        private ProductionProcessService _productionProcessService = new();
        private ProductService _productService = new();
        public Order order { get; set; }
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
        private void LoadImageTepm(string filePath)
        {
            Uri fileUri = new Uri(filePath);
            image.Source = new BitmapImage(fileUri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = _productService.GetProductById(order.ProductId);
            ProductionProcess productionProcess = _productionProcessService.getProductionProcessesByOrder(order.Id);
            Order newOrder = new Order();
            newOrder = _orderService.GetOrderById(order.Id);

            if (imageUrl != null && productionProcess!=null)
            {
                product.ImageUrl = imageUrl;
                _productService.updateProduct(product);

                productionProcess.ProductionStatusId = 5;
                _productionProcessService.updateProductionProcess(productionProcess);

                newOrder.OrderStatusId = 4;
                _orderService.updateOrder(newOrder);
                MessageBox.Show("Production complete");
                this.Close();
            }
            else
            {
               MessageBox.Show("Please add image");
                return;
            }}
    }
}
