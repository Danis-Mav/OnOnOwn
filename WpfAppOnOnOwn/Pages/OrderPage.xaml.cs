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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public static int blogNum { get; set; }
        public static ObservableCollection<OrderMenu> OrderMenu { get; set; }
        public static ObservableCollection<menu> menu { get; set; }
        public static ObservableCollection<Order> order { get; set; }
        public OrderPage(int currentOrder)
        {
            InitializeComponent();
            Nomer.Text = currentOrder.ToString();
            OrderMenu = new ObservableCollection<OrderMenu>(DBConnection.connection.OrderMenu.Where(x => x.IDorder == currentOrder).ToList());
            this.DataContext = this;

            var query = from r in (OrderMenu.Where(x => x.IDorder == currentOrder)).AsEnumerable()
                        select r.price;

            foreach (var i in query)
            {
                
                blogNum += (int)i;
            }
            Total.Content = blogNum;
            this.DataContext = this;
        }

        private void DoOrder_Click(object sender, RoutedEventArgs e)
        {
            var a = new OrderMenu();
            var b = new Order();
            b.FullPrice = blogNum;
            b.idStol = 1;
            b.IsComplete = true;
            //a.IsOrder = true;
            DataAccess.DoOrder(b);
            MessageBox.Show("Заказ сделан");
            blogNum = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage(MenuPage.globAdmin,MainPage.currentOrder));
        }
    }
}
