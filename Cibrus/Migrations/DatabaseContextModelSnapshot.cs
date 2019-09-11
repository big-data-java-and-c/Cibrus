﻿// <auto-generated />
using Cibrus.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cibrus.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cibrus.models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StudentId");

                    b.Property<int>("SubjectId");

                    b.Property<int>("TeacherId");

                    b.Property<string>("date_received");

                    b.Property<int>("value_grade");

                    b.HasKey("GradeId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("grade");

                    b.HasData(
                        new
                        {
                            GradeId = 1,
                            StudentId = 1,
                            SubjectId = 1,
                            TeacherId = 1,
                            date_received = "12/08/2019",
                            value_grade = 5
                        },
                        new
                        {
                            GradeId = 2,
                            StudentId = 1,
                            SubjectId = 1,
                            TeacherId = 1,
                            date_received = "12/08/2019",
                            value_grade = 5
                        },
                        new
                        {
                            GradeId = 3,
                            StudentId = 1,
                            SubjectId = 1,
                            TeacherId = 1,
                            date_received = "12/08/2019",
                            value_grade = 5
                        },
                        new
                        {
                            GradeId = 4,
                            StudentId = 1,
                            SubjectId = 1,
                            TeacherId = 1,
                            date_received = "12/08/2019",
                            value_grade = 5
                        },
                        new
                        {
                            GradeId = 5,
                            StudentId = 2,
                            SubjectId = 1,
                            TeacherId = 1,
                            date_received = "12/08/2019",
                            value_grade = 5
                        },
                        new
                        {
                            GradeId = 6,
                            StudentId = 2,
                            SubjectId = 1,
                            TeacherId = 1,
                            date_received = "12/08/2019",
                            value_grade = 5
                        },
                        new
                        {
                            GradeId = 7,
                            StudentId = 4,
                            SubjectId = 1,
                            TeacherId = 1,
                            date_received = "12/08/2019",
                            value_grade = 5
                        },
                        new
                        {
                            GradeId = 8,
                            StudentId = 4,
                            SubjectId = 1,
                            TeacherId = 1,
                            date_received = "12/08/2019",
                            value_grade = 5
                        },
                        new
                        {
                            GradeId = 9,
                            StudentId = 1,
                            SubjectId = 1,
                            TeacherId = 1,
                            date_received = "12/08/2019",
                            value_grade = 5
                        });
                });

            modelBuilder.Entity("Cibrus.models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("groupName");

                    b.HasKey("GroupId");

                    b.ToTable("group");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            groupName = "IO1"
                        },
                        new
                        {
                            GroupId = 2,
                            groupName = "IO2"
                        },
                        new
                        {
                            GroupId = 3,
                            groupName = "IO3"
                        },
                        new
                        {
                            GroupId = 4,
                            groupName = "IO4"
                        },
                        new
                        {
                            GroupId = 5,
                            groupName = "IO5"
                        },
                        new
                        {
                            GroupId = 6,
                            groupName = "IO6"
                        },
                        new
                        {
                            GroupId = 7,
                            groupName = "NewUserGroup"
                        });
                });

            modelBuilder.Entity("Cibrus.models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnName("role_type");

                    b.HasKey("RoleId");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            name = "ADMIN"
                        },
                        new
                        {
                            RoleId = 2,
                            name = "STUDENT"
                        },
                        new
                        {
                            RoleId = 3,
                            name = "TEACHER"
                        });
                });

            modelBuilder.Entity("Cibrus.models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("address");

                    b.Property<string>("city");

                    b.Property<string>("displayName");

                    b.Property<string>("phone_number");

                    b.Property<string>("province");

                    b.Property<string>("zip_code");

                    b.HasKey("StudentId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("student");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            GroupId = 1,
                            UserId = 1,
                            address = " szkolna 11",
                            city = " uć ",
                            displayName = " Wiktor",
                            phone_number = "785772271",
                            province = " lodzkie",
                            zip_code = "12-345"
                        },
                        new
                        {
                            StudentId = 2,
                            GroupId = 1,
                            UserId = 2,
                            address = " szkolna 11",
                            city = " uć ",
                            displayName = " Kamil",
                            phone_number = "785772271",
                            province = " lodzkie",
                            zip_code = "12-345"
                        },
                        new
                        {
                            StudentId = 3,
                            GroupId = 2,
                            UserId = 3,
                            address = " szkolna 11",
                            city = " uć ",
                            displayName = " Rafał",
                            phone_number = "785772271",
                            province = " lodzkie",
                            zip_code = "12-345"
                        },
                        new
                        {
                            StudentId = 4,
                            GroupId = 2,
                            UserId = 4,
                            address = " robertowa 11",
                            city = " uć ",
                            displayName = " Robert",
                            phone_number = "733333271",
                            province = " lodzkie",
                            zip_code = "12-345"
                        });
                });

            modelBuilder.Entity("Cibrus.models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.Property<int>("value_ECTS");

                    b.HasKey("SubjectId");

                    b.ToTable("subject");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            name = "Matematyka Dyskretna",
                            value_ECTS = 6
                        },
                        new
                        {
                            SubjectId = 2,
                            name = "Analiza Matematyczna",
                            value_ECTS = 5
                        },
                        new
                        {
                            SubjectId = 3,
                            name = "Podstawy Programowania",
                            value_ECTS = 4
                        });
                });

            modelBuilder.Entity("Cibrus.models.Teacher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("name")
                        .HasColumnName("name");

                    b.Property<int>("salary")
                        .HasColumnName("salary");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("teacher");

                    b.HasData(
                        new
                        {
                            id = 1,
                            UserId = 3,
                            name = "profesor",
                            salary = 15000
                        });
                });

            modelBuilder.Entity("Cibrus.models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnName("roles_id");

                    b.Property<string>("email");

                    b.Property<string>("password");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 2,
                            email = "ekoGroszek@wp.pl",
                            password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0="
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2,
                            email = "xewionn@wp.pl",
                            password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0="
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3,
                            email = "profesor@wp.pl",
                            password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0="
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 3,
                            email = "doktor@wp.pl",
                            password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0="
                        },
                        new
                        {
                            UserId = 5,
                            RoleId = 1,
                            email = "admin@wp.pl",
                            password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0="
                        },
                        new
                        {
                            UserId = 6,
                            RoleId = 2,
                            email = "student6@wp.pl",
                            password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0="
                        });
                });

            modelBuilder.Entity("Cibrus.models.Grade", b =>
                {
                    b.HasOne("Cibrus.models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cibrus.models.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cibrus.models.Teacher", "Teacher")
                        .WithMany("Grades")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Cibrus.models.Student", b =>
                {
                    b.HasOne("Cibrus.models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Cibrus.models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cibrus.models.Teacher", b =>
                {
                    b.HasOne("Cibrus.models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Cibrus.models.User", b =>
                {
                    b.HasOne("Cibrus.models.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
