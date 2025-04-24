using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dating.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_FaceVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FaceVerification",
                table: "Images",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceVerification",
                table: "Images");
        }
    }
}
