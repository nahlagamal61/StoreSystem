namespace StoreSystem.Entities
{
    using StoreEntities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TransferItem
    {
        public int Id { get; set; }
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
        public int Quantity { get; set; }
        
        public int ProductId { get; set; }
        
        public Product Product { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ProductionDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ExpirationDate { get; set; }

    }
}