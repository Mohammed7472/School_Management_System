using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using School_Management_System.Models;

namespace School_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassRoom> Classrooms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                 .HasOne(s => s.Classroom)
                 .WithMany(c => c.Students)
                 .HasForeignKey(s => s.ClassRoomId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(std => std.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Subject)
                .WithMany(std => std.Enrollments)
                .HasForeignKey(e => e.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<Teacher>()
                .HasIndex(t => t.Email)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Salary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Grade)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.SubjectId })
                .IsUnique();

            // Seeding Data
            modelBuilder.Entity<Department>()
                .HasData(
                     new Department
                     {
                         Id = 1,
                         Name = "Mathematics",
                         Description = "Mathematics Department"
                     },
                     new Department
                     {
                         Id = 2,
                         Name = "Science",
                         Description = "Science Department"
                     },
                     new Department
                     {
                         Id = 3,
                         Name = "Languages",
                         Description = "Languages Department"
                     }
                );



            modelBuilder.Entity<Teacher>()
                .HasData(
                     new Teacher
                     {
                         Id = 1,
                         FirstName = "Ahmed",
                         LastName = "Hassan",
                         Email = "ahmed.hassan@school.com",
                         PhoneNumber = "01011111111",
                         Salary = 15000m,
                         DepartmentId = 1
                     },
                     new Teacher
                     {
                         Id = 2,
                         FirstName = "Mona",
                         LastName = "Ali",
                         Email = "mona.ali@school.com",
                         PhoneNumber = "01022222222",
                         Salary = 17000m,
                         DepartmentId = 2
                     },
                     new Teacher
                     {
                         Id = 3,
                         FirstName = "Sara",
                         LastName = "Mohamed",
                         Email = "sara.mohamed@school.com",
                         PhoneNumber = "01033333333",
                         Salary = 16000m,
                         DepartmentId = 3
                     }
                );

            modelBuilder.Entity<Subject>()
              .HasData(
                  new Subject
                  {
                      Id = 1,
                      Name = "Algebra",
                      Description = "Basic Algebra",
                      MaxGrade = 100,
                      TeacherId = 1
                  },
                  new Subject
                  {
                      Id = 2,
                      Name = "Physics",
                      Description = "General Physics",
                      MaxGrade = 100,
                      TeacherId = 2
                  },
                  new Subject
                  {
                      Id = 3,
                      Name = "English",
                      Description = "English Language",
                      MaxGrade = 100,
                      TeacherId = 3
                  }
              );

            modelBuilder.Entity<ClassRoom>()
                .HasData(
                    new ClassRoom
                    {
                        Id = 1,
                        Name = "Grade 10-A",
                        GradeLevel = 10,
                        Capacity = 30
                    },
                    new ClassRoom
                    {
                        Id = 2,
                        Name = "Grade 11-B",
                        GradeLevel = 11,
                        Capacity = 25
                    }
                );


            modelBuilder.Entity<Student>()
                 .HasData(
                     new Student
                     {
                         Id = 1,
                         FirstName = "Omar",
                         LastName = "Mahmoud",
                         Email = "omar@student.com",
                         PhoneNumber = "01111111111",
                         DateOfBirth = new DateTime(2008, 5, 10),
                         ClassRoomId = 1
                     },
                     new Student
                     {
                         Id = 2,
                         FirstName = "Youssef",
                         LastName = "Ahmed",
                         Email = "youssef@student.com",
                         PhoneNumber = "01222222222",
                         DateOfBirth = new DateTime(2008, 7, 15),
                         ClassRoomId = 1
                     },
                     new Student
                     {
                         Id = 3,
                         FirstName = "Nada",
                         LastName = "Ali",
                         Email = "nada@student.com",
                         PhoneNumber = "01555555555",
                         DateOfBirth = new DateTime(2007, 3, 25),
                         ClassRoomId = 2
                     }
                 );


            modelBuilder.Entity<Enrollment>()
                .HasData(
                    new Enrollment
                    {
                        Id = 1,
                        StudentId = 1,
                        SubjectId = 1,
                        EnrollmentDate = new DateTime(2025, 1, 15),
                        Grade = 95.50m
                    },
                    new Enrollment
                    {
                        Id = 2,
                        StudentId = 1,
                        SubjectId = 2,
                        EnrollmentDate = new DateTime(2025, 1, 15),
                        Grade = 88.75m
                    },
                    new Enrollment
                    {
                        Id = 3,
                        StudentId = 2,
                        SubjectId = 1,
                        EnrollmentDate = new DateTime(2025, 1, 20),
                        Grade = 91.25m
                    },
                    new Enrollment
                    {
                        Id = 4,
                        StudentId = 3,
                        SubjectId = 3,
                        EnrollmentDate = new DateTime(2025, 2, 1),
                        Grade = 97.00m
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
