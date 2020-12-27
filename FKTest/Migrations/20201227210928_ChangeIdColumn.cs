using Microsoft.EntityFrameworkCore.Migrations;

namespace FKTest.Migrations
{
    public partial class ChangeIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Parents_ParentCode",
                table: "Children");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Children",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_ParentCode",
                table: "Children");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Parents",
                type: "varchar(95) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(95) CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ParentCode",
                table: "Children",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(95) CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Children",
                type: "varchar(95) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(95) CHARACTER SET utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Children",
                table: "Children",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_Code",
                table: "Parents",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Children_Code",
                table: "Children",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Children_ParentId",
                table: "Children",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Parents_ParentId",
                table: "Children",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Parents_ParentId",
                table: "Children");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_Code",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Children",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_Code",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_ParentId",
                table: "Children");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Parents",
                type: "varchar(95) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(95) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParentCode",
                table: "Children",
                type: "varchar(95) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Children",
                type: "varchar(95) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(95) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Children",
                table: "Children",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Children_ParentCode",
                table: "Children",
                column: "ParentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Parents_ParentCode",
                table: "Children",
                column: "ParentCode",
                principalTable: "Parents",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
