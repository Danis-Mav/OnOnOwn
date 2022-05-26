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
        public static ObservableCollection<Order> Order { get; set; }
        public OrderPage()
        {
            InitializeComponent();
            OrderMenu = new ObservableCollection<OrderMenu>(DBConnection.connection.OrderMenu.ToList());
            this.DataContext = this;
            menu = new ObservableCollection<menu>(DBConnection.connection.menu.ToList());
            this.DataContext = this;
            Order = new ObservableCollection<Order>(DBConnection.connection.Order.ToList());
            this.DataContext = this;

            var query = from r in OrderMenu.AsEnumerable()
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
            var c = new Stol();
            b.FullPrice = blogNum;
            b.idStol = c.NameStol;
            DBConnection.connection.Order.Add(b);
            DBConnection.connection.SaveChanges();
            MessageBox.Show("Заказ сделан");
        }
    }
}
