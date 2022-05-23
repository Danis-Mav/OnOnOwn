using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnOnOwn
{
    public class Class1
    {
    }
    internal class DBconnection
    {
        public static OnOnOwnEntities connection = new OnOnOwnEntities();
    }
    
    public static class DataAccess
    {
        public static List<menu> Getmenu()
        {
            List<menu> alk = new List<menu>(DBconnection.connection.menu);
            List<menu> menu = new List<menu>();
            foreach (var t in alk)
            {
                menu.Add(
                new menu
                {
                    IDmenu = t.IDmenu,
                    NameDish = t.NameDish,
                    Price = t.Price,
                });
            }
            return menu;
        }

        public static menu Getmenu(int Id_menu)
        {
            List<menu> users = Getmenu();
            return users.Where(a => a.IDmenu == Id_menu).FirstOrDefault();
        }

        public static menu Getmenu(string Name)
        {
            List<menu> userss = Getmenu();
            return userss.Where(t => t.NameDish == Name).FirstOrDefault();
        }
        public static bool AddNewmenu(menu users)
        {
            try
            {
                DBconnection.connection.menu.Add(users);
                DBconnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void Updatemenu(int Id_menu, menu users)
        {

            DBconnection.connection.menu.SingleOrDefault(t => t.IDmenu == Id_menu);
            DBconnection.connection.SaveChanges();

        }

        public static void Deletemenu(string name)
        {
            menu deletmenu = DBconnection.connection.menu.FirstOrDefault<menu>(p => p.NameDish == name);
            DBconnection.connection.menu.Remove(deletmenu);
            DBconnection.connection.SaveChanges();
        }
        public static void Deletemenu(int id)
        {
            menu deletAuto = DBconnection.connection.menu.FirstOrDefault<menu>(p => p.IDmenu == id);
            DBconnection.connection.menu.Remove(deletAuto);
            DBconnection.connection.SaveChanges();
        }

    }
}
