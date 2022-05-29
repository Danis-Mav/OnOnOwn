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
    /// Логика взаимодействия для StopListPage.xaml
    /// </summary>
    public partial class StopListPage : Page
    {
        public static ObservableCollection<menu> menu { get; set; }
        public static List<menu> menu2show { get; set; }
        public StopListPage()
        {
            menu = new ObservableCollection<menu>(DBConnection.connection.menu.ToList());
            menu2show = new List<menu>();
            this.DataContext = this;
            foreach (var i in menu)
            {

                if (i.IsST == true)
                    menu2show.Add(i);
            }
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage((MenuPage.globAdmin)));
        }

        private void DeleteSL_Click(object sender, RoutedEventArgs e)
        {
            if (prod.SelectedItem != null)
            {
                (prod.SelectedItem as menu).IsST = false;
                DataAccess.DeleteSL();
            }
            else MessageBox.Show("Выберите блюдо");
            menu = new ObservableCollection<menu>(DBConnection.connection.menu.Where(x => (bool)x.IsST).ToList());
            prod.ItemsSource = menu;
            prod.Items.Refresh();
        }
    }
}
