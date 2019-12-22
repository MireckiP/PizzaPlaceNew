using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaPlace.Models
{
    public partial class PizzaContext : DbContext
    {
        public PizzaContext()
        {
        }

        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerHasOrder> CustomerHasOrder { get; set; }
        public virtual DbSet<Deals> Deals { get; set; }
        public virtual DbSet<Extras> Extras { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<OrderHasDeals> OrderHasDeals { get; set; }
        public virtual DbSet<OrderHasExtras> OrderHasExtras { get; set; }
        public virtual DbSet<OrderHasPizzas> OrderHasPizzas { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonType> PersonType { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaHasIngredient> PizzaHasIngredient { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Pizza;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerHasOrder>(entity =>
            {
                entity.HasKey(e => new { e.PersonIdPerson, e.OrderIdOrder })
                    .HasName("CustomerHasOrder_pk");

                entity.Property(e => e.PersonIdPerson).HasColumnName("Person_Id_Person");

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_Id_Order");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.CustomerHasOrder)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerHasOrder_Order");

                entity.HasOne(d => d.PersonIdPersonNavigation)
                    .WithMany(p => p.CustomerHasOrder)
                    .HasForeignKey(d => d.PersonIdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerHasOrder_Person");
            });

            modelBuilder.Entity<Deals>(entity =>
            {
                entity.HasKey(e => e.IdDeals)
                    .HasName("Deals_pk");

                entity.Property(e => e.IdDeals)
                    .HasColumnName("Id_Deals")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.DealName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Extras>(entity =>
            {
                entity.HasKey(e => e.IdExtras)
                    .HasName("Extras_pk");

                entity.Property(e => e.IdExtras)
                    .HasColumnName("Id_Extras")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ExtraName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExtraPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IdIngredient)
                    .HasName("Ingredient_pk");

                entity.Property(e => e.IdIngredient)
                    .HasColumnName("Id_Ingredient")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IngredientPrice).HasColumnType("money");
            });

            modelBuilder.Entity<OrderHasDeals>(entity =>
            {
                entity.HasKey(e => new { e.OrderIdOrder, e.DealsIdDeals })
                    .HasName("OrderHasDeals_pk");

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_Id_Order");

                entity.Property(e => e.DealsIdDeals).HasColumnName("Deals_Id_Deals");

                entity.HasOne(d => d.DealsIdDealsNavigation)
                    .WithMany(p => p.OrderHasDeals)
                    .HasForeignKey(d => d.DealsIdDeals)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderHasDeals_Deals");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.OrderHasDeals)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderHasDeals_Order");
            });

            modelBuilder.Entity<OrderHasExtras>(entity =>
            {
                entity.HasKey(e => new { e.OrderIdOrder, e.ExtrasIdExtras })
                    .HasName("OrderHasExtras_pk");

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_Id_Order");

                entity.Property(e => e.ExtrasIdExtras).HasColumnName("Extras_Id_Extras");

                entity.HasOne(d => d.ExtrasIdExtrasNavigation)
                    .WithMany(p => p.OrderHasExtras)
                    .HasForeignKey(d => d.ExtrasIdExtras)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderHasExtras_Extras");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.OrderHasExtras)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderHasExtras_Order");
            });

            modelBuilder.Entity<OrderHasPizzas>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.OrderIdOrder })
                    .HasName("OrderHasPizzas_pk");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_Id_Pizza");

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_Id_Order");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.OrderHasPizzas)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderHasPizzas_Order");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.OrderHasPizzas)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderHasPizzas_Pizza");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("Person_pk");

                entity.Property(e => e.IdPerson)
                    .HasColumnName("Id_Person")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonTypeIdPersonType).HasColumnName("PersonType_Id_PersonType");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.PersonTypeIdPersonTypeNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.PersonTypeIdPersonType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_PersonType");
            });

            modelBuilder.Entity<PersonType>(entity =>
            {
                entity.HasKey(e => e.IdPersonType)
                    .HasName("PersonType_pk");

                entity.Property(e => e.IdPersonType)
                    .HasColumnName("Id_PersonType")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.TypeOfPerson)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("Id_Pizza")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaPrice).HasColumnType("money");
            });

            modelBuilder.Entity<PizzaHasIngredient>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.IngredientIdIngredient })
                    .HasName("PizzaHasIngredient_pk");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_Id_Pizza");

                entity.Property(e => e.IngredientIdIngredient).HasColumnName("Ingredient_Id_Ingredient");

                entity.HasOne(d => d.IngredientIdIngredientNavigation)
                    .WithMany(p => p.PizzaHasIngredient)
                    .HasForeignKey(d => d.IngredientIdIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaHasIngredient_Ingredient");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaHasIngredient)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaHasIngredient_Pizza");
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("Order_pk");

                entity.Property(e => e.IdOrder)
                    .HasColumnName("Id_Order")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ActualDelivery).HasColumnType("datetime");

                entity.Property(e => e.EstimatedDelivery).HasColumnType("datetime");

                entity.Property(e => e.PersonDelivering).HasColumnName("Person_Delivering");

                entity.Property(e => e.PersonSupervising).HasColumnName("Person_Supervising");

                entity.Property(e => e.TimeOrdered).HasColumnType("datetime");

                entity.Property(e => e.TimePrepared).HasColumnType("datetime");

                entity.HasOne(d => d.PersonDeliveringNavigation)
                    .WithMany(p => p.PizzaOrderPersonDeliveringNavigation)
                    .HasForeignKey(d => d.PersonDelivering)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Supervisor");

                entity.HasOne(d => d.PersonSupervisingNavigation)
                    .WithMany(p => p.PizzaOrderPersonSupervisingNavigation)
                    .HasForeignKey(d => d.PersonSupervising)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Deliverer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
