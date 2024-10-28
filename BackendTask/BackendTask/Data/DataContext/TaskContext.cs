using BackendTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTask.Data.DataContext
{
    public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskContext).Assembly);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
