using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FKTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(95) CHARACTER SET utf8mb4", nullable: false),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(95) CHARACTER SET utf8mb4", nullable: false),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ParentCode = table.Column<string>(type: "varchar(95) CHARACTER SET utf8mb4", nullable: false),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Children_Parents_ParentCode",
                        column: x => x.ParentCode,
                        principalTable: "Parents",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_ParentCode",
                table: "Children",
                column: "ParentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
