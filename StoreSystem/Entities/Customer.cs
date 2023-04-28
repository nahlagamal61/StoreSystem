namespace StoreEntities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }

       // public int StoreId { get; set; }

       // public Store Store { get; set; }
    }
}
