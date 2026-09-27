using System;

namespace Phone
{
    class Bank
    {
        public static void basic_emulator()
        {
            if (!check_login())
            {
                Console.WriteLine("Неверные пароль или логин.");
                return;
            }

            print_menu();
        }

        static bool check_login()
        {
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль:");
            string pswd = Console.ReadLine();

            if (login == "admin" && pswd == "admin")
                return true;
            else
                return false;
        }

        static void print_menu()
        {
            Console.WriteLine("");
        }
    }
}