using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
