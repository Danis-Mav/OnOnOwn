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
            menu = new ObservableCollection<menu>(DBconnection.connection.menu.ToList());
            this.DataContext = this;
            if(isAdmin == true)
            {
                add.Visibility = Visibility.Visible;
            }
        }
    }
}
