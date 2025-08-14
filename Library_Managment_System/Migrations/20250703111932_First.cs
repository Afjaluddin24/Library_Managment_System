using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    member_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    membership_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.member_id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.staff_id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    category_id1 = table.Column<int>(type: "int", nullable: true),
                    available_copies = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_category_id1",
                        column: x => x.category_id1,
                        principalTable: "Categories",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    member_id = table.Column<int>(type: "int", nullable: true),
                    member_id1 = table.Column<int>(type: "int", nullable: true),
                    book_id = table.Column<int>(type: "int", nullable: true),
                    book_id1 = table.Column<int>(type: "int", nullable: true),
                    staff_id = table.Column<int>(type: "int", nullable: true),
                    staff_id1 = table.Column<int>(type: "int", nullable: true),
                    issue_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    return_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK_Transactions_Books_book_id1",
                        column: x => x.book_id1,
                        principalTable: "Books",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK_Transactions_Members_member_id1",
                        column: x => x.member_id1,
                        principalTable: "Members",
                        principalColumn: "member_id");
                    table.ForeignKey(
                        name: "FK_Transactions_Staffs_staff_id1",
                        column: x => x.staff_id1,
                        principalTable: "Staffs",
                        principalColumn: "staff_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_category_id1",
                table: "Books",
                column: "category_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_book_id1",
                table: "Transactions",
                column: "book_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_member_id1",
                table: "Transactions",
                column: "member_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_staff_id1",
                table: "Transactions",
                column: "staff_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
