using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rebecca.BeWell.BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddStartEnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Nutritions");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Sleeps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Sleeps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Nutritions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NutritionTypeId",
                table: "Nutritions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Nutritions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Intensities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Intensities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Nutritions_NutritionTypeId",
                table: "Nutritions",
                column: "NutritionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutritions_NutritionTypes_NutritionTypeId",
                table: "Nutritions",
                column: "NutritionTypeId",
                principalTable: "NutritionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutritions_NutritionTypes_NutritionTypeId",
                table: "Nutritions");

            migrationBuilder.DropIndex(
                name: "IX_Nutritions_NutritionTypeId",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Sleeps");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Sleeps");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "NutritionTypeId",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Intensities");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Intensities");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Nutritions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
