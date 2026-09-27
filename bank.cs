using System;
using dotenv.net; // Всё со строчной (маленькой) буквы


namespace Phone
{
    class Bank
    {
        public static void basic_emulator()
        {
            DotEnv.Load();
            if (!check_login())
            {
                Console.WriteLine("Неверные пароль или логин.");
                return;
            }

            Console.WriteLine("Вход выполнен!");

            bank_cycle();
        }

        static bool check_login()
        {
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль:");
            string pswd = Console.ReadLine();

            if (login == Environment.GetEnvironmentVariable("login") &&
                pswd == Environment.GetEnvironmentVariable("pswd"))
                return true;
            else
                return false;
        }

        static void print_menu()
        {
            Console.WriteLine("Меню нашего банковского приложения:");
            Console.WriteLine("1. Посмотреть счета");
            Console.WriteLine("2. Создать счет");
            Console.WriteLine("3. Пополниь счет");
            Console.WriteLine("4. Снять деньги");
            Console.WriteLine("5. Перевод между счетами");
            Console.WriteLine("0. Выход");
        }

        static void bank_cycle()
        {
            bool _bank = true;

            while (_bank)
            {
                print_menu();

                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "0":
                        _bank = false;
                        return;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                }
            }
        }
    }
}