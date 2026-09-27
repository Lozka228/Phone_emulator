using System;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            bool _pragma = true;
            while (_pragma)
            {
                Console.WriteLine($"Привет, куда отправимся?\n1.Калькулятор\n2.Банковское приложение");

                String answ = Console.ReadLine();
                switch (answ)
                {
                    case "1":
                        Calculator.basic_calculator();
                        break;

                    case "2":
                    Bank.basic_emulator();
                        break;

                    case "выход":
                        _pragma = false;
                        break;

                    default:
                        Console.WriteLine("Не очевидный ввод, попробуйте снова");
                        break;
                }

                Console.WriteLine("Выходим в главное меню...");
            }
            Console.WriteLine("Конец порграммы.");
        }
    }
}
