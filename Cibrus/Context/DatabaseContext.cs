using Cibrus.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cibrus.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }





        public DbSet<Grade> grades { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<User> users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .HasOne(b => b.Teacher)
                .WithMany(a => a.Grades)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Group>().HasData(
                new Group { GroupId = 1, groupName = "IO1" },
                new Group { GroupId = 2, groupName = "IO2" },
                new Group { GroupId = 3, groupName = "IO3" },
                new Group { GroupId = 4, groupName = "IO4" },
                new Group { GroupId = 5, groupName = "IO5" },
                new Group { GroupId = 6, groupName = "IO6" },
                new Group { GroupId = 7, groupName = "NewUserGroup" }

                );

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, name = "ADMIN" },
                new Role { RoleId = 2, name = "STUDENT" },
                new Role { RoleId = 3, name = "TEACHER" }
                );

            modelBuilder.Entity<User>().HasData(                    //password = 12345678
                new User { UserId = 1, email = "ekoGroszek@wp.pl", password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0=", RoleId = 2 },
                new User { UserId = 2, email = "xewionn@wp.pl", password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0=", RoleId = 2 },
                new User { UserId = 3, email = "profesor@wp.pl", password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0=", RoleId = 3 },
                new User { UserId = 4, email = "doktor@wp.pl", password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0=", RoleId = 3 },
                new User { UserId = 5, email = "admin@wp.pl", password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0=", RoleId = 1 },
                new User { UserId = 6, email = "student6@wp.pl", password = "kndJaVXsrxzrYoIXkkEmI3aEEGfvxogy+KxCvf/YXP0=", RoleId = 2 }
                );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, name = "Matematyka Dyskretna", value_ECTS = 6 },
                new Subject { SubjectId = 2, name = "Analiza Matematyczna", value_ECTS = 5 },
                new Subject { SubjectId = 3, name = "Podstawy Programowania", value_ECTS = 4 }
                );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { id = 1, name = "profesor", salary = 15000, UserId = 3 }
                );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    displayName = " Wiktor",
                    address = " szkolna 11",
                    city = " uć ",
                    province = " lodzkie",
                    zip_code = "12-345",
                    phone_number = "785772271",
                    UserId = 1,
                    GroupId = 1,
                },
                new Student
                {
                    StudentId = 2,
                    displayName = " Kamil",
                    address = " szkolna 11",
                    city = " uć ",
                    province = " lodzkie",
                    zip_code = "12-345",
                    phone_number = "785772271",
                    UserId = 2,
                    GroupId = 1
                },
                new Student
                {
                    StudentId = 3,
                    displayName = " Rafał",
                    address = " szkolna 11",
                    city = " uć ",
                    province = " lodzkie",
                    zip_code = "12-345",
                    phone_number = "785772271",
                    UserId = 3,
                    GroupId = 2
                },
                new Student
                {
                    StudentId = 4,
                    displayName = " Robert",
                    address = " robertowa 11",
                    city = " uć ",
                    province = " lodzkie",
                    zip_code = "12-345",
                    phone_number = "733333271",
                    UserId = 4,
                    GroupId = 2
                }
            );

            modelBuilder.Entity<Grade>().HasData(
                new Grade
                 {
                    GradeId = 1,
                    value_grade = 5,
                    date_received = "12/08/2019",
                    StudentId = 1,
                    TeacherId = 1,
                    SubjectId = 1
                },
                 new Grade
                 {
                     GradeId = 2,
                     value_grade = 5,
                     date_received = "12/08/2019",
                     StudentId = 1,
                     TeacherId = 1,
                     SubjectId = 1
                 },
                 new Grade
                 {
                     GradeId = 3,
                     value_grade = 5,
                     date_received = "12/08/2019",
                     StudentId = 1,
                     TeacherId = 1,
                     SubjectId = 1
                 },
                 new Grade
                 {
                     GradeId = 4,
                     value_grade = 5,
                     date_received = "12/08/2019",
                     StudentId = 1,
                     TeacherId = 1,
                     SubjectId = 1
                 },
                 new Grade
                 {
                     GradeId = 5,
                     value_grade = 5,
                     date_received = "12/08/2019",
                     StudentId = 2,
                     TeacherId = 1,
                     SubjectId = 1
                 },
                 new Grade
                 {
                     GradeId = 6,
                     value_grade = 5,
                     date_received = "12/08/2019",
                     StudentId = 2,
                     TeacherId = 1,
                     SubjectId = 1
                 },
                 new Grade
                 {
                     GradeId = 7,
                     value_grade = 5,
                     date_received = "12/08/2019",
                     StudentId = 4,
                     TeacherId = 1,
                     SubjectId = 1
                 },
                 new Grade
                 {
                     GradeId = 8,
                     value_grade = 5,
                     date_received = "12/08/2019",
                     StudentId = 4,
                     TeacherId = 1,
                     SubjectId = 1
                 },
                 new Grade
                 {
                     GradeId = 9,
                     value_grade = 5,
                     date_received = "12/08/2019",
                     StudentId = 1,
                     TeacherId = 1,
                     SubjectId = 1
                 }
                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseLazyLoadingProxies();
        }

    }

}
