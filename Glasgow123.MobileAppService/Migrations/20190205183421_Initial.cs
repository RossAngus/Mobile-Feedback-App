using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Glasgow123.MobileAppService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    IsTeacher = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversityClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    LecturerId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityClasses_Persons_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    ToPersonId = table.Column<int>(nullable: true),
                    UniversityClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Persons_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Persons_ToPersonId",
                        column: x => x.ToPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_UniversityClasses_UniversityClassId",
                        column: x => x.UniversityClassId,
                        principalTable: "UniversityClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonClasses",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    UniversityClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonClasses", x => new { x.PersonId, x.UniversityClassId });
                    table.ForeignKey(
                        name: "FK_PersonClasses_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonClasses_UniversityClasses_UniversityClassId",
                        column: x => x.UniversityClassId,
                        principalTable: "UniversityClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_AuthorId",
                table: "Feedbacks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ToPersonId",
                table: "Feedbacks",
                column: "ToPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UniversityClassId",
                table: "Feedbacks",
                column: "UniversityClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonClasses_UniversityClassId",
                table: "PersonClasses",
                column: "UniversityClassId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityClasses_LecturerId",
                table: "UniversityClasses",
                column: "LecturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "PersonClasses");

            migrationBuilder.DropTable(
                name: "UniversityClasses");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
