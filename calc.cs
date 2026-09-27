using System;

namespace Phone
{
    class Calculator
    {
        public static void basic_calculator()
        {
            try
            {
                Console.WriteLine("Введите первое число:");
                int num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите второе число:");
                int num2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите операцию:");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "+":
                        Console.WriteLine($"{num1} + {num2} = {num1+num2}");
                        break;
                    
                    case "-":
                        Console.WriteLine($"{num1} - {num2} = {num1-num2}");
                        break;

                    case "*":
                        Console.WriteLine($"{num1} * {num2} = {num1*num2}");
                        break;

                    case "/":
                        if (num2 != 0)
                            Console.WriteLine($"{num1} / {num2} = {num1/num2}");
                        else
                            Console.WriteLine("Деление на ноль!");
                        break;

                    default:
                        Console.WriteLine($"Неизвестная операция '{op}'");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex}");
            }
        }
    }
}
