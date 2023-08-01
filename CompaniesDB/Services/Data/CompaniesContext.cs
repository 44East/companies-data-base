using CompaniesDataBase.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompaniesDataBase.Services.Data
{
    public class CompaniesContext : DbContext
    {
        public CompaniesContext(DbContextOptions<CompaniesContext> options)
        : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Notes)
                .WithOne(n => n.Employee)
                .HasForeignKey(n => n.EmployeeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Company)
                .HasForeignKey(o => o.CompanyId)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Notes)
                .WithOne(n => n.Company)
                .HasForeignKey(n => n.CompanyId)
                .OnDelete(DeleteBehavior.ClientCascade);
            
        }
    }
}
