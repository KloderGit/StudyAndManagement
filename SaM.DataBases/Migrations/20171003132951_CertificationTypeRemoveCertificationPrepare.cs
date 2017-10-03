using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaM.DataBases.Migrations
{
    public partial class CertificationTypeRemoveCertificationPrepare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificationTypes_Certifications_AssessmentId",
                table: "CertificationTypes");

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentId",
                table: "CertificationTypes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationTypes_Certifications_AssessmentId",
                table: "CertificationTypes",
                column: "AssessmentId",
                principalTable: "Certifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificationTypes_Certifications_AssessmentId",
                table: "CertificationTypes");

            migrationBuilder.AlterColumn<int>(
                name: "AssessmentId",
                table: "CertificationTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationTypes_Certifications_AssessmentId",
                table: "CertificationTypes",
                column: "AssessmentId",
                principalTable: "Certifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
