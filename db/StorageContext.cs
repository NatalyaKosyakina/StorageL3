using Microsoft.EntityFrameworkCore;
using StorageL3.Models;

namespace StorageL3.db
{
    public partial class StorageContext : DbContext
    {
        public DbSet<Storage> Storages { get; set; }
        public DbSet<ProductStorage> productStorages { get; set; }
        private string _connectionString = "Host=localhost;Username=postgres;Password=example;Database=StorageL3";

        public StorageContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Storage>(ent =>
            {
                ent.HasKey(x => x.Id);
                ent.Property(x => x.Id);
                ent.Property(x => x.Name).HasMaxLength(255);
            });
            modelBuilder.Entity<ProductStorage>(ent =>
            {
                ent.HasKey(x => x.StorageID);
                ent.HasKey(x => x.ProductId);
                ent.Property(x => x.Count);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
