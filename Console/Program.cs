using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnOnOwn;

namespace OnOnOwnConsole
{
    internal class Program
    {
        public static ObservableCollection<menu> menu { get; set; }
        static void Main(string[] args)
        {
            menu menu;
            bool auth = false;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Добро пожаловать в OnOnOwn, что желаете заказать?");
            string Dish = Console.ReadLine();
            while (Dish != "0")
            {
                Console.WriteLine("Выберите № блюда, для вывода чека введите 0");
                Console.WriteLine();
                Dish = Console.ReadLine();


            }


        }
    }
}
