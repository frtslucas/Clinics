using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinics.Infrastructure.EntityFramework.Command.Migrations
{
    public partial class SessionToOwnAggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Session_SessionId",
                schema: "Clinics",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Patient_PatientId",
                schema: "Clinics",
                table: "Session");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                schema: "Clinics",
                table: "Session",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "Clinics",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                schema: "Clinics",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Session_SessionId",
                schema: "Clinics",
                table: "Payment",
                column: "SessionId",
                principalSchema: "Clinics",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Patient_PatientId",
                schema: "Clinics",
                table: "Session",
                column: "PatientId",
                principalSchema: "Clinics",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Session_SessionId",
                schema: "Clinics",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Patient_PatientId",
                schema: "Clinics",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "Clinics",
                table: "Session");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                schema: "Clinics",
                table: "Session",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                schema: "Clinics",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Session_SessionId",
                schema: "Clinics",
                table: "Payment",
                column: "SessionId",
                principalSchema: "Clinics",
                principalTable: "Session",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Patient_PatientId",
                schema: "Clinics",
                table: "Session",
                column: "PatientId",
                principalSchema: "Clinics",
                principalTable: "Patient",
                principalColumn: "Id");
        }
    }
}
