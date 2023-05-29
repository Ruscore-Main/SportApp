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
    /// Логика взаимодействия для ProductTable.xaml
    /// </summary>
    public partial class ProductTable : Window
    {
        public readonly SportDBEntities _db = new SportDBEntities();
        public ProductTable()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        /// <summary>
        /// метод обновления таблицы
        /// </summary>
        public void RefreshTable()
        {
            dtgrdProduct.ItemsSource = _db.Product.ToList();
        }

        /// <summary>
        /// Кнопка перехода на окно изменения продукта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            OneOfTheProductUpdate oneOfTheProductUpdate = new OneOfTheProductUpdate(sender, this);
            oneOfTheProductUpdate.Show();
        }

        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshTable();
        }

        /// <summary>
        /// Кнопка удаления продукта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button).DataContext as Product;

            _db.Product.Remove(product);
            _db.SaveChanges();

            MessageBox.Show($"{product.ProductName} удален");

            RefreshTable();
        }
    }
}
