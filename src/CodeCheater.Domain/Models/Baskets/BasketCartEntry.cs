namespace CodeCheater.Domain.Models.Baskets
{
    public class BasketCartEntry
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quanity { get; set; }

    }
}
