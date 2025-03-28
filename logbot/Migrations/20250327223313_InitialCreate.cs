using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace logbot.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyIdId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "CompanyModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyModel",
                table: "CompanyModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CompanyModel_CompanyIdId",
                table: "Employees",
                column: "CompanyIdId",
                principalTable: "CompanyModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CompanyModel_CompanyIdId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyModel",
                table: "CompanyModel");

            migrationBuilder.RenameTable(
                name: "CompanyModel",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyIdId",
                table: "Employees",
                column: "CompanyIdId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
