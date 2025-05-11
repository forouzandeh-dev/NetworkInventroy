using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkInventory.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceCategoryProperly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Devices");

            migrationBuilder.AddColumn<int>(
                name: "DeviceCategoryId",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeviceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceCategoryId",
                table: "Devices",
                column: "DeviceCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceCategories_DeviceCategoryId",
                table: "Devices",
                column: "DeviceCategoryId",
                principalTable: "DeviceCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceCategories_DeviceCategoryId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceCategories");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DeviceCategoryId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DeviceCategoryId",
                table: "Devices");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
