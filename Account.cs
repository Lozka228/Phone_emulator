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
        public int Id { get; set; } 
        public string Full_owner_name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public _Currency Currency { get; set; } = _Currency.USD;
    }
}