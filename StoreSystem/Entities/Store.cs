namespace StoreEntities
{
    using StoreSystem.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Employee ResponsablePerson { get; set; } 

        public virtual ICollection<Product>  Products { get; set; }

        public virtual ICollection<ImportPermit> ImportPermits { get; set; }
        public virtual ICollection<ExchangePermit> ExchangePermits { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }


    }
}
