using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class TaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 103, 52, 239, 19, 162, 21, 36, 171, 13, 96, 152, 221, 170, 109, 219, 52, 138, 13, 129, 205, 241, 14, 89, 23, 214, 99, 193, 181, 73, 50, 170, 125, 48, 203, 41, 54, 114, 21, 2, 141, 50, 244, 243, 104, 255, 190, 199, 160, 25, 246, 103, 254, 170, 14, 242, 94, 137, 113, 109, 151, 235, 247, 36, 92 }, new byte[] { 3, 93, 161, 87, 2, 93, 167, 16, 178, 159, 175, 79, 87, 59, 190, 100, 68, 184, 8, 50, 66, 157, 193, 108, 255, 45, 97, 111, 85, 169, 165, 161, 5, 127, 172, 75, 183, 122, 105, 250, 176, 132, 93, 130, 81, 236, 195, 200, 128, 79, 192, 113, 30, 66, 135, 139, 21, 134, 129, 177, 143, 20, 6, 183, 167, 144, 54, 171, 80, 177, 211, 24, 165, 3, 61, 155, 106, 105, 156, 189, 80, 207, 232, 119, 158, 130, 164, 161, 84, 12, 89, 173, 166, 72, 24, 0, 233, 134, 92, 6, 254, 98, 9, 196, 94, 118, 84, 98, 220, 92, 217, 252, 0, 148, 182, 22, 145, 157, 68, 176, 62, 208, 174, 167, 14, 248, 81, 78 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 162, 85, 48, 98, 60, 9, 38, 35, 8, 80, 134, 93, 78, 209, 61, 71, 110, 113, 19, 150, 114, 5, 56, 87, 125, 196, 60, 80, 197, 48, 53, 12, 161, 47, 204, 45, 202, 17, 95, 130, 140, 229, 243, 193, 21, 20, 228, 76, 15, 145, 3, 123, 153, 203, 240, 223, 165, 156, 72, 113, 221, 234, 98, 109 }, new byte[] { 55, 89, 244, 18, 55, 246, 86, 143, 224, 188, 151, 75, 122, 130, 196, 34, 63, 183, 253, 226, 214, 160, 25, 47, 189, 228, 209, 205, 187, 241, 117, 252, 171, 252, 59, 108, 210, 187, 176, 243, 79, 112, 141, 144, 59, 92, 215, 2, 12, 110, 76, 231, 76, 155, 69, 239, 181, 74, 11, 41, 50, 251, 210, 178, 196, 38, 239, 48, 31, 23, 6, 151, 221, 232, 115, 112, 52, 24, 232, 8, 237, 208, 179, 86, 251, 57, 218, 45, 126, 252, 140, 122, 214, 75, 51, 185, 76, 69, 100, 162, 25, 56, 79, 215, 167, 129, 194, 160, 159, 166, 65, 158, 154, 192, 202, 83, 211, 52, 227, 138, 232, 240, 68, 130, 207, 223, 122, 213 } });
        }
    }
}
