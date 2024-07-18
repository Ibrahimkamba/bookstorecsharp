using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace BookStoreApp.Data
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
               "server=bkbxqvr3u99gdowtsu8c-mysql.services.clever-cloud.com;database=bkbxqvr3u99gdowtsu8c;user=u5dmf8qxsxlp6sca;password=iMsCpRUikhByXlmWSQnb;",
               mySqlOptions => mySqlOptions.ServerVersion(new Version(5, 7, 32), ServerType.MySql)  // Ensure the server version is specified correctly
           );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.B_A_ID);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.R_C_ID);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Book)
                .WithMany()
                .HasForeignKey(r => r.R_B_ID);
        }
    }
}
