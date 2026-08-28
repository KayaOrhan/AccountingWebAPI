using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muhasebe.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class remove_ucaf_company_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "UniformChartOfAccounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "UniformChartOfAccounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
