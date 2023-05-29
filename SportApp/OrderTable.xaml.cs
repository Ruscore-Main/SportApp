using SportApp.Models;
using System;
using System.Linq;
using System.Windows;

namespace SportApp
{
    /// <summary>
    /// Логика взаимодействия для OrderTable.xaml
    /// </summary>
    public partial class OrderTable : Window
    {
        public readonly SportDBEntities _db = new SportDBEntities();
        public OrderTable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshTable();

            DateTime dt = DateTime.Now;
            MessageBox.Show(dt.ToString(""));
        }

        /// <summary>
        /// Метод обновления таблицы
        /// </summary>
        public void RefreshTable()
        {
            dtgrdOrders.ItemsSource = _db.Order.ToList();
        }

        /// <summary>
        /// Изменение даты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datepickDelivery_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (datepickCreation.SelectedDate.Value != null && datepickDelivery.SelectedDate.Value != null)
            {
                dtgrdOrders.ItemsSource = _db.Order
                .Where(q => q.OrderCreateDate > datepickCreation.SelectedDate.Value && q.OrderCreateDate < datepickDelivery.SelectedDate.Value)
                .ToList();
            }
            else
            {
                RefreshTable();
            }
        }

        /// <summary>
        /// Переход на страницу заказов в ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOrdersList_Click(object sender, RoutedEventArgs e)
        {
            OrderListWindow orderListWindow = new OrderListWindow();
            orderListWindow.Show();
            this.Hide();
        }
    }
}
