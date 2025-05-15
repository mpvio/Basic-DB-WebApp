using System.Reflection;
using BasicDBWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicDBWebApp.MyDbContext
{
    public class ApplicationDbContext : DbContext
    {
        //entities
        public virtual DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; } 
        public DbSet<StudentCourse> StudentCourses { get; set; }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //string appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    //string databasePath = Path.Combine(appDir, "Database");

        //    //if (!Directory.Exists(databasePath))
        //    //{
        //    //    Directory.CreateDirectory(databasePath);
        //    //}

        //    //var connectionString = "Server=(localdb)\\mssqllocaldb;AttachDbFilename={AppDir}\\Database\\BasicDBWebApp.mdf;Database=BasicDBWebApp;Trusted_Connection=True;MultipleActiveResultSets=true"
        //    //    .Replace("{AppDir}", appDir.Replace("\\", "\\\\"));

        //    //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=BasicDBWebApp;AttachDbFilename=E:\\_Desktop\\Coding Work\\BasicDBWebApp\\Database\\BasicDB.mdf;Database=BasicDB;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //define primary keys
            modelBuilder.Entity<Student>()
                .Property(s => s.StudentID)
                .IsRequired();

            modelBuilder.Entity<Grade>()
                .Property(g => g.GradeID)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(c => c.CourseID)
                .IsRequired();

            //1:M
            modelBuilder.Entity<Student>()
                .HasOne<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeID)
                .OnDelete(DeleteBehavior.Restrict);

            //M:M
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new {sc.StudentID, sc.CourseID});
        }
    }
}
