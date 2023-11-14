using SrezGri.Entities;
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

namespace SrezGri.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        OrderService orderService;
        bool isEdit = true;
        public AddEditPage()
        {
            InitializeComponent();
            orderService = new OrderService();
            isEdit = false;
        }
        public AddEditPage(OrderService orderServices)
        {
            InitializeComponent();
            orderService = orderServices;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isEdit)
                {
                    NavigationService.Navigate(new OrderPage());
                }
                else
                {
                    if (NameServiceTextBox.Text == "" || PriceTextBox.Text == "" || DateOrderPicker.Text == "")
                    {
                        MessageBox.Show("Есть пустые поля!");
                    }
                    else
                    {

                        orderService.Order.OrderDate = DateOrderPicker.SelectedDate;
                        DB.DB.entities.SaveChanges();
                        NavigationService.GoBack();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
