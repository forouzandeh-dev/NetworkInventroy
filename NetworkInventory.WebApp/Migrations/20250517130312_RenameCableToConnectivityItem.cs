using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkInventory.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameCableToConnectivityItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceCategories_DeviceCategoryId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "Cables");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceCategoryId",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ConnectivityItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectivityItems", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceCategories_DeviceCategoryId",
                table: "Devices",
                column: "DeviceCategoryId",
                principalTable: "DeviceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceCategories_DeviceCategoryId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "ConnectivityItems");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceCategoryId",
                table: "Devices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Cables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cables", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceCategories_DeviceCategoryId",
                table: "Devices",
                column: "DeviceCategoryId",
                principalTable: "DeviceCategories",
                principalColumn: "Id");
        }
    }
}
