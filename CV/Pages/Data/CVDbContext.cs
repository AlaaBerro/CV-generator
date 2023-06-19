using CV.Pages.Model;
using Microsoft.EntityFrameworkCore;


namespace CV.Pages.Data
{
    public class CVDbContext : DbContext
    {
        public CVDbContext(DbContextOptions<CVDbContext> options) : base(options)
        {
        }

        public DbSet<CVModel> cv { get; set; }
    }
}
