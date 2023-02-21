﻿// <auto-generated />
using System;
using Infrastucture.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastucture.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataModel.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KanbanTaskId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("KanbanTaskId");

                    b.HasIndex("userId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("DataModel.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Active = true,
                            CreatedOn = new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Chocolates Company",
                            Name = "Butlers",
                            PhoneNumber = "+353864069750"
                        },
                        new
                        {
                            CompanyId = 2,
                            Active = true,
                            CreatedOn = new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "IT Company",
                            Name = "SystematIT",
                            PhoneNumber = "+353833057491"
                        });
                });

            modelBuilder.Entity("DataModel.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            Active = true,
                            CreatedByUserId = 1,
                            CreatedOn = new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Human Resources",
                            Name = "HR"
                        },
                        new
                        {
                            DepartmentId = 2,
                            Active = true,
                            CreatedByUserId = 1,
                            CreatedOn = new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Finance",
                            Name = "Finance"
                        });
                });

            modelBuilder.Entity("DataModel.KanbanTask", b =>
                {
                    b.Property<int>("KanbanTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KanbanTaskId"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentVersionId")
                        .HasColumnType("int");

                    b.Property<int>("ReporterUserId")
                        .HasColumnType("int");

                    b.HasKey("KanbanTaskId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ReporterUserId");

                    b.ToTable("KanbanTasks");
                });

            modelBuilder.Entity("DataModel.KanbanTaskHistory", b =>
                {
                    b.Property<int>("TaskHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskHistoryId"), 1L, 1);

                    b.Property<int>("AssigneeUserId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KanbanTaskId")
                        .HasColumnType("int");

                    b.Property<int?>("LastModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatusStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("TaskHistoryId");

                    b.HasIndex("AssigneeUserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("KanbanTaskId");

                    b.HasIndex("LastModifiedByUserId");

                    b.HasIndex("StoreId");

                    b.HasIndex("TaskStatusStatusId");

                    b.ToTable("KanbanTaskHistory", (string)null);
                });

            modelBuilder.Entity("DataModel.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("DataModel.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Description = "Admin user access",
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Description = "Manager access",
                            Name = "Manager"
                        },
                        new
                        {
                            RoleId = 3,
                            Description = "Regular access",
                            Name = "Regular"
                        });
                });

            modelBuilder.Entity("DataModel.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Name = "ToDo"
                        },
                        new
                        {
                            StatusId = 2,
                            Name = "InProgress"
                        },
                        new
                        {
                            StatusId = 3,
                            Name = "Done"
                        },
                        new
                        {
                            StatusId = 4,
                            Name = "Cancelled"
                        },
                        new
                        {
                            StatusId = 5,
                            Name = "Blocked"
                        });
                });

            modelBuilder.Entity("DataModel.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StoreId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            StoreId = 1,
                            Active = true,
                            CompanyId = 1,
                            CreatedByUserId = 1,
                            CreatedOn = new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Cafe",
                            Name = "Ballsbridge"
                        });
                });

            modelBuilder.Entity("DataModel.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "35 Test Adress",
                            CompanyId = 2,
                            DOB = new DateTime(1989, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lucianoGimenez@gmail.com",
                            FirstName = "Luciano",
                            LastName = "Gimenez",
                            Mobile = "0838352063",
                            Password = "9Y0lMkL/vVg6MfillNNBmeCMRnLdnLRBwPAHy3aFehA=",
                            Salt = "8ra1c6vpeVJwf/OC7WbAPw=="
                        },
                        new
                        {
                            UserId = 2,
                            Address = "28 Test Adress",
                            CompanyId = 1,
                            DOB = new DateTime(1988, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "JohnDoe@buttlers.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Mobile = "0878352233",
                            Password = "64qPYH7Rrew0uRpCCrrY4Vd72o9O5dSZRuCdo5atJlM=",
                            Salt = "W8PohmTcey3GxSAHQnchFg=="
                        });
                });

            modelBuilder.Entity("DataModel.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            UserId = 1
                        },
                        new
                        {
                            RoleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            RoleId = 3,
                            UserId = 1
                        },
                        new
                        {
                            RoleId = 3,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("DataModel.Comment", b =>
                {
                    b.HasOne("DataModel.KanbanTask", "KanbanTask")
                        .WithMany("Comments")
                        .HasForeignKey("KanbanTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KanbanTask");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataModel.Department", b =>
                {
                    b.HasOne("DataModel.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("DataModel.KanbanTask", b =>
                {
                    b.HasOne("DataModel.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_KanbanTask_Company_CompanyId");

                    b.HasOne("DataModel.User", "Reporter")
                        .WithMany()
                        .HasForeignKey("ReporterUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_KanbanTask_Reporter_UserId");

                    b.Navigation("Company");

                    b.Navigation("Reporter");
                });

            modelBuilder.Entity("DataModel.KanbanTaskHistory", b =>
                {
                    b.HasOne("DataModel.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_TaskHistory_Assignee_UserId");

                    b.HasOne("DataModel.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.KanbanTask", "KanbanTask")
                        .WithMany("Histories")
                        .HasForeignKey("KanbanTaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_TaskHistory_KanbanTask_KanbanTaskId");

                    b.HasOne("DataModel.User", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedByUserId");

                    b.HasOne("DataModel.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId");

                    b.HasOne("DataModel.Status", "TaskStatus")
                        .WithMany()
                        .HasForeignKey("TaskStatusStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Department");

                    b.Navigation("KanbanTask");

                    b.Navigation("LastModifiedBy");

                    b.Navigation("Store");

                    b.Navigation("TaskStatus");
                });

            modelBuilder.Entity("DataModel.Message", b =>
                {
                    b.HasOne("DataModel.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Message_Company_CompanyId");

                    b.HasOne("DataModel.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Message_Receiver_UserId");

                    b.HasOne("DataModel.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Message_Sender_UserId");

                    b.Navigation("Company");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DataModel.Store", b =>
                {
                    b.HasOne("DataModel.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Store_Company_CompanyId");

                    b.HasOne("DataModel.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");

                    b.Navigation("Company");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("DataModel.User", b =>
                {
                    b.HasOne("DataModel.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_User_Company_CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DataModel.UserRole", b =>
                {
                    b.HasOne("DataModel.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataModel.KanbanTask", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Histories");
                });

            modelBuilder.Entity("DataModel.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DataModel.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
