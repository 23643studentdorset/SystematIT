using DataModel;
using Infrastucture.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
            modelBuilder.Entity<Message>(entity =>
            {
                entity.Navigation(e => e.Sender).AutoInclude();

                entity.Navigation(e => e.Receiver).AutoInclude();

                entity.HasOne(e => e.Sender)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Message_Sender_UserId");

                entity.HasOne(e => e.Receiver)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Message_Receiver_UserId");

                entity.HasOne(e => e.Company)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Message_Company_CompanyId");
            });

            modelBuilder.Entity<KanbanTask>(entity =>
            {
                entity.Navigation(e => e.Reporter).AutoInclude();

                entity.Navigation(e => e.Histories).AutoInclude();

                entity.Navigation(e => e.Comments).AutoInclude();

                entity.HasOne(e => e.Reporter)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_KanbanTask_Reporter_UserId");

                entity.HasOne(e => e.Company)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_KanbanTask_Company_CompanyId");

                entity.HasMany(e => e.Histories)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_KanbanTask_Histories_TaskHistoryId");
            });

            modelBuilder.Entity<KanbanTaskHistory>(entity =>
            {
                entity.ToTable("KanbanTaskHistory");

                entity.HasKey(e => e.TaskHistoryId);

                entity.Property(e => e.TaskHistoryId).UseIdentityColumn(1, 1);

                entity.Navigation(e => e.Assignee).AutoInclude();

                entity.Navigation(e => e.TaskStatus).AutoInclude();

                entity.Navigation(e => e.KanbanTask).AutoInclude();

                entity.Navigation(e => e.Department).AutoInclude();

                entity.Navigation(e => e.Store).AutoInclude();

                entity.HasOne(e => e.Assignee)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TaskHistory_Assignee_UserId");

                entity.HasOne(e => e.KanbanTask)
                    .WithMany(e => e.Histories)
                    .HasForeignKey(e => e.KanbanTaskId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TaskHistory_KanbanTask_KanbanTaskId");
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

                entity.HasOne(e => e.Company)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Store_Company_CompanyId");
            });


            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasQueryFilter(p => p.Active);

                entity.Navigation(e => e.CreatedBy).AutoInclude();

                entity.Navigation(e => e.ModifiedBy).AutoInclude();

            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.Navigation(e => e.UserRoles).AutoInclude();

                entity.HasOne(e => e.Company)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_User_Company_CompanyId");
            });

            modelBuilder.Entity<UserRole>(entity => {
                entity.HasKey(e => new { e.RoleId, e.UserId });
                entity.Navigation(e => e.Role).AutoInclude();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasQueryFilter(p => p.Active);
            });
        }

        public void Seed()
        {                     

            var companies = new List<Company>()
            {
                new Company { CompanyId = 1, Active = true, Description = "Chocolates Company", CreatedOn = DateTime.Today, Name = "Butlers", PhoneNumber = "+353864069750"},
                new Company { CompanyId = 2, Active = true, Description = "IT Company", CreatedOn = DateTime.Today, Name = "SystematIT", PhoneNumber = "+353833057491" }
            };

            var roles = new List<Role>() 
            {
                new Role() { RoleId = 1, Name="Admin", Description = "Admin user access" },
                new Role() { RoleId = 2, Name="Manager", Description = "Manager access" },
                new Role() { RoleId = 3, Name="Regular", Description = "Regular access" },
            };

            var passwordHashedUser1 = PasswordEncryption.SaltAndHashPassword(DataAccessSettings.SecretUserAdminPassword);
            var passwordHashedUser2 = PasswordEncryption.SaltAndHashPassword(DataAccessSettings.SecretUserTestPassword);

            var firstUser = new User 
            {
                UserId = 1,
                FirstName = "Luciano",
                LastName = "Gimenez",
                Address = "35 Test Adress",
                DOB = new DateTime(1989, 04, 10),
                Email = "lucianoGimenez@gmail.com",
                Mobile = "0838352063",
                CompanyId = companies[1].CompanyId,
                Password = passwordHashedUser1.Item1,
                Salt = passwordHashedUser1.Item2,
            };

            var secondUser = new User
            {
                UserId = 2,
                FirstName = "John",
                LastName = "Doe",
                Address = "28 Test Adress",
                DOB = new DateTime(1988, 05, 11),
                Email = "JohnDoe@buttlers.com",
                Mobile = "0878352233",
                CompanyId = companies[0].CompanyId,
                Password = passwordHashedUser2.Item1,
                Salt = passwordHashedUser2.Item2,
            };

            var userRoles = new List<UserRole>()
            {
                new UserRole
                {
                    UserId = firstUser.UserId,
                    RoleId = roles[0].RoleId
                },
                new UserRole
                {
                    UserId = firstUser.UserId,
                    RoleId = roles[1].RoleId
                },
                new UserRole
                {
                    UserId = firstUser.UserId,
                    RoleId = roles[2].RoleId
                },
                new UserRole
                {
                    UserId = secondUser.UserId,
                    RoleId = roles[2].RoleId
                }
            };

            var statuses = new List<Status>()
            {
                new Status {StatusId = 1, Name = "ToDo"},
                new Status {StatusId = 2, Name = "InProgress"},
                new Status {StatusId = 3, Name = "Done"},
                new Status {StatusId = 4, Name = "Cancelled"},
                new Status {StatusId = 5, Name = "Blocked"},
            };

            var users = new List<User>() { firstUser, secondUser };

            modelBuilder.Entity<Company>().HasData(companies);

            modelBuilder.Entity<Role>().HasData(roles);

            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<Status>().HasData(statuses);

            modelBuilder.Entity<Store>()
              .HasData(
              new Store()
              {
                  StoreId = 1,
                  Name = "Ballsbridge",
                  Active = true,
                  CompanyId = companies[0].CompanyId,
                  CreatedByUserId = firstUser.UserId,
                  CreatedOn = DateTime.Today,
                  Description = "Cafe"
              });

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
                });

            modelBuilder.Entity<UserRole>()
                .HasData(userRoles);
        }
    }
}
