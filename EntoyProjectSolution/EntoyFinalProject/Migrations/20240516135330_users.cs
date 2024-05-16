using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntoyFinalProject.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "User",
                newName: "Email");
        }
    }
}
