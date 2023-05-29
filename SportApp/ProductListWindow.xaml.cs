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
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        SportDBEntities _db = new SportDBEntities();
        public ProductListWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод обновления списка
        /// </summary>
        public void UpdateList()
        {
            if (this.IsLoaded)
            {
                List<Product> products = _db.Product.ToList();
                string selectedSort = (CmbSort.SelectedItem as ComboBoxItem).Content.ToString();
                string selectedFilter = (CmbFilter.SelectedItem as ComboBoxItem).Content.ToString();

                if (TxtSearch.Text != "")
                {
                    products = products.Where(el => el.ProductName.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
                }

                if (selectedSort == "По возрастанию")
                {
                    products = products.OrderBy(el => el.ProductCost).ToList();
                }
                else
                {
                    products = products.OrderByDescending(el => el.ProductCost).ToList();
                }

                if (selectedFilter == "0-9,99%")
                {
                    products = products.Where(el => el.ProductDiscountAmount >= 0 && el.ProductDiscountAmount < 10).ToList();
                }
                else if (selectedFilter == "10-14,99%")
                {
                    products = products.Where(el => el.ProductDiscountAmount >= 10 && el.ProductDiscountAmount < 15).ToList();
                }
                else if (selectedFilter == "15% и более")
                {
                    products = products.Where(el => el.ProductDiscountAmount >= 15).ToList();
                }

                TxtAmountElemnts.Text = "Общее кол-во записей: " + products.Count.ToString();
                ListProduct.ItemsSource = products;
            }


        }

        /// <summary>
        /// Обработчик изменения сортировки по цене
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Изменение фильтрации по скидке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Изменение текса поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// Окно загружено
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
