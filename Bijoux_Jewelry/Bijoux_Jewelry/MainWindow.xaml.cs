using Bijoux_Jewelry.DataAccess.Models;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bijoux_Jewelry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DiamondShopDbContext con;
        public MainWindow()
        {
            InitializeComponent();
            con = new DiamondShopDbContext();
            loadDiamond();
        }

        public void loadDiamond()
        {
            // Load diamond data
            List<Diamond> list = con.Diamonds.ToList();
            lvProduct.ItemsSource = list;
        }
    }
}