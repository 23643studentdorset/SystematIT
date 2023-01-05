using DataModel;
using Infrastucture.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infrastucture.DataAccess.Data
{
    public class DbInitializer
    {
        protected readonly ModelBuilder modelBuilder;
        //private readonly IConfiguration _iconfiguration;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
            //_iconfiguration = iConfiguration;
        }

        public void EntityDefinition()
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.Navigation(e => e.Sender).AutoInclude();

                entity.Navigation(e => e.Receiver).AutoInclude();

                //entity.Navigation(e => e.Company).AutoInclude();

                entity.HasOne(d => d.Sender)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Message_Sender_UserId");

                entity.HasOne(d => d.Receiver)
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

                entity.Navigation(e => e.Assignee).AutoInclude();

                //entity.Navigation(e => e.Company).AutoInclude();

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

                entity.HasOne(e => e.Company)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_KanbanTask_Company_CompanyId");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.Property(e => e.StoreId).UseIdentityColumn(1, 1);

                entity.Navigation(e => e.CreatedBy).AutoInclude();

                entity.Navigation(e => e.ModifiedBy).AutoInclude();

                //entity.Navigation(e => e.Company).AutoInclude();                   

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
                entity.Navigation(e => e.CreatedBy).AutoInclude();

                entity.Navigation(e => e.ModifiedBy).AutoInclude();

            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Navigation(e => e.CreatedBy).AutoInclude();

                entity.Navigation(e => e.ModifiedBy).AutoInclude();
            });

            modelBuilder.Entity<User>(entity =>
            {
                //entity.Navigation(e => e.Company).AutoInclude();
                entity.Navigation(e => e.UserRoles).AutoInclude();
            });

            modelBuilder.Entity<UserRole>(entity => { 
                entity.HasKey(sc => new {sc.RoleId, sc.UserId});
                entity.Navigation(e => e.Role).AutoInclude();
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

            var passwordHashedUser1 = PasswordEncryption.SaltAndHashPassword("secret1");
            var passwordHashedUser2 = PasswordEncryption.SaltAndHashPassword("secret2");

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
                FirstName = "Charlie",
                LastName = "Shein",
                Address = "28 Test Adress",
                DOB = new DateTime(1988, 05, 11),
                Email = "charlieshein@buttlers.com",
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
                    RoleId = roles.ToArray()[0].RoleId
                },
                new UserRole
                {
                    UserId = firstUser.UserId,
                    RoleId = roles.ToArray()[1].RoleId
                },
                new UserRole
                {
                    UserId = firstUser.UserId,
                    RoleId = roles.ToArray()[2].RoleId
                },
                new UserRole
                {
                    UserId = secondUser.UserId,
                    RoleId = roles.ToArray()[2].RoleId
                }
            };

            var users = new List<User>() { firstUser, secondUser };

            modelBuilder.Entity<Company>().HasData(companies);

            modelBuilder.Entity<Role>().HasData(roles);

            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<Store>()
              .HasData(
              new
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
