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
    /// Логика взаимодействия для OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        public readonly SportDBEntities _db = new SportDBEntities();
        public OrderListWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList(TxtSearch.Text);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrderTable orderTable = new OrderTable();
            orderTable.Show();
            Hide();
        }

        public void RefreshList(string status)
        {
            ListViewOrders.ItemsSource = status == string.Empty ? _db.Order.ToList() : _db.Order.Where(q => q.OrderStatus.OrderStatusName.ToLower().Contains(status)).ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshList(TxtSearch.Text);
        }

        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = (sender as Button).DataContext as Order;

            MessageBox.Show($"{order.OrderID} - Выбранный элемент!");
        }

        private void BtnChangeOrder_Click(object sender, RoutedEventArgs e)
        {
            Order selectedorder = (sender as Button).DataContext as Order;
            UpdateOrderWindow uow = new UpdateOrderWindow(selectedorder);
            uow.Show();
            Hide();
        }
    }
}
