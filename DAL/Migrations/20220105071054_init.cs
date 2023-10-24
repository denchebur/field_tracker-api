using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "pet",
                columns: table => new
                {
                    field_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    vegetation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    square = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    humidity = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet", x => x.field_id);
                    table.ForeignKey(
                        name: "FK_pet_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pet_user_id",
                table: "pet",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pet");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
