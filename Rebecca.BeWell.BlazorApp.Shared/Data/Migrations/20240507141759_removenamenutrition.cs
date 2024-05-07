using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rebecca.BeWell.BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class removenamenutrition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Nutritions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Nutritions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
