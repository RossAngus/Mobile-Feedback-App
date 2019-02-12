using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Glasgow123.MobileAppService.Migrations
{
    public partial class ProperFeedbackRelation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Persons_AuthorId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Persons_ToPersonId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_UniversityClasses_UniversityClassId",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityClassId",
                table: "Feedbacks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ToPersonId",
                table: "Feedbacks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Feedbacks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Persons_AuthorId",
                table: "Feedbacks",
                column: "AuthorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Persons_ToPersonId",
                table: "Feedbacks",
                column: "ToPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_UniversityClasses_UniversityClassId",
                table: "Feedbacks",
                column: "UniversityClassId",
                principalTable: "UniversityClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Persons_AuthorId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Persons_ToPersonId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_UniversityClasses_UniversityClassId",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityClassId",
                table: "Feedbacks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ToPersonId",
                table: "Feedbacks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Feedbacks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Persons_AuthorId",
                table: "Feedbacks",
                column: "AuthorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Persons_ToPersonId",
                table: "Feedbacks",
                column: "ToPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_UniversityClasses_UniversityClassId",
                table: "Feedbacks",
                column: "UniversityClassId",
                principalTable: "UniversityClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
