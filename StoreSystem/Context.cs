namespace StoreSystem
{
    using StoreEntities;
    using StoreSystem.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Context :DbContext
    {
        public Context():base(@"Data Source=.;Initial Catalog=StoreSystem; Integrated Security=true;")
        {}
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ImportPermitItem>()
           .HasRequired(x => x.ImportPermit)
           .WithMany(x => x.Items)
           .HasForeignKey(x => x.ImportPermitId)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExchangePermitItem>()
           .HasRequired(x => x.ExchangePermit)
           .WithMany(x => x.Items)
           .HasForeignKey(x => x.ExchangePermitId)
           .WillCascadeOnDelete(false);


            modelBuilder.Entity<TransferItem>()
               .HasRequired(x => x.Transfer)
               .WithMany(x => x.Items)
               .HasForeignKey(x => x.TransferId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transfer>()
            .HasRequired(x => x.ToStore)
            .WithMany()
            .HasForeignKey(x => x.ToStoreId)
            .WillCascadeOnDelete(false);



        }

        public DbSet<Store> Store { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<ImportPermit> ImportPermit { get; set; }

        public DbSet<ImportPermitItem> ImportPermitItems { get; set; }

        public DbSet<ExchangePermit> ExchangePermit { get; set; }
        public DbSet<ExchangePermitItem> ExchangePermitItem { get; set; }

        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransferItem> TransferItems { get; set; }

    }
}
