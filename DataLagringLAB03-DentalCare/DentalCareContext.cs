
using DataLagringLAB03_DentalCare.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLagringLAB03_DentalCare
{
    class DentalCareContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=DENTALCARE;Trusted_Connection=True;");
            // connects to a local Server; called DENTALCARE ;using this computers user or whatever the last part was
        }
    }
}