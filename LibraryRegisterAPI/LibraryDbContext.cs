using LibraryRegisterAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryEntityFramework
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rental>()
                .HasKey(r => new { r.MemberId, r.BookId });

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Member)
                .WithMany()
                .HasForeignKey(r => r.MemberId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Book)
                .WithMany()
                .HasForeignKey(r => r.BookId);
        }

        public virtual DbSet<Book> Book { get; set; }

        public virtual DbSet<Member> Member { get; set; }

        public virtual DbSet<Rental> Rental { get; set; }
    }
}