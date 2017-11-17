namespace CatalogModel.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Catalog : DbContext
    {
        public Catalog()
            : base("name=Catalog")
        {
        }

        public virtual DbSet<AccessRights> AccessRights { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Conditioner> Conditioner { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Heater> Heater { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Instalation> Instalation { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDelivery> OrderDelivery { get; set; }
        public virtual DbSet<OrderInstalation> OrderInstalation { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessRights>()
                .HasMany(e => e.User)
                .WithOptional(e => e.AccessRights)
                .HasForeignKey(e => e.FK_AccessRights);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Brand)
                .HasForeignKey(e => e.FK_Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.Cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.OrderDelivery)
                .WithRequired(e => e.Delivery)
                .HasForeignKey(e => e.FK_Delivery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Image)
                .HasForeignKey(e => e.FK_Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Image)
                .HasForeignKey(e => e.FK_Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Instalation>()
                .Property(e => e.Cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Instalation>()
                .HasMany(e => e.OrderInstalation)
                .WithRequired(e => e.Instalation)
                .HasForeignKey(e => e.FK_Instalation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDelivery)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.FK_Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderInstalation)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.FK_Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Conditioner)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Heater)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Image1)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.FK_Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.FK_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Review)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.FK_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Review>()
                .HasMany(e => e.Image)
                .WithOptional(e => e.Review)
                .HasForeignKey(e => e.FK_Review);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.FK_Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Review)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_User)
                .WillCascadeOnDelete(false);
        }
    }
}
