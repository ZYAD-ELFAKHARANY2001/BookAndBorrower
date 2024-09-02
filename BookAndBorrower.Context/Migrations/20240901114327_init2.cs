using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAndBorrower.Context.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookBorrower",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BorrowerId",
                table: "BookBorrower",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookBorrower");

            migrationBuilder.DropColumn(
                name: "BorrowerId",
                table: "BookBorrower");
        }
    }
}
