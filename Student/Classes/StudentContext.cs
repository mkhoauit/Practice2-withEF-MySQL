using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEF.Classes
{
    class StudentContext : DbContext
    {


        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public string DbPath { get; private set; }

        public StudentContext()
        {

            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}Student.db";

        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlite($"Data Source={DbPath}");
            options.UseMySQL($"Server=127.0.0.1;Database=Student;Uid=root;Pwd=123456;");
            // localhost replace with 127.0.0.1
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one blog has many post
            modelBuilder.Entity<StudentClass>()
             .HasKey(t => new { t.StudentId, t.SubjectId });

            modelBuilder.Entity<StudentClass>()
                .HasOne(pt => pt.Student)
                .WithMany(p => p.StudentClasses)
                .HasForeignKey(pt => pt.StudentId);

            modelBuilder.Entity<StudentClass>()
                .HasOne(pt => pt.Subject)
                .WithMany(t => t.StudentClasses)
                .HasForeignKey(pt => pt.SubjectId);

            // take query with .isdeleted = false
            modelBuilder.Entity<Student>().HasQueryFilter(stu => !stu.isDeleted);
            modelBuilder.Entity<Subject>().HasQueryFilter(sub => !sub.isDeleted);
            modelBuilder.Entity<StudentClass>().HasQueryFilter(stc => !stc.isDeleted);




        }

    }
}

