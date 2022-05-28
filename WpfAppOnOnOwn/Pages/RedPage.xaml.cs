using Microsoft.Win32;
using OnOnOwn;
using System;
using System.Collections.Generic;
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
        public static menu constmenu;
        public RedPage(menu n)
        {
            InitializeComponent();
            constmenu = n;
            this.DataContext = constmenu;
            tb_id.Text = n.IDmenu.ToString();
            tb_name.Text = n.NameDish;
            tb_description.Text = n.description;

            cb_country.ItemsSource = DBConnection.connection.Country.ToList();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public static bool DeleteDish(menu menu)
        {
            menu.IsDelete = true;
            try
            {
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btn_delite_Click(object sender, RoutedEventArgs e)
        {
            DeleteDish(constmenu);
            MessageBox.Show($"Блюдо {constmenu.NameDish} удалено");
            NavigationService.GoBack();
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
            constmenu.Price = Convert.ToInt32(tb_price);
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
            DBConnection.connection.SaveChanges();
            NavigationService.Navigate(new MenuPage(MenuPage.globAdmin));
        }
    }
}
