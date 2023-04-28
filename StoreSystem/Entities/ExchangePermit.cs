namespace StoreSystem.Entities
{
    using StoreEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExchangePermit
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public string PermitNumber { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
  
        public ICollection<ExchangePermitItem> Items { get; set; }


        [Column(TypeName = "Date")]
        public DateTime PermitDate { get; set; }


    }
}
