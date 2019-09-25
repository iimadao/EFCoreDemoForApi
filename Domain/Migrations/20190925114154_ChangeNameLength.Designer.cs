﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20190925114154_ChangeNameLength")]
    partial class ChangeNameLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Classes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long>("GradeId");

                    b.Property<string>("Name")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Domain.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("GradeId");

                    b.Property<string>("Name")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.Grade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<uint>("Age");

                    b.Property<long>("ClassesId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Mail")
                        .HasMaxLength(125);

                    b.Property<string>("Name")
                        .HasMaxLength(125);

                    b.HasKey("Id");

                    b.HasIndex("ClassesId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Classes", b =>
                {
                    b.HasOne("Domain.Grade", "Grade")
                        .WithMany("Classes")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Course", b =>
                {
                    b.HasOne("Domain.Grade", "Grade")
                        .WithMany("Courses")
                        .HasForeignKey("GradeId");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.HasOne("Domain.Classes", "Classes")
                        .WithMany("Students")
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}