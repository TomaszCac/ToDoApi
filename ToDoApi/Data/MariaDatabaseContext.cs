using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public class MariaDatabaseContext : DbContext
    {
        public MariaDatabaseContext(DbContextOptions<MariaDatabaseContext> options) : base(options) { }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
