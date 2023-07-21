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
        public DbSet<EmployeePosition> Positions { get; set; }
        public DbSet<EmployeeSalutation> Titles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyId);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Title)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TitleId);
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Notes)
                .WithOne(n => n.Employee)
                .HasForeignKey(n => n.EmployeeId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Company)
                .HasForeignKey(o => o.CompanyId);
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Notes)
                .WithOne(n => n.Company)
                .HasForeignKey(n => n.CompanyId);
            
        }
    }
}
