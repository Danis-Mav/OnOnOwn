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
        public static ObservableCollection<OrderMenu> OrderMenu { get; set; }
        public static ObservableCollection<menu> menu { get; set; }
        //public static ObservableCollection<Type> Type { get; set; }
        public OrderPage()
        {
            InitializeComponent();
            OrderMenu = new ObservableCollection<OrderMenu>(DBConnection.connection.OrderMenu.ToList());
            this.DataContext = this;
            menu = new ObservableCollection<menu>(DBConnection.connection.menu.ToList());
            this.DataContext = this;
            //Type = new ObservableCollection<Type>(DBConnection.connection.Type.ToList());
            //this.DataContext = this;
        }
    }
}
