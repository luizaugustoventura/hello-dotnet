using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloDotnet.Migrations
{
    /// <inheritdoc />
    public partial class RenamingColumnFlexPlateToLicensePlate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "flex_plate",
                table: "vehicles",
                newName: "license_plate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "license_plate",
                table: "vehicles",
                newName: "flex_plate");
        }
    }
}
