using Microsoft.EntityFrameworkCore;

namespace HourlyRate.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options):base(options){}
    }
}