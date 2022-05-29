using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnOnOwn
{
    public static class DataAccess
    {
        public static bool globAdmin;
        public static ObservableCollection<menu> menu { get; set; }
        public static List<menu> menu2show { get; set; }
        public static bool AddDish(menu menu)
        {
            try
            {
                DBConnection.connection.menu.Add(menu);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
        public static bool DoOrder(Order order)
        {
            try
            {
                DBConnection.connection.Order.Add(order);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DoOrderMenu(OrderMenu orderMenu)
        {
            try
            {
                DBConnection.connection.OrderMenu.Add(orderMenu);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteSL()
        {
            try
            {
                DBConnection.connection.menu.FirstOrDefault();
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
