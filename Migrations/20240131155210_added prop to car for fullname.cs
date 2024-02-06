using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergCarRazorPages.Migrations
{
    /// <inheritdoc />
    public partial class addedproptocarforfullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Cars");
        }
    }
}
