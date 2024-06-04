using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPredator.DataAccess.Migrations
{
    public partial class nomappedproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_companies_CompanyId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_CompanyId",
                table: "jobs");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_url_title_location",
                table: "jobs",
                columns: new[] { "url", "title", "location" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_jobs_url_title_location",
                table: "jobs");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_CompanyId",
                table: "jobs",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_companies_CompanyId",
                table: "jobs",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
