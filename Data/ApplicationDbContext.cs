using Microsoft.EntityFrameworkCore;
using MedicalDeviceTracking.Models;

namespace MedicalDeviceTracking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<CentralRequest> CentralRequests { get; set; }
        public DbSet<BudgetRequest> BudgetRequests { get; set; }
        public DbSet<DirectProcurement> DirectProcurements { get; set; }
    }
}
