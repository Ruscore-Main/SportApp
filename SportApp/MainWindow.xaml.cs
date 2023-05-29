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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SportApp.Models;

namespace SportApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SportDBEntities _db = new SportDBEntities();
        string captchaAnswer = "";
        DispatcherTimer dispatcher = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = _db.User.FirstOrDefault(u => u.UserLogin == TxtLogin.Text && u.UserPassword == TxtPassword.Password);

            if (user != null)
            {
                MessageBox.Show("Авторизован");
                ProductListWindow productListWindow = new ProductListWindow();
                productListWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пользователь не найден. Пройдите капчу!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                UpdateCaptcha();
                AuthPanel.Visibility = Visibility.Hidden;
                CaptchaPanel.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Обновление каптчи
        /// </summary>
        public void UpdateCaptcha()
        {
            MyCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
            TxtCaptcha.Text = "";
            captchaAnswer = MyCaptcha.CaptchaText;
        }

       /// <summary>
       /// Запуск таймера
       /// </summary>
       /// <param name="h"></param>
       /// <param name="m"></param>
       /// <param name="s"></param>
        public void TimerStart()
        {
            dispatcher.Tick += new EventHandler(TimerTick);
            dispatcher.Interval = new TimeSpan(0, 0, 10);
            dispatcher.Start();
        }


        /// <summary>
        /// Срабатывание таймера каждую секунду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TimerTick(object sender, EventArgs e)
        {
            BtnCaptcha.IsEnabled = true;
            UpdateCaptcha();
            dispatcher.Stop();
        }

        /// <summary>
        /// Проверка каптчи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCaptcha_Click(object sender, RoutedEventArgs e)
        {
            if (TxtCaptcha.Text == captchaAnswer)
            {
                AuthPanel.Visibility = Visibility.Visible;
                CaptchaPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                BtnCaptcha.IsEnabled = false;
                TimerStart();
            }
        }

        /// <summary>
        /// Войти как гость
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btnTable_Click(object sender, RoutedEventArgs e)
        {
            ProductTable productTable = new ProductTable();
            productTable.Show();
        }

        private void btnOrderTable_Click(object sender, RoutedEventArgs e)
        {
            OrderTable orderTable = new OrderTable();
            orderTable.Show();
        }
    }
}
