using Microsoft.Win32;
using SportApp.Models;
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

namespace SportApp
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        SportDBEntities _db = new SportDBEntities();
        public string filename;
        public AddProduct()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка добавлении фотографии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                filename = dlg.FileName;
                imgProductPhoto.Source = new BitmapImage(new Uri(filename));
            }
        }

        /// <summary>
        /// Кнопка добавление нового продукта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string currentDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            try
            {
                string extantion = filename.Split('.')[filename.Split('.').Length - 1];

                File.Copy(filename, $@"{currentDirectory}/Photos/{txtArticleNumber.Text}.{extantion}");

                var newproduct = new Product()
                {
                    ProductArticleNumber = txtArticleNumber.Text,
                    ProductName = txtName.Text,
                    UnitTypeID = 1,
                    ProductCost = int.Parse(txtCost.Text),
                    ProductMaxDiscountAmount = 10,
                    ProductManufacturer = cmbManufacturer.SelectedItem as ProductManufacturer,
                    ProductSupplierID = 1,
                    ProductCategory = cmbCategory.SelectedItem as ProductCategory,
                    ProductDiscountAmount = (byte?)int.Parse(txtDiscount.Text),
                    ProductQuantityInStock = int.Parse(txtQuantityInStock.Text),
                    ProductDescription = txtDescription.Text,
                    ProductPhoto = $@"{currentDirectory}/Photos/{txtArticleNumber.Text}.{extantion}"
                };

                _db.Product.Add(newproduct);
                _db.SaveChanges();

                MessageBox.Show("Добавлен новый продукт!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SportApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbManufacturer.ItemsSource = _db.ProductManufacturer.ToList();
            cmbCategory.ItemsSource = _db.ProductCategory.ToList();
        }
    }
}
