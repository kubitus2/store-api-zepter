using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZepterApi.Migrations
{
    /// <inheritdoc />
    public partial class ModelsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlatNumber",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Addresses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlatNumber",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Addresses");
        }
    }
}
