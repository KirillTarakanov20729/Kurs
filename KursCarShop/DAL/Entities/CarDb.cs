using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class CarDb : DbContext
    {
        public CarDb()
            : base("name=CarDb")
        {
        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Model)
                .WithRequired(e => e.Brand)
                .HasForeignKey(e => e.brand_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.colour)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.car_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.FIO)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.phone)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.client_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.phone)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.FIO)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.employee_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.transmission)
                .IsFixedLength();

            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.Car)
                .WithRequired(e => e.Equipment)
                .HasForeignKey(e => e.equipment_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Model>()
                .HasMany(e => e.Equipment)
                .WithRequired(e => e.Model)
                .HasForeignKey(e => e.model_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.type1)
                .IsFixedLength();

            modelBuilder.Entity<Type>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
