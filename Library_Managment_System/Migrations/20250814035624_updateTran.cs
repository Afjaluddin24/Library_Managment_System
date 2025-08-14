using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class updateTran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Staffs_staff_id1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_staff_id1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "staff_id1",
                table: "Transactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "return_date",
                table: "Transactions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "available_copies",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_staff_id",
                table: "Transactions",
                column: "staff_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Staffs_staff_id",
                table: "Transactions",
                column: "staff_id",
                principalTable: "Staffs",
                principalColumn: "staff_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Staffs_staff_id",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_staff_id",
                table: "Transactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "return_date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "staff_id1",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "available_copies",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_staff_id1",
                table: "Transactions",
                column: "staff_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Staffs_staff_id1",
                table: "Transactions",
                column: "staff_id1",
                principalTable: "Staffs",
                principalColumn: "staff_id");
        }
    }
}
