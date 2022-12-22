using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.DataAccess.Migrations
{
    public partial class SystematITDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_CreateByUserId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Users_CreateByUserId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskHistories_Users_CreateByUserId",
                table: "TaskHistories");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "TaskHistories",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreateByUserId",
                table: "TaskHistories",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskHistories_CreateByUserId",
                table: "TaskHistories",
                newName: "IX_TaskHistories_CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "Stores",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreateByUserId",
                table: "Stores",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_CreateByUserId",
                table: "Stores",
                newName: "IX_Stores_CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "BoardStatusStatusId",
                table: "KanbanTasks",
                newName: "TaskStatusStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanTasks_BoardStatusStatusId",
                table: "KanbanTasks",
                newName: "IX_KanbanTasks_TaskStatusStatusId");

            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "Departments",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreateByUserId",
                table: "Departments",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_CreateByUserId",
                table: "Departments",
                newName: "IX_Departments_CreatedByUserId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "DOB", "Email", "FirstName", "LastName", "Mobile" },
                values: new object[] { 1, "35 Test Adress", new DateTime(1989, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucianoGimenez@gmail.com", "Luciano", "Gimenez", "0838352063" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Active", "CreatedByUserId", "CreatedOn", "Description", "ModifiedByUserId", "ModifiedOn", "Name" },
                values: new object[] { 1, true, 1, new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), "Human Resources", null, null, "HR" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Active", "CreatedByUserId", "CreatedOn", "Description", "ModifiedByUserId", "ModifiedOn", "Name" },
                values: new object[] { 2, true, 1, new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), "Finance", null, null, "Finance" });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_CreatedByUserId",
                table: "Departments",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Users_CreatedByUserId",
                table: "Stores",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHistories_Users_CreatedByUserId",
                table: "TaskHistories",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_CreatedByUserId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Users_CreatedByUserId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskHistories_Users_CreatedByUserId",
                table: "TaskHistories");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "TaskHistories",
                newName: "CreateOn");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "TaskHistories",
                newName: "CreateByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskHistories_CreatedByUserId",
                table: "TaskHistories",
                newName: "IX_TaskHistories_CreateByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Stores",
                newName: "CreateOn");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Stores",
                newName: "CreateByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_CreatedByUserId",
                table: "Stores",
                newName: "IX_Stores_CreateByUserId");

            migrationBuilder.RenameColumn(
                name: "TaskStatusStatusId",
                table: "KanbanTasks",
                newName: "BoardStatusStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanTasks_TaskStatusStatusId",
                table: "KanbanTasks",
                newName: "IX_KanbanTasks_BoardStatusStatusId");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Departments",
                newName: "CreateOn");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Departments",
                newName: "CreateByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_CreatedByUserId",
                table: "Departments",
                newName: "IX_Departments_CreateByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_CreateByUserId",
                table: "Departments",
                column: "CreateByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Users_CreateByUserId",
                table: "Stores",
                column: "CreateByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHistories_Users_CreateByUserId",
                table: "TaskHistories",
                column: "CreateByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
