using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.DataAccess.Migrations
{
    public partial class SystematITDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "LzzlWv4loKCUMO0AWFIAbAvrUXfi6RkeUueQ7FNLjyg=", "cLj+BrpTPc5GyU3+Wz31ig==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "5AtSUsG+OS43QltImuOTTTbam7yx6hBvoEHlZr4P/yQ=", "i2aySrxlt4EEoKBxgOfBcg==" });
        }
    }
}
