using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndBorrower.Context.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookBorrower",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrower", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    NumberOfCopies = table.Column<int>(type: "int", nullable: false),
                    BorrowedBooks = table.Column<int>(type: "int", nullable: false),
                    BookBorrowerCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookBorrower_BookBorrowerCode",
                        column: x => x.BookBorrowerCode,
                        principalTable: "BookBorrower",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookBorrowerCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrowers_BookBorrower_BookBorrowerCode",
                        column: x => x.BookBorrowerCode,
                        principalTable: "BookBorrower",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookBorrowerCode",
                table: "Books",
                column: "BookBorrowerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_BookBorrowerCode",
                table: "Borrowers",
                column: "BookBorrowerCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Borrowers");

            migrationBuilder.DropTable(
                name: "BookBorrower");
        }
    }
}
