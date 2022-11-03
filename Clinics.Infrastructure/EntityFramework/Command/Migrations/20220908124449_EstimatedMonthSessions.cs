using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinics.Infrastructure.EntityFramework.Command.Migrations
{
    public partial class EstimatedMonthSessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "EstimatedMonthSessions",
                schema: "Clinics",
                table: "Patient",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedMonthSessions",
                schema: "Clinics",
                table: "Patient");
        }
    }
}
