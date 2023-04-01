using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data 
{
    public class StudentSystemContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=StudentSystem;Integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(x => x.StudentId);

            modelBuilder.Entity<Student>().Property(x => x.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired();

            modelBuilder.Entity<Student>().Property(x => x.PhoneNumber)
               .IsFixedLength()
               .HasMaxLength(10)
               .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasKey(x => x.CourseId);

            modelBuilder.Entity<Course>().Property(x => x.Name)
               .HasMaxLength(80)
               .IsUnicode(true)
               .IsRequired();

            modelBuilder.Entity<Course>().Property(x => x.Description)
               .IsUnicode(true);

            modelBuilder.Entity<Resource>()
                .HasKey(x => x.ResourceId);

            modelBuilder.Entity<Resource>().Property(x => x.Name)
               .HasMaxLength(50)
               .IsUnicode(true)
               .IsRequired();

            modelBuilder.Entity<Resource>().Property(x => x.Url)
               .IsUnicode(false);

            modelBuilder.Entity<Homework>()
                 .HasKey(x => x.HomeworkId);

            modelBuilder.Entity<Homework>().Property(x => x.Content)
               .IsUnicode(false);

            modelBuilder.Entity<StudentCourse>()
                  .HasKey(x => new { x.CourseId, x.StudentId });
                
        }
    }
}
