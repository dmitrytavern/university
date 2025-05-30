using Microsoft.EntityFrameworkCore;

namespace server_web_lab4.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StoreDepartment> StoreDepartments { get; set; }
        public DbSet<DepartmentProduct> DepartmentProducts { get; set; }
    }
}
