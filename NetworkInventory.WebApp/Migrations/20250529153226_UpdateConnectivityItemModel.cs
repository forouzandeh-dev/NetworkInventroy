using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkInventory.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConnectivityItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ConnectivityItems");

            migrationBuilder.AlterColumn<double>(
                name: "Length",
                table: "ConnectivityItems",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CableType",
                table: "ConnectivityItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectorType",
                table: "ConnectivityItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FiberMode",
                table: "ConnectivityItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "ConnectivityItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeystoneCategory",
                table: "ConnectivityItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ConnectivityItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortCount",
                table: "ConnectivityItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SfpType",
                table: "ConnectivityItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransmissionDistance",
                table: "ConnectivityItems",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CableType",
                table: "ConnectivityItems");

            migrationBuilder.DropColumn(
                name: "ConnectorType",
                table: "ConnectivityItems");

            migrationBuilder.DropColumn(
                name: "FiberMode",
                table: "ConnectivityItems");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "ConnectivityItems");

            migrationBuilder.DropColumn(
                name: "KeystoneCategory",
                table: "ConnectivityItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ConnectivityItems");

            migrationBuilder.DropColumn(
                name: "PortCount",
                table: "ConnectivityItems");

            migrationBuilder.DropColumn(
                name: "SfpType",
                table: "ConnectivityItems");

            migrationBuilder.DropColumn(
                name: "TransmissionDistance",
                table: "ConnectivityItems");

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "ConnectivityItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ConnectivityItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
