

namespace Phone
{
    public class Operation
    {
        // Пополнение счета
        public static void Deposit(List<Account> accounts, int id, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма должна быть больше нуля");
                return;
            }

            var acc = AccountStorage.FindById(accounts, id);
            if (acc == null)
            {
                Console.WriteLine($"Счёт с Id={id} не найден");
                return;
            }

            acc.Balance += amount;
            Console.WriteLine($"Счёт {id} пополнен на {amount} {acc.Currency}. Баланс: {acc.Balance}");
        }

        // Снятие средств
        public static void Withdraw(List<Account> accounts, int id, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма должна быть больше нуля");
                return;
            }

            var acc = AccountStorage.FindById(accounts, id);
            if (acc == null)
            {
                Console.WriteLine($"Счёт с Id={id} не найден");
                return;
            }

            if (acc.Balance < amount)
            {
                Console.WriteLine($"Недостаточно средств. На счёте: {acc.Balance}, нужно: {amount}");
                return;
            }

            acc.Balance -= amount;
            Console.WriteLine($"Со счёта {id} снято {amount} {acc.Currency}. Баланс: {acc.Balance}");
        }
        public static void Transfer(List<Account> accounts, int fromId, int toId, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма должна быть больше нуля");
                return;
            }

            if (fromId == toId)
            {
                Console.WriteLine("Нельзя перевести на тот же счёт");
                return;
            }

            var from = AccountStorage.FindById(accounts, fromId);
            var to = AccountStorage.FindById(accounts, toId);

            if (from == null) { Console.WriteLine($"Счёт отправителя {fromId} не найден"); return; }
            if (to == null) { Console.WriteLine($"Счёт получателя {toId} не найден"); return; }

            if (from.Currency != to.Currency)
            {
                Console.WriteLine($"Разные валюты: {from.Currency} → {to.Currency}. Перевод невозможен");
                return;
            }

            if (from.Balance < amount)
            {
                Console.WriteLine($"Недостаточно средств. На счёте {fromId}: {from.Balance}, нужно: {amount}");
                return;
            }

            // Сначала списываем, потом зачисляем — только после всех проверок!
            from.Balance -= amount;
            to.Balance += amount;

            Console.WriteLine($"Переведено {amount} {from.Currency} со счёта {fromId} на счёт {toId}");
        }
    }
}