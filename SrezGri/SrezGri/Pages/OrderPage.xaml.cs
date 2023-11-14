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
using System.Threading;

namespace SrezGri.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderService CurretOrderService;
        List<OrderService> OrderServices = new List<OrderService>();
        public OrderPage()
        {
            InitializeComponent();
            AllOrdersListView.ItemsSource = DB.DB.entities.OrderService.ToList();
        }
        List<OrderService> orderServicesList = new List<OrderService>();
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            OrderService CurrentOrderService = (OrderService)AllOrdersListView.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этот заказ?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DB.DB.entities.OrderService.Remove(CurrentOrderService);
                DB.DB.entities.SaveChanges();
                AllOrdersListView.ItemsSource = DB.DB.entities.OrderService.ToList();
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBox.Show("Информация не будет удалена!");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            OrderService CurrentOrderService = (OrderService)AllOrdersListView.SelectedItem;
            NavigationService.Navigate(new AddEditPage(CurrentOrderService));
            AllOrdersListView.ItemsSource = DB.DB.entities.OrderService.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage());
            AllOrdersListView.ItemsSource = DB.DB.entities.OrderService.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AllOrdersListView.ItemsSource = DB.DB.entities.OrderService.ToList();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
