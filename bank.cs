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

            var accounts = AccountStorage.Load();
            while (_bank)
            {
                print_menu();

                

                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "0":
                        _bank = false;
                        continue;

                    case "1":
                        foreach (var acc in accounts)
                        {
                            Console.WriteLine($"№{acc.Id} {acc.Full_owner_name}: {acc.Balance} {acc.Currency}");
                        }
                        break;

                    case "2":
                        // Создать счет

                        string name = Environment.GetEnvironmentVariable("login");
                        Console.WriteLine("Введите сумму:");
                        decimal balance = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Введите валюту (1. USD 2. EUR 3. RUB):");
                        string currency_str = Console.ReadLine();
                        _Currency currency = _Currency.USD;

                        switch (currency_str)
                        {
                            case "1": 
                                currency = _Currency.USD;
                                break;
                            case "2":
                                currency = _Currency.EUR;
                                break;
                            case "3":
                                currency = _Currency.RUB;
                                break;
                            default:
                                break;
                        }

                        accounts.Add(new Account
                        {
                            Full_owner_name = name,
                            Balance = balance,
                            Currency = currency
                        });

                        Console.WriteLine("Счет был успешно создан!");
                        break;
                    case "3":
                        Console.WriteLine("Введите номер счета:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите сумму для пополнения:");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());

                        Operation.Deposit(accounts, id, amount);
                        break;
                    case "4":
                        Console.WriteLine("Введите номер счета:");
                        int idq = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите сумму для снятия:");
                        decimal amountq = Convert.ToDecimal(Console.ReadLine());

                        Operation.Withdraw(accounts, idq, amountq);
                        break;
                    case "5":
                        Console.WriteLine("Введите номер счета, с которого снимаем:");
                        int from = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите номер счета, на который переводим:");
                        int to = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите сумму для перевода:");
                        decimal amount_transfer = Convert.ToDecimal(Console.ReadLine());

                        Operation.Transfer(accounts, from, to, amount_transfer);
                        break;
                }
                Thread.Sleep(3000);
                Console.Clear();
                AccountStorage.Save(accounts);
            }
        }
    }
}