using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;

namespace Infrastucture.DataAccess
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }
        public ApplicationDbContext() : base()
        {
            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<KanbanTask> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(125)
                    .IsUnicode(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Teacher)
                //    .WithMany(p => p.Course)
                //    .HasForeignKey(d => d.TeacherId)
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .HasConstraintName("FK_Course_Teacher");
            });



        }
    }
}
