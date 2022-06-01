﻿using System;
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
        public static ObservableCollection<menu> GetAllMenu()
        {
            var listBase = new ObservableCollection<menu>();

            foreach (var i in Getmenu())
            {
                var gh = new menu();
                gh.IDmenu = i.IDmenu;
                gh.NameDish = i.NameDish;
                gh.description = i.description;
                gh.IsST = i.IsST;
                gh.IsDelete = i.IsDelete;
                gh.Price = i.Price;
                listBase.Add(gh);
            }
            return listBase;
        }
        public static ObservableCollection<OrderMenu> GetAllOrderMenu()
        {
            var listBase = new ObservableCollection<OrderMenu>();

            foreach (var i in GetOrderMenu())
            {
                var m = new OrderMenu();
                m.IDMenu = i.IDMenu;
                m.price = i.price;
                m.IDorder = i.IDorder;
                m.IsOrder = i.IsOrder;
                listBase.Add(m);
            }
            return listBase;
        }


    }
}
