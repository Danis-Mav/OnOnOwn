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
using System.Collections.ObjectModel;
using OnOnOwn;

namespace WpfAppOnOnOwn.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public static ObservableCollection<menu> menu { get; set; }
        public MenuPage(bool isAdmin)
        {
            InitializeComponent();
            menu = new ObservableCollection<menu>(DBConnection.connection.menu.ToList());
            this.DataContext = this;

            if(isAdmin==true)
            { 
                ToOrderDish.Visibility = Visibility.Hidden;
                GoOrder.Visibility = Visibility.Hidden;
                GoOrder.Visibility = Visibility.Hidden;
                AddDish.Visibility = Visibility.Visible;
                DeleteDish.Visibility = Visibility.Visible;
                Orders.Visibility = Visibility.Visible;
                StopList.Visibility = Visibility.Visible;
                RedStopList.Visibility = Visibility.Visible;

            }
        }

        private void Button_hotDish(object sender, RoutedEventArgs e)
        {
            prod.ItemsSource = new ObservableCollection<menu>(DBConnection.connection.menu.Where(p => p.IDtype == 1));
        }

        private void Button_coldDish(object sender, RoutedEventArgs e)
        {
            prod.ItemsSource = new ObservableCollection<menu>(DBConnection.connection.menu.Where(p => p.IDtype == 2));
        }
        private void Button_Snacks(object sender, RoutedEventArgs e)
        {
            prod.ItemsSource = new ObservableCollection<menu>(DBConnection.connection.menu.Where(p => p.IDtype == 3));
        }
        private void Button_Drinks(object sender, RoutedEventArgs e)
        {
            prod.ItemsSource = new ObservableCollection<menu>(DBConnection.connection.menu.Where(p => p.IDtype == 4));
        }
        private void Button_Salad(object sender, RoutedEventArgs e)
        {
            prod.ItemsSource = new ObservableCollection<menu>(DBConnection.connection.menu.Where(p => p.IDtype == 5));
        }

        private void Button_allDish(object sender, RoutedEventArgs e)
        {
            prod.ItemsSource = new ObservableCollection<menu>(DBConnection.connection.menu.ToList());
        }

        private void ToOrderDish_Button(object sender, RoutedEventArgs e)
        {
            if (prod.SelectedItem != null)
            {
                var menuToAdd = prod.SelectedItem as menu;
                var newOM = new OrderMenu();

                newOM.IDom = 1;
                newOM.price = menuToAdd.Price;
                newOM.IDMenu = menuToAdd.IDmenu;
                newOM.IDorder = 1;  //СЮДА ВСТАВЛЯТЬ ID ЗАКАЗА  


                DBConnection.connection.OrderMenu.Add(newOM);
                DBConnection.connection.SaveChanges();
            }
            else MessageBox.Show("ЛОХ");
        }


        private void GoOrder_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage());
        }

        private void AddDish_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new NewEditPage());
        }

        private void DeleteDish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RedDish_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new NewEditPage());
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmOrders());
        }

        private void StopList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RedStopList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
