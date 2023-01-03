using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.DataAccess.Migrations
{
    public partial class SystematITDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "5AtSUsG+OS43QltImuOTTTbam7yx6hBvoEHlZr4P/yQ=", "i2aySrxlt4EEoKBxgOfBcg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "bSWIDMBYdqyyYPJsySI6yU+G21kE8Ma72o6qqv+FYbI=", "t2y5SLz5DKJmSnVeDG50GQ==" });
        }
    }
}
