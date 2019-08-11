using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace moviewBackEnd.Model
{
    public partial class moviewContext : DbContext
    {
        public moviewContext()
        {
        }

        public moviewContext(DbContextOptions<moviewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:moview.database.windows.net,1433;Initial Catalog=moview;Persist Security Info=False;User ID=Pranavan;Password=Potplant23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__Movies__4BD2943ACEB391D1");

                entity.Property(e => e.Movie).IsUnicode(false);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__Reviews__74BC79CE3D561A44");

                entity.Property(e => e.Review).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("MovieId");

                entity.HasOne(d => d.UserKeyNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserKey)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("UserKey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserKey)
                    .HasName("PK__Users__296ADCF15246A6F9");

                entity.Property(e => e.FullName).IsUnicode(false);
            });
        }
    }
}
