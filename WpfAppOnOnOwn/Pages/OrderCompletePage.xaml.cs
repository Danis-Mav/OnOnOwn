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
        public static ObservableCollection<OrderMenu> order { get; set; }
        public static List<OrderMenu> order2show { get; set; }
        public OrderCompletePage(Order n)
        {
            this.DataContext = this;
            foreach (var i in order2show)
            {
                if (i.IDorder == 1)
                    order2show.Add(i);

            }
            InitializeComponent();
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
