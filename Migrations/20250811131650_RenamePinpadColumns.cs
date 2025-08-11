using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtnNewPinpad.Migrations
{
    /// <inheritdoc />
    public partial class RenamePinpadColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IPLow",
                table: "Pinpads",
                newName: "IpLow");

            migrationBuilder.RenameColumn(
                name: "IPHigh",
                table: "Pinpads",
                newName: "IpHigh");

            migrationBuilder.RenameColumn(
                name: "TanggalRegister",
                table: "Pinpads",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "TID",
                table: "Pinpads",
                newName: "TerminalId");

            migrationBuilder.RenameColumn(
                name: "StatusPinpad",
                table: "Pinpads",
                newName: "PinpadStatus");

            migrationBuilder.RenameColumn(
                name: "KodeOutlet",
                table: "Pinpads",
                newName: "ParentBranch");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "Pinpads",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CabangInduk",
                table: "Pinpads",
                newName: "OutletCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IpLow",
                table: "Pinpads",
                newName: "IPLow");

            migrationBuilder.RenameColumn(
                name: "IpHigh",
                table: "Pinpads",
                newName: "IPHigh");

            migrationBuilder.RenameColumn(
                name: "TerminalId",
                table: "Pinpads",
                newName: "TID");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Pinpads",
                newName: "TanggalRegister");

            migrationBuilder.RenameColumn(
                name: "PinpadStatus",
                table: "Pinpads",
                newName: "StatusPinpad");

            migrationBuilder.RenameColumn(
                name: "ParentBranch",
                table: "Pinpads",
                newName: "KodeOutlet");

            migrationBuilder.RenameColumn(
                name: "OutletCode",
                table: "Pinpads",
                newName: "CabangInduk");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Pinpads",
                newName: "CreateBy");
        }
    }
}
