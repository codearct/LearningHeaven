using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DbFirst.Entities;

#nullable disable

namespace DbFirst.DataAccess
{
    public partial class MovieStoreContext : DbContext
    {
        public MovieStoreContext()
        {
        }

        public MovieStoreContext(DbContextOptions<MovieStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MoviePerformer> MoviePerformers { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MovieStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasComment("TRIAL");

                entity.Property(e => e.Id).HasComment("TRIAL");

                entity.Property(e => e.UserId).HasComment("TRIAL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasComment("TRIAL");

                entity.Property(e => e.Id).HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("TRIAL");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial782)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL782")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasComment("TRIAL");

                entity.Property(e => e.Id).HasComment("TRIAL");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial782)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL782")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasComment("TRIAL");

                entity.HasIndex(e => e.Price, "idx_Price")
                    .IsUnique();

                entity.Property(e => e.Id).HasComment("TRIAL");

                entity.Property(e => e.DirectorId).HasComment("TRIAL");

                entity.Property(e => e.GenreId).HasComment("TRIAL");

                entity.Property(e => e.Price).HasComment("TRIAL");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasComment("TRIAL");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial782)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL782")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("DirectorId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("GenreId");
            });

            modelBuilder.Entity<MoviePerformer>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.PerformerId })
                    .HasName("movieperformers_pkey");

                entity.HasComment("TRIAL");

                entity.Property(e => e.MovieId).HasComment("TRIAL");

                entity.Property(e => e.PerformerId).HasComment("TRIAL");

                entity.Property(e => e.Trial782)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL782")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MoviePerformers)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MovieId");

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.MoviePerformers)
                    .HasForeignKey(d => d.PerformerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PerformerId");
            });

            modelBuilder.Entity<OperationClaim>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasComment("TRIAL");

                entity.Property(e => e.Id).HasComment("TRIAL");

                entity.Property(e => e.MovieId).HasComment("TRIAL");

                entity.Property(e => e.MoviePrice).HasComment("TRIAL");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("date")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial782)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL782")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.Property(e => e.UserId).HasComment("TRIAL");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("movie_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_Id");
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.HasComment("TRIAL");

                entity.Property(e => e.Id).HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("TRIAL");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial782)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL782")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength(true);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
