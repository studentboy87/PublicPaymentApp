using Microsoft.EntityFrameworkCore;
using PaymentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApp.Data
{
    public class RegisterCardContext : DbContext
    {
        public RegisterCardContext(DbContextOptions<RegisterCardContext> options) : base(options)
        {
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UKAddress> UKAddresses { get; set; }
        public DbSet<RegisteredCard> RegisteredCards { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Address>().ToTable("Adress");
            modelBuilder.Entity<RegisteredCard>().ToTable("RegisteredCard");
        }
    }
}
