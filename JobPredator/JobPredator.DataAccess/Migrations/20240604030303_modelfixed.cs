using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPredator.DataAccess.Migrations
{
    public partial class modelfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_companies_CompanyId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_CompanyId",
                table: "jobs");
        }
    }
}
