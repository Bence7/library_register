using LibraryRegisterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryEntityFramework
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }

        public virtual DbSet<Member> Member { get; set; }

        public virtual DbSet<Rental> Rental { get; set; }
    }
}