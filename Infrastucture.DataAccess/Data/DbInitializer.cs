﻿using DataModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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

                entity.HasOne(e => e.Company)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Store_Company_CompanyId");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Navigation(e => e.CreatedBy).AutoInclude();

                entity.Navigation(e => e.ModifiedBy).AutoInclude();

                entity.HasOne(e => e.Company)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Department_Company_CompanyId");

            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Navigation(e => e.CreatedBy).AutoInclude();

                entity.Navigation(e => e.ModifiedBy).AutoInclude();
            });
        }

        public void Seed()
        {
            var company_test_1 = new Company { CompanyId = 1, Active = true, CreatedOn = DateTime.Today, Name = "Butlers", PhoneNumber = "+353864069750"};
            var company_test_2 = new Company { CompanyId = 2, Active = true, CreatedOn = DateTime.Today, Name = "SystematIT", PhoneNumber = "+353833057491" };

            var passwordHashed = SaltAndHashPassword("secret1");
                      
            modelBuilder.Entity<Company>().HasData(company_test_1);
            modelBuilder.Entity<Company>().HasData(company_test_2);
            
            modelBuilder.Entity<User>()
                .HasData(new
                {
                    UserId = 1,
                    FirstName = "Luciano",
                    LastName = "Gimenez",
                    Address = "35 Test Adress",
                    DOB = new DateTime(1989, 04, 10),
                    Email = "lucianoGimenez@gmail.com",
                    Mobile = "0838352063",
                    CompanyId = company_test_2.CompanyId,
                    Password = passwordHashed.Item1,
                    Salt = passwordHashed.Item2,

                });

            modelBuilder.Entity<Store>()
                .HasData(
                new
                {
                    StoreId = 1,
                    Name = "Ballsbridge",
                    Active = true,
                    CompanyId = company_test_1.CompanyId,
                    CreatedByUserId = 1,
                    CreatedOn = DateTime.Today,
                    Description = "Cafe"
                });
          
            modelBuilder.Entity<Department>()
                .HasData(
                new
                    {
                        DepartmentId = 1,
                        CompanyId = company_test_1.CompanyId,
                        Name = "HR",
                        Description = "Human Resources",
                        Active = true,
                        CreatedByUserId = 1,
                        CreatedOn = DateTime.Today
                    },
                new
                    {
                        DepartmentId = 2,
                        CompanyId = company_test_2.CompanyId,
                        Name = "Finance",
                        Description = "Finance",
                        Active = true,
                        CreatedByUserId = 1,
                        CreatedOn = DateTime.Today
                    }
                );
        }
        private static (string, string) SaltAndHashPassword(string password)
        {
            string salt = Convert.ToBase64String(GenerateSalt());

            string passwordWithSalt = password + salt;
            byte[] hash = SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordWithSalt));
            string hashedPassword = Convert.ToBase64String(hash);
            return (hashedPassword, salt);
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;            
        }

    }
}
