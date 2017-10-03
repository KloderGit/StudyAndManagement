using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaM.DataBases.Migrations
{
    public partial class AttestationCertificationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CertificationTypeId",
                table: "Attestations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attestations_CertificationTypeId",
                table: "Attestations",
                column: "CertificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attestations_CertificationTypes_CertificationTypeId",
                table: "Attestations",
                column: "CertificationTypeId",
                principalTable: "CertificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attestations_CertificationTypes_CertificationTypeId",
                table: "Attestations");

            migrationBuilder.DropIndex(
                name: "IX_Attestations_CertificationTypeId",
                table: "Attestations");

            migrationBuilder.DropColumn(
                name: "CertificationTypeId",
                table: "Attestations");
        }
    }
}
