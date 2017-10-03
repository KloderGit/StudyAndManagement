using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaM.DataBases.Migrations
{
    public partial class AttestationCertType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attestations_CertificationTypes_CertificationTypeId",
                table: "Attestations");

            migrationBuilder.AlterColumn<int>(
                name: "CertificationTypeId",
                table: "Attestations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attestations_CertificationTypes_CertificationTypeId",
                table: "Attestations",
                column: "CertificationTypeId",
                principalTable: "CertificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attestations_CertificationTypes_CertificationTypeId",
                table: "Attestations");

            migrationBuilder.AlterColumn<int>(
                name: "CertificationTypeId",
                table: "Attestations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Attestations_CertificationTypes_CertificationTypeId",
                table: "Attestations",
                column: "CertificationTypeId",
                principalTable: "CertificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
