using MealOrdering.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Server.Data.Context
{
    public class MealOrderingDbContext : DbContext
    {
        public MealOrderingDbContext(DbContextOptions<MealOrderingDbContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "public");

                entity.HasKey(i => i.Id).HasName("pk_user_id");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("UUID_GENERATE_V4()").IsRequired();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("character varying").HasMaxLength(100);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("character varying").HasMaxLength(100);
                entity.Property(i => i.EMailAdress).HasColumnName("email_address").HasColumnType("character varying").HasMaxLength(100);
                entity.Property(i => i.Password).HasColumnName("password").HasColumnType("character varying").HasMaxLength(250);

                entity.Property(i => i.CreateDate).HasColumnName("create_date").HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                entity.Property(i => i.IsActive).HasColumnName("isactive").HasColumnType("boolean");

            });


            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_supplier_id");

                entity.ToTable("suppliers", "public");

                entity.Property(e => e.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("public.uuid_generate_v4()").IsRequired();

                entity.Property(e => e.IsActive).HasColumnName("isactive").HasColumnType("boolean");
                entity.Property(e => e.Name).HasColumnName("name").HasColumnType("character varying").HasMaxLength(100);
                entity.Property(e => e.CreateDate).HasColumnName("createdate").HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();

                entity.Property(e => e.WebUrl).HasColumnName("web_url").HasColumnType("character varying").HasMaxLength(500);
            });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id)
                    .HasName("pk_order_id");

                entity.ToTable("orders", "public");

                entity.Property(o => o.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("public.uuid_generate_v4()");
                entity.Property(o => o.Name).HasColumnName("name").HasColumnType("character varying").HasMaxLength(100);
                entity.Property(o => o.Description).HasColumnName("description").HasColumnType("character varying").HasMaxLength(1000);

                entity.Property(o => o.CreateDate).HasColumnName("createdate").HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
                entity.Property(o => o.CreatedUserId).HasColumnName("created_user_id").HasColumnType("uuid");
                entity.Property(o => o.SupplierId).HasColumnName("supplier_id").HasColumnType("uuid").IsRequired().ValueGeneratedNever();
                entity.Property(o => o.ExpireDate).HasColumnName("expire_date").HasColumnType("timestamp without time zone").IsRequired();


                entity.HasOne(d => d.CreatedUser)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(d => d.CreatedUserId)
                   .HasConstraintName("fk_user_order_id")
                   .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Supplier)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(d => d.SupplierId)
                   .HasConstraintName("fk_supplier_order_id")
                   .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_orderItem_id");

                entity.ToTable("order_items", "public");

                entity.Property(e => e.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("public.uuid_generate_v4()");
                entity.Property(e => e.Description).HasColumnName("description").HasColumnType("character varying").HasMaxLength(1000);
                entity.Property(e => e.CreateDate).HasColumnName("createdate").HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()");
                entity.Property(e => e.CreatedUserId).HasColumnName("created_user_id").HasColumnType("uuid");
                entity.Property(e => e.OrderId).HasColumnName("order_id").HasColumnType("uuid");


                entity.HasOne(d => d.Order)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(d => d.OrderId)
                   .HasConstraintName("fk_orderitems_order_id")
                   .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.CreatedUser)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(d => d.CreatedUserId)
                   .HasConstraintName("fk_orderitems_user_id")
                   .OnDelete(DeleteBehavior.Cascade);

            });




            base.OnModelCreating(modelBuilder);
        }
    }
}