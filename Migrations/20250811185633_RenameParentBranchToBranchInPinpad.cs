using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtnNewPinpad.Migrations
{
    /// <inheritdoc />
    public partial class RenameParentBranchToBranchInPinpad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentBranch",
                table: "Pinpads",
                newName: "Branch");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "Pinpads",
                newName: "ParentBranch");
        }
    }
}
