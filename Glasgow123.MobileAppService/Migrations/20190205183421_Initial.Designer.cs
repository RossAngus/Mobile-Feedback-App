﻿// <auto-generated />
using Glasgow123.MobileAppService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Glasgow123.MobileAppService.Migrations
{
    [DbContext(typeof(SQLItemContext))]
    [Migration("20190205183421_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Glasgow123.MobileAppService.Models.Relationships.PersonClass", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("UniversityClassId");

                    b.HasKey("PersonId", "UniversityClassId");

                    b.HasIndex("UniversityClassId");

                    b.ToTable("PersonClasses");
                });

            modelBuilder.Entity("Glasgow123.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Score");

                    b.Property<int?>("ToPersonId");

                    b.Property<int?>("UniversityClassId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ToPersonId");

                    b.HasIndex("UniversityClassId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Glasgow123.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<bool>("IsTeacher");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Glasgow123.Models.UniversityClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("LecturerId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.ToTable("UniversityClasses");
                });

            modelBuilder.Entity("Glasgow123.MobileAppService.Models.Relationships.PersonClass", b =>
                {
                    b.HasOne("Glasgow123.Models.Person", "Person")
                        .WithMany("PersonClasses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Glasgow123.Models.UniversityClass", "UniversityClass")
                        .WithMany("PersonClasses")
                        .HasForeignKey("UniversityClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Glasgow123.Models.Feedback", b =>
                {
                    b.HasOne("Glasgow123.Models.Person", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Glasgow123.Models.Person", "ToPerson")
                        .WithMany()
                        .HasForeignKey("ToPersonId");

                    b.HasOne("Glasgow123.Models.UniversityClass", "UniversityClass")
                        .WithMany()
                        .HasForeignKey("UniversityClassId");
                });

            modelBuilder.Entity("Glasgow123.Models.UniversityClass", b =>
                {
                    b.HasOne("Glasgow123.Models.Person", "Lecturer")
                        .WithMany("Teaches")
                        .HasForeignKey("LecturerId");
                });
#pragma warning restore 612, 618
        }
    }
}
