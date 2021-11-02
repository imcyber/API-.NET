using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class UserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "UpdateAt", "email", "name" },
                values: new object[] { new Guid("52240ef3-b83f-48cd-af4a-f3d88fc1759d"), new DateTime(2021, 11, 2, 14, 23, 2, 7, DateTimeKind.Local).AddTicks(5004), new DateTime(2021, 11, 2, 14, 23, 2, 8, DateTimeKind.Local).AddTicks(5353), "adm@mail", "Administrador" });

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
