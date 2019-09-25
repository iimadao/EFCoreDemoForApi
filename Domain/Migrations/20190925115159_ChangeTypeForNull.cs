using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class ChangeTypeForNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassesId",
                table: "Students");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Students",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "ClassesId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<uint>(
                name: "Age",
                table: "Students",
                nullable: true,
                oldClrType: typeof(uint));

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassesId",
                table: "Students",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassesId",
                table: "Students");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Students",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ClassesId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<uint>(
                name: "Age",
                table: "Students",
                nullable: false,
                oldClrType: typeof(uint),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassesId",
                table: "Students",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
