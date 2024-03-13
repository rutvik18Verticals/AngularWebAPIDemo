using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAdminWithId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 1, new byte[] { 162, 85, 48, 98, 60, 9, 38, 35, 8, 80, 134, 93, 78, 209, 61, 71, 110, 113, 19, 150, 114, 5, 56, 87, 125, 196, 60, 80, 197, 48, 53, 12, 161, 47, 204, 45, 202, 17, 95, 130, 140, 229, 243, 193, 21, 20, 228, 76, 15, 145, 3, 123, 153, 203, 240, 223, 165, 156, 72, 113, 221, 234, 98, 109 }, new byte[] { 55, 89, 244, 18, 55, 246, 86, 143, 224, 188, 151, 75, 122, 130, 196, 34, 63, 183, 253, 226, 214, 160, 25, 47, 189, 228, 209, 205, 187, 241, 117, 252, 171, 252, 59, 108, 210, 187, 176, 243, 79, 112, 141, 144, 59, 92, 215, 2, 12, 110, 76, 231, 76, 155, 69, 239, 181, 74, 11, 41, 50, 251, 210, 178, 196, 38, 239, 48, 31, 23, 6, 151, 221, 232, 115, 112, 52, 24, 232, 8, 237, 208, 179, 86, 251, 57, 218, 45, 126, 252, 140, 122, 214, 75, 51, 185, 76, 69, 100, 162, 25, 56, 79, 215, 167, 129, 194, 160, 159, 166, 65, 158, 154, 192, 202, 83, 211, 52, 227, 138, 232, 240, 68, 130, 207, 223, 122, 213 }, "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
