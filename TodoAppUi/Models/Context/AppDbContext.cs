using Microsoft.EntityFrameworkCore;
using TodoAppUi.Models.Configuration;
using TodoAppUi.Models.Entities.Concrete;

namespace TodoAppUi.Models.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<TodoList>  TodoLists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=TodoApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoListConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());
        }
    }
}
