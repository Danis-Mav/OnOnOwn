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
        public static ObservableCollection<menu> Getmenu()
        {
            return new ObservableCollection<menu>(DBConnection.connection.menu.ToList());
        }
        public static ObservableCollection<OrderMenu> GetOrderMenu()
        {
            return new ObservableCollection<OrderMenu>(DBConnection.connection.OrderMenu.ToList());
        }
        public static OrderMenu GetOrderMenu(int IdOM)
        {
            ObservableCollection<OrderMenu> users = new ObservableCollection<OrderMenu>(DBConnection.connection.OrderMenu);
            var currentPet = users.Where(u => u.IDom == IdOM).FirstOrDefault();
            return currentPet;
        }
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

        public static void AddMenu(string nameDish, int price, string description, int dcountry, int dtype, bool isDelete, bool isST)
        {
            var m = new menu();
            m.NameDish = nameDish;
            m.Price = price;
            m.description = description;
            m.IDcountry = dcountry;
            m.IDtype = dtype;
            m.IsDelete = isDelete;
            m.IsST = isST;
            DBConnection.connection.menu.Add(m);
            DBConnection.connection.SaveChanges();
        }

        public static void AddOrderMenu(int idmenu, int price, int idorder, bool isOrder)
        {
            var m = new OrderMenu();
            m.IDMenu = idmenu;
            m.price = price;
            m.IDorder = idorder;
            m.IsOrder = isOrder;
            DBConnection.connection.OrderMenu.Add(m);
            DBConnection.connection.SaveChanges();
        }

        public static bool EditDish(menu menu)
        {
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
       
        public static void RemoveDish(int id)
        {
            DBConnection.connection.OrderMenu.Remove(GetOrderMenu(id));
            DBConnection.connection.SaveChanges();
        }
        public static menu GetToIdMenu(int id)
        {
            return DBConnection.connection.menu.Where(x=> x.IDmenu == id).FirstOrDefault();
        }
    }
}
