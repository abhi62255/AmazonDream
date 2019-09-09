using AmazonDream.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AmazonDream.DAL
{
    public class AmazonDreamDbContext : DbContext
    {
        public AmazonDreamDbContext():base()
        {

        }
        public AmazonDreamDbContext(DbContextOptions<AmazonDreamDbContext> options) : base(options) { }
      
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPicture> ProductPicture { get; set; }
        public virtual DbSet<Entities.Kart> Kart { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<PlacedOrder> PlacedOrder { get; set; }







        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=XIPL9378\SQLEXPRESS;Database=AmazonDreamDatabase;Trusted_Connection=True;");
    }
}
