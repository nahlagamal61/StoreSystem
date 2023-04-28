namespace StoreSystem.Entities
{
    using StoreEntities;

    public class ImportPermitItem
    {
        public int Id { get; set; }
        public int ImportPermitId { get; set; }
        public ImportPermit ImportPermit { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}