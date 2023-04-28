namespace StoreSystem.Entities
{
    using StoreEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ImportPermit
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public string PermitNumber { get; set; }

        [Column(TypeName = "Date")]
        public DateTime PermitDate { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        [Column(TypeName = "Date")]

        public DateTime ProductionDate { get; set; }
        
        [Column(TypeName = "Date")]
        public DateTime ExpirationDate { get; set; }
        public ICollection<ImportPermitItem> Items { get; set; }
    }
}
