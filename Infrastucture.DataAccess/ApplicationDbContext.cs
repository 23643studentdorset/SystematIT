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
        public DbSet<KanbanTask> KanbanTasks { get; set; }
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
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(d => d.Sender)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Message_Sender_UserId");

                entity.HasOne(d => d.Receiver)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Message_Receiver_UserId");

            });

            modelBuilder.Entity<KanbanTask>(entity =>
            {
                entity.HasOne(d => d.BoardStatus)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_KanbanTask_Status_StatusId");

                entity.HasOne(d => d.Reporter)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_KanbanTask_Reporter_UserId");

                entity.HasOne(d => d.Assignee)
                    .WithMany()                   
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_KanbanTask_Assignee_UserId");

                entity.HasOne(d => d.Department)
                    .WithMany()                    
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_KanbanTask_Department_DepartmentId");

            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.Property(e => e.StoreId).UseIdentityColumn(1, 1);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    ;

                entity.Property(e => e.Active)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.CreateOn)
                    .IsRequired();
            });

        }

    }
}

