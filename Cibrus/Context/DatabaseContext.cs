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

           
        }

    }
   
}
