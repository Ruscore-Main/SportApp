using SportApp.Models;
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

namespace SportApp
{
    /// <summary>
    /// Логика взаимодействия для UpdateOrderWindow.xaml
    /// </summary>
    public partial class UpdateOrderWindow : Window
    {
        public readonly SportDBEntities _db = new SportDBEntities();
        public Order _order;
        public UpdateOrderWindow(Order order)
        {
            InitializeComponent();
            _order = order;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SelectComboboxes();

            DtpcCreateDate.SelectedDate = _order.OrderCreateDate;
            DtpcDeliveryDate.SelectedDate = _order.OrderDeliveryDate;
        }

        /// <summary>
        /// Заполнение Combobo и выбор соответсвующего
        /// </summary>
        public void SelectComboboxes()
        {
            foreach (OrderStatus a in _db.OrderStatus.ToList())
            {
                CmbStatus.Items.Add(a.OrderStatusName);
            }

            foreach (PickupPoint a in _db.PickupPoint.ToList())
            {
                CmbPickupPoint.Items.Add(a.Address);
            }

            for (int i = 0; i < CmbStatus.Items.Count; i++)
            {
                if (CmbStatus.Items[i].ToString() == _order.OrderStatus.OrderStatusName)
                {
                    CmbStatus.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < CmbPickupPoint.Items.Count; i++)
            {
                if (CmbPickupPoint.Items[i].ToString() == _order.PickupPoint.Address)
                {
                    CmbPickupPoint.SelectedIndex = i;
                    break;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrderListWindow olw = new OrderListWindow();
            olw.Show();
            Hide();
        }

        private void BtnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            Order updatedorder = _db.Order.FirstOrDefault(q => q.OrderID == _order.OrderID);
            OrderStatus selectedorderstatus = _db.OrderStatus.FirstOrDefault(q => q.OrderStatusName == CmbStatus.SelectedValue.ToString());
            PickupPoint selectedpickuppoint = _db.PickupPoint.FirstOrDefault(q => q.Address == CmbPickupPoint.SelectedValue.ToString());

            updatedorder.OrderStatusID = selectedorderstatus.OrderStatusID;
            updatedorder.PickupPointID = selectedpickuppoint.PickupPointID;
            updatedorder.OrderCreateDate = DtpcCreateDate.SelectedDate.Value;
            updatedorder.OrderDeliveryDate = DtpcDeliveryDate.SelectedDate.Value;

            _db.SaveChanges();
        }
    }
}
