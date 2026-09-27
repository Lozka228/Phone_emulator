/*
Класс для банковского счета клиента
+ виды валют
*/

namespace Phone
{
    public enum _Currency
    {
        USD,
        EUR,
        RUB,
    }
    public class Account
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Full_owner_name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public _Currency Currency { get; set; } = _Currency.USD;

        public Account()
        {
            Id = _nextId++;
        }

        // Синхронизация счётчика с уже существующими счетами,
        // чтобы новый счёт не получил занятый Id
        public static void SyncNextId(int lastUsedId)
        {
            if (lastUsedId >= _nextId)
                _nextId = lastUsedId + 1;
        }
    }
}