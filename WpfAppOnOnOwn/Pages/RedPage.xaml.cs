using Microsoft.Win32;
using OnOnOwn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Логика взаимодействия для RedPage.xaml
    /// </summary>
    public partial class RedPage : Page
    {
        public static ObservableCollection<menu> Menu { get; set; }
        public static ObservableCollection<Country> Country { get; set; }

        public static menu constmenu;
        public RedPage(menu n)
        {
            Country = new ObservableCollection<Country>(DBConnection.connection.Country.ToList());
            InitializeComponent();
            constmenu = n;
            this.DataContext = constmenu;
            tb_id.Text = n.IDmenu.ToString();
            tb_name.Text = n.NameDish;
            tb_description.Text = n.description;
            tb_price.Text = n.Price.ToString();

            cb_country.ItemsSource = DBConnection.connection.Country.ToList();
            cb_country.DisplayMemberPath = "NameCountry";

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_delite_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.DeleteDish(constmenu);
            MessageBox.Show($"Блюдо {constmenu.NameDish} удалено");
            NavigationService.Navigate(new MenuPage(MenuPage.globAdmin));
        }

        private void tb_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0) && e.Text != "-")
            {
                e.Handled = true;
            }
        }

        private void btn_newphoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                constmenu.img = File.ReadAllBytes(openFile.FileName);
                img_prod.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            constmenu.NameDish = tb_name.Text;
            constmenu.description = tb_description.Text;
            constmenu.Price = Convert.ToInt32(tb_price.Text);
            constmenu.IsDelete = false;
            constmenu.IsST = false;
            if (cb_country.SelectedIndex == 0)
            {
                constmenu.IDcountry = 1;
            }
            else if (cb_country.SelectedIndex == 1)
            {
                constmenu.IDcountry = 2;
            }
            else if (cb_country.SelectedIndex == 2)
            {
                constmenu.IDcountry = 3;
            }

            if (rb_hd.IsChecked == true)
            {
                constmenu.IDtype = 1;
            }
            else if (rb_cd.IsChecked == true)
            {
                constmenu.IDtype = 2;
            }
            else if (rb_zak.IsChecked == true)
            {
                constmenu.IDtype = 3;
            }
            else if (rb_sd.IsChecked == true)
            {
                constmenu.IDtype = 4;
            }
            else if (rb_dr.IsChecked == true)
            {
                constmenu.IDtype = 5;
            }

            DataAccess.AddDish(constmenu);
            NavigationService.Navigate(new MenuPage(MenuPage.globAdmin));

        }
    }
}
