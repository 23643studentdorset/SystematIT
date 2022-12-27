using DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.DataAccess.Data
{
    public class DbInitializer
    {
        protected readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void EntityDefinition()
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
                entity.Navigation(e => e.Sender).AutoInclude();

                entity.Navigation(e => e.Receiver).AutoInclude();

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
                entity.Navigation(e => e.Reporter).AutoInclude();

                entity.Navigation(e => e.Assignee).AutoInclude();

                entity.HasOne(d => d.TaskStatus)
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

                entity.Navigation(e => e.CreatedBy).AutoInclude();

                entity.Navigation(e => e.ModifiedBy).AutoInclude();

                entity.HasQueryFilter(p => p.Active);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);

                entity.Property(e => e.Active)
                    .IsRequired();

                entity.Property(e => e.CreatedOn)
                    .IsRequired();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Navigation(e => e.CreatedBy).AutoInclude();

                entity.Navigation(e => e.ModifiedBy).AutoInclude();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Navigation(e => e.CreatedBy).AutoInclude();

                entity.Navigation(e => e.ModifiedBy).AutoInclude();
            });
        }

        public void Seed()
        {
            var firstUser = new User { UserId = 1, FirstName = "Luciano", LastName = "Gimenez", Address = "35 Test Adress", DOB = new DateTime(1989, 04, 10), Email = "lucianoGimenez@gmail.com", Mobile = "0838352063" };
            var firstLogin = new Login { Email = "lucianoGimenez@gmail.com", Password = "secret" };

            modelBuilder.Entity<User>()
                .HasData(firstUser);

            modelBuilder.Entity<Login>()
                .HasData(firstLogin);

            modelBuilder.Entity<Department>()
                .HasData(
                    new
                    {
                        DepartmentId = 1,
                        Name = "HR",
                        Description = "Human Resources",
                        Active = true,
                        CreatedByUserId = firstUser.UserId,
                        CreatedOn = DateTime.Today
                    },
                    new
                    {
                        DepartmentId = 2,
                        Name = "Finance",
                        Description = "Finance",
                        Active = true,
                        CreatedByUserId = firstUser.UserId,
                        CreatedOn = DateTime.Today
                    }
                );
        }
    }
}
