using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtnNewPinpad.Migrations
{
    /// <inheritdoc />
    public partial class AddPinpadTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pinpads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabangInduk = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KodeOutlet = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TanggalRegister = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusPinpad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IPLow = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IPHigh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pinpads", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pinpads");
        }
    }
}
