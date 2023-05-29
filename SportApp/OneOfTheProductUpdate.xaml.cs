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
using SportApp.Models;

namespace SportApp
{
    /// <summary>
    /// Логика взаимодействия для OneOfTheProductUpdate.xaml
    /// </summary>
    public partial class OneOfTheProductUpdate : Window
    {
        public readonly SportDBEntities _db = new SportDBEntities();
        public Product _product = new Product();
        public ProductTable _productTable;
        public OneOfTheProductUpdate(object sender, ProductTable productTable)
        {
            InitializeComponent();
            _product = (sender as Button).DataContext as Product;
            _productTable = productTable;
        }

        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblNameProduct.Content = _product.ProductName;
        }
    }
}
