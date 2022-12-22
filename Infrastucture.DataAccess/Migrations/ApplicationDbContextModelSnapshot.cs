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
                            CreatedOn = new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Human Resources",
                            Name = "HR"
                        },
                        new
                        {
                            DepartmentId = 2,
                            Active = true,
                            CreatedByUserId = 1,
                            CreatedOn = new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Local),
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

                    b.Property<int>("AssigneeUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReporterUserId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatusStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("KanbanTaskId");

                    b.HasIndex("AssigneeUserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ReporterUserId");

                    b.HasIndex("StoreId");

                    b.HasIndex("TaskStatusStatusId");

                    b.ToTable("KanbanTasks");
                });

            modelBuilder.Entity("DataModel.Login", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(125)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Email");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("DataModel.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiverUserId")
                        .HasColumnType("int");

                    b.Property<int>("SenderUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverUserId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("DataModel.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

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

                    b.HasKey("StatusId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("DataModel.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

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

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("DataModel.TaskHistory", b =>
                {
                    b.Property<int>("TaskHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskHistoryId"), 1L, 1);

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("HistoryFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HistoryTo")
                        .HasColumnType("bit");

                    b.Property<int>("TaskKanbanTaskId")
                        .HasColumnType("int");

                    b.HasKey("TaskHistoryId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("TaskKanbanTaskId");

                    b.ToTable("TaskHistories");
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

                    b.Property<DateTime>("DOB")
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

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "35 Test Adress",
                            DOB = new DateTime(1989, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lucianoGimenez@gmail.com",
                            FirstName = "Luciano",
                            LastName = "Gimenez",
                            Mobile = "0838352063"
                        });
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
                    b.HasOne("DataModel.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_KanbanTask_Assignee_UserId");

                    b.HasOne("DataModel.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_KanbanTask_Department_DepartmentId");

                    b.HasOne("DataModel.User", "Reporter")
                        .WithMany()
                        .HasForeignKey("ReporterUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_KanbanTask_Reporter_UserId");

                    b.HasOne("DataModel.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId");

                    b.HasOne("DataModel.Status", "TaskStatus")
                        .WithMany()
                        .HasForeignKey("TaskStatusStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_KanbanTask_Status_StatusId");

                    b.Navigation("Assignee");

                    b.Navigation("Department");

                    b.Navigation("Reporter");

                    b.Navigation("Store");

                    b.Navigation("TaskStatus");
                });

            modelBuilder.Entity("DataModel.Message", b =>
                {
                    b.HasOne("DataModel.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Message_Receiver_UserId");

                    b.HasOne("DataModel.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Message_Sender_UserId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DataModel.Status", b =>
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

            modelBuilder.Entity("DataModel.Store", b =>
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

            modelBuilder.Entity("DataModel.TaskHistory", b =>
                {
                    b.HasOne("DataModel.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.KanbanTask", "Task")
                        .WithMany("Histories")
                        .HasForeignKey("TaskKanbanTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("DataModel.KanbanTask", b =>
                {
                    b.Navigation("Histories");
                });
#pragma warning restore 612, 618
        }
    }
}
