using SrezGri.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace SrezGri.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginUser.Text;
            string password = PasswordUser.Password;

            User user = DB.DB.entities.User.FirstOrDefault(c => c.Password == password && c.Login == login);
            if (user != null&&CaptchaBlock.Text==CaptchaBox.Text)
            {
                CurrentUser.CurrentUser.user = user;
                NavigationService.Navigate(new OrderPage());
            }
            else if (LoginUser.Text == "" || PasswordUser.Password == "")
            {
                MessageBox.Show("Есть пустые поля.");
            }
            else
            {
                MessageBox.Show("Пользователь не найден.");
                LoginUser.Clear();
                PasswordUser.Clear();
                CaptchaPanel.Visibility = Visibility.Visible;
                CaptchaBlock.Text = CaptchaGen();
                EnterButton.IsEnabled = false;
                RefreshButtonTimer();
            }
        }
        public string CaptchaGen()
        {
            string alf = "juiikqahJUSIAHXJUAHNjudxkai217890hnsdjuaFGVJWS";
            string captcha = "";
            Random random= new Random();
            for(int i = 0; i < 5; i++) 
            {
                captcha += alf[random.Next(0, alf.Length)];
            }
            return captcha;
        }

        private async void RefreshButtonTimer()
        {
            await Task.Delay(10000);
            EnterButton.IsEnabled = true;
        }
    }
}
