using OnOnOwn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfAppOnOnOwn.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdmOrders.xaml
    /// </summary>
    public partial class AdmOrders : Page
    {
        private static Order currentMenu = new Order();
        public static ObservableCollection<Order> order { get; set; }
        
        public AdmOrders()
        {
            order = new ObservableCollection<Order>(DBConnection.connection.Order.ToList());
            this.DataContext = this;
            InitializeComponent();
        }

        private void GotoOrder_Click(object sender, RoutedEventArgs e)
        {
            if (Orders.SelectedItem != null)
            {
                var n = currentMenu;
                NavigationService.Navigate(new OrderCompletePage(n));
            }
            else MessageBox.Show("Выберите блюдо");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentMenu = ((sender as ListView).SelectedItem as Order);
        }
    }
}
