using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtnNewPinpad.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBranchFromPinpadModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Pinpads");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Pinpads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
