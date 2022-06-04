using OnOnOwn;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConsoleOnOnOwn
{
    internal class Program
    {
        public static ObservableCollection<menu> Menu { get; set; }
        public static ObservableCollection<OrderMenu> OrdMen { get; set; }
        public static ObservableCollection<Order> Ord { get; set; }
        public static int current2Order;
        public static int fullprice;


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Menu = new ObservableCollection<menu>(DBConnection.connection.menu.Where(x => (bool)x.IsST == false && x.IsDelete == false).ToList());

            var newOrd = new Order();

            Console.WriteLine("Добро пожаловать в OnOnOwn, что желаете заказать?");
            int Dish = 1;
            while (Dish != 0)
            {
                Console.WriteLine("Выберите № блюда, для вывода чека введите 0");
                Console.WriteLine();
                foreach (menu c in Menu)
                {
                    Console.WriteLine(c.IDmenu + ".  " + c.NameDish + " " + c.Price + " " + c.description);
                }
                Dish = Convert.ToInt32(Console.ReadLine());

                var menuToAdd = DataAccess.GetToIdMenu(Dish);
                var newOM = new OrderMenu();
                    
                    newOM.price = menuToAdd.Price;
                    newOM.IDMenu = menuToAdd.IDmenu;
                    newOM.IsOrder = true;
                    newOM.IDorder = newOrd.idOrder = current2Order;
                    
                DataAccess.DoOrderMenu(newOM);
            }
            OrdMen = new ObservableCollection<OrderMenu>(DBConnection.connection.OrderMenu.Where(x => x.IDorder == current2Order && x.IsOrder == true).ToList());
            foreach (OrderMenu a in OrdMen)
            {
                Console.WriteLine(a.IDom + ".  " + a.menu.NameDish + " " + a.price);
                fullprice += (int)a.price;
            }
            newOrd.idStol = 1;
            newOrd.FullPrice = fullprice;
            Console.WriteLine("Общая сумма = " + fullprice);

        }

    }
}
