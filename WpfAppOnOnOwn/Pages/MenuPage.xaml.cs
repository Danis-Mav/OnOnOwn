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
        public static bool globAdmin;
        public static ObservableCollection<menu> menu { get; set; }
        public static List<menu> menu2show { get; set; }

        private static menu currentMenu = new menu();
        public static int current2Order;


        public MenuPage(bool isAdmin, int currentOrder)
        {
            InitializeComponent();
            current2Order = currentOrder;
            globAdmin = isAdmin;
            menu = new ObservableCollection<menu>(DBConnection.connection.menu.ToList());
            menu2show = new List<menu>();
            this.DataContext = this;

            foreach (var i in menu)
            {
                if ((i.IsDelete == false) && (i.IsST == false))
                {
                    menu2show.Add(i);
                }
            }
            menu = new ObservableCollection<menu>(DBConnection.connection.menu.Where(x => (x.IsST == false) && (x.IsDelete == false)).ToList());
            prod.ItemsSource = menu;
            prod.Items.Refresh();
            if (globAdmin==true)
            { 
                ToOrderDish.Visibility = Visibility.Hidden;
                GoOrder.Visibility = Visibility.Hidden;
                GoOrder.Visibility = Visibility.Hidden;
                AddDish.Visibility = Visibility.Visible;
                RedDish.Visibility = Visibility.Visible;
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

                newOM.price = menuToAdd.Price;
                newOM.IDMenu = menuToAdd.IDmenu;
                newOM.IDorder = current2Order;
                newOM.IsOrder = false;
                DataAccess.DoOrderMenu(newOM);
            }
            else MessageBox.Show("Выберите блюдо");
        }


        private void GoOrder_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage(current2Order));
        }

        private void AddDish_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RedPage(new menu()));
        }

        private void DeleteDish_Click(object sender, RoutedEventArgs e)
        {

            if (prod.SelectedItem != null)
            {
                var st = prod.SelectedItem as menu;
                st.IsST = true;
                DBConnection.connection.SaveChanges();
            }
            else MessageBox.Show("Выберите блюдо");
        }

        private void RedDish_Click(object sender, RoutedEventArgs e)
        {
            if (prod.SelectedItem != null)
            {
                var n = currentMenu;
                NavigationService.Navigate(new RedPage(n));
            }
            else MessageBox.Show("Выберите блюдо");

        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdmOrders());
        }

        private void StopList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StopListPage());
        }

        private void RedStopList_Click(object sender, RoutedEventArgs e)
        {
            
            if (prod.SelectedItem != null)
            {
                (prod.SelectedItem as menu).IsST = true;
                DBConnection.connection.menu.FirstOrDefault();
                DBConnection.connection.SaveChanges();
            }
            else MessageBox.Show("Выберите блюдо");
            menu = new ObservableCollection<menu>(DBConnection.connection.menu.Where(x => (bool)x.IsST == false).ToList());
            prod.ItemsSource = menu;
            prod.Items.Refresh();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
    }

        private void prod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentMenu = ((sender as ListView).SelectedItem as menu);
        }
       
    }
}
