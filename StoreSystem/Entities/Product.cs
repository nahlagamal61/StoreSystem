namespace StoreEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public string UnitOfMeasurement { get; set; }

        [Column(TypeName = "Date")]
        public DateTime AddDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ExpirationDate { get; set; }


        public int StoreId { get; set; } 
        public virtual Store  Store { get; set; }

    }
}
