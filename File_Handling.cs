using System.Text.Json;

/*
Работа с записями банковских счетов нашего единственного пользователя

*/
namespace Phone
{
    public static class AccountStorage
    {
        // Путь к файлу рядом с программой
        private static readonly string FilePath = "accounts.json";

        // Настройки, чтобы русские буквы в JSON читались нормально
        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        // Сохранить список счетов в файл
        public static void Save(List<Account> accounts)
        {
            string json = JsonSerializer.Serialize(accounts, Options);
            File.WriteAllText(FilePath, json);
        }

        // Загрузить список счетов из файла
        // Если файла нет - вернёт пустой список
        public static List<Account> Load()
        {
            if (!File.Exists(FilePath))
                return new List<Account>();

            string json = File.ReadAllText(FilePath);
            var accounts = JsonSerializer.Deserialize<List<Account>>(json, Options)
                           ?? new List<Account>();

            // ВАЖНО: обновляем статический счётчик, чтобы новые счета
            // получали уникальные Id, а не начинали с 1
            if (accounts.Count > 0)
            {
                int maxId = 0;
                foreach (var acc in accounts)
                    if (acc.Id > maxId) maxId = acc.Id;

                Account.SyncNextId(maxId);
            }

            return accounts;        }

        public static Account? FindById(List<Account> accounts, int id)
        {
            foreach (var acc in accounts)
            {
                if (acc.Id == id)
                    return acc;
            }
            return null; // не нашли
        }
    }
}