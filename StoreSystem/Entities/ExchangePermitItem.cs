namespace StoreSystem.Entities
{
    using StoreEntities;

    public class ExchangePermitItem
    {
        public int Id { get; set; }
        public int ExchangePermitId { get; set; }
        public ExchangePermit ExchangePermit { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}