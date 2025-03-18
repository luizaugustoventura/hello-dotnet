using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloDotnet.Migrations
{
    /// <inheritdoc />
    public partial class ChangingNameOfVehicleForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_users_OwnerId",
                table: "vehicles");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "vehicles",
                newName: "owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_vehicles_OwnerId",
                table: "vehicles",
                newName: "IX_vehicles_owner_id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_users_owner_id",
                table: "vehicles",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_users_owner_id",
                table: "vehicles");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "vehicles",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicles_owner_id",
                table: "vehicles",
                newName: "IX_vehicles_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_users_OwnerId",
                table: "vehicles",
                column: "OwnerId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
