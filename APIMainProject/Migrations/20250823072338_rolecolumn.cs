using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMainProject.Migrations
{
    /// <inheritdoc />
    public partial class rolecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Role",
                value: "Customer");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Role",
                value: "Customer");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Phone", "Role", "UserName" },
                values: new object[] { 3, "admin@example.com", "admin123", "9999999999", "Admin", "AdminUser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
