using Microsoft.EntityFrameworkCore;

namespace MyTodos.Models
{
    public class TodosDbContext : DbContext
    {
        public TodosDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Todos> Todo { get; set; }
    }
}
