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
    /// Логика взаимодействия для OrderCompletePage.xaml
    /// </summary>
    public partial class OrderCompletePage : Page
    {
        public static ObservableCollection<OrderMenu> ordermenu { get; set; }
        public static ObservableCollection<Order> Order { get; set; }
        public static List<OrderMenu> order2show { get; set; }
        public static int Price;
        public OrderCompletePage(int idorder, int fullprice)
        {
            InitializeComponent();
            Price = fullprice;
            Total.Text = fullprice.ToString();
            Nomer.Text = (idorder).ToString();
            order2show = new List<OrderMenu>();
            ordermenu = new ObservableCollection<OrderMenu>(DBConnection.connection.OrderMenu.Where(x => (x.IDorder == idorder-1) && x.IsOrder == true).ToList());
            this.DataContext = this;
            foreach (var i in ordermenu.ToList())
            {
                //if (i.IDorder == idorder)
                //{
                    order2show.Add(i);
                //}
            }
            
        }

        private void OrderComplete(object sender, RoutedEventArgs e)
        {
                       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
