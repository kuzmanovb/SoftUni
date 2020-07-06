﻿using Microsoft.EntityFrameworkCore;

using P01_StudentSystem.Data.Models;


namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> opctions)
            : base(opctions)
        {

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(@"Server = BIBI - PC\SQLEXPRESS; Database = SoftUni; Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity
                .Property(s => s.Name)
                .HasMaxLength(100);

                entity
                .Property(s => s.PhoneNumber)
                .HasColumnType("char")
                .HasMaxLength(10)
                .IsUnicode(false);

            });

          
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsRequired();
           
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity
                .Property(r => r.Name)
                .HasMaxLength(50);

                entity
                .Property(r => r.Url)
                .IsUnicode(false);

                entity
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);

            });

            modelBuilder.Entity<Homework>(entity => 
            {
                entity.HasKey(h => h.HomeworkId);

                entity
                .Property(h => h.Content)
                .IsUnicode(false);

                entity
                .HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId);

                entity
                .HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);

            });

            modelBuilder.Entity<StudentCourse>(entity => 
            {
                entity.HasKey(ps => new { ps.StudentId, ps.CourseId });

                entity
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }


    }
}
