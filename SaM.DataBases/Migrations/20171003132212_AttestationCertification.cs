using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaM.DataBases.Migrations
{
    public partial class AttestationCertification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CertificationId",
                table: "Attestations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attestations_CertificationId",
                table: "Attestations",
                column: "CertificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attestations_Certifications_CertificationId",
                table: "Attestations",
                column: "CertificationId",
                principalTable: "Certifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attestations_Certifications_CertificationId",
                table: "Attestations");

            migrationBuilder.DropIndex(
                name: "IX_Attestations_CertificationId",
                table: "Attestations");

            migrationBuilder.DropColumn(
                name: "CertificationId",
                table: "Attestations");
        }
    }
}
