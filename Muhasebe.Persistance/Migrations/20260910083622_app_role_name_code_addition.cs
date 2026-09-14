using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muhasebe.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class app_role_name_code_addition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "AspNetRoles");
        }
    }
}
