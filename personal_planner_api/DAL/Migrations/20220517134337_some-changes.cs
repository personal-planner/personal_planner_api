using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acts_AspNetUsers_UserId1",
                table: "Acts");

            migrationBuilder.DropForeignKey(
                name: "FK_Acts_Categories_CategoryId1",
                table: "Acts");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_UserId1",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserId1",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Acts_CategoryId1",
                table: "Acts");

            migrationBuilder.DropIndex(
                name: "IX_Acts_UserId1",
                table: "Acts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Acts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Acts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Acts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Acts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Acts_CategoryId",
                table: "Acts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Acts_UserId",
                table: "Acts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acts_AspNetUsers_UserId",
                table: "Acts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acts_Categories_CategoryId",
                table: "Acts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acts_AspNetUsers_UserId",
                table: "Acts");

            migrationBuilder.DropForeignKey(
                name: "FK_Acts_Categories_CategoryId",
                table: "Acts");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_UserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Acts_CategoryId",
                table: "Acts");

            migrationBuilder.DropIndex(
                name: "IX_Acts_UserId",
                table: "Acts");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Acts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Acts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId1",
                table: "Acts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Acts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId1",
                table: "Categories",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Acts_CategoryId1",
                table: "Acts",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Acts_UserId1",
                table: "Acts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Acts_AspNetUsers_UserId1",
                table: "Acts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acts_Categories_CategoryId1",
                table: "Acts",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_UserId1",
                table: "Categories",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
