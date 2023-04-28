namespace StoreSystem.Entities
{
    using StoreEntities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Transfer
    {
        public int Id { get; set; }
        public int FromStoreId { get; set; }
        public Store FromStore { get; set; }
        public int ToStoreId { get; set; }
        public Store ToStore { get; set; }
        [Column(TypeName ="Date")]
        public DateTime TransferDate { get; set; }
        public ICollection<TransferItem> Items { get; set; }

    }
}
