using Microsoft.EntityFrameworkCore;
using DataModel;
using Infrastucture.DataAccess.Data;

namespace Infrastucture.DataAccess
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public ApplicationDbContext() : base()
        {
            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<KanbanTask> KanbanTasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dbInitializer = new DbInitializer(modelBuilder);           
            dbInitializer.EntityDefinition();
            dbInitializer.Seed();
        }

    }
}

