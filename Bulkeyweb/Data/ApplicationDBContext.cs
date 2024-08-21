using Bulkeyweb.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulkeyweb.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) 
        {

        }
        public DbSet<Category> Categoris { get; set; }
    }
}
