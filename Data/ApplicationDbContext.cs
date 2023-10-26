using MediPortal_Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPortal_Hospital.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Hospital> Hospitals { get; set; }
    }
}
