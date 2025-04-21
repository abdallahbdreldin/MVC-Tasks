using Microsoft.EntityFrameworkCore;

namespace Task1.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base()
        {

        }

        public CompanyContext(DbContextOptions<CompanyContext> options):base(options)
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrsResult>()
                .HasKey(c => new { c.Crs_Id, c.Trainee_Id });

            modelBuilder.Entity<CrsResult>()
                .HasOne(c => c.Course)
                .WithMany(crs => crs.CrsResults)
                .HasForeignKey(c => c.Crs_Id);

            modelBuilder.Entity<CrsResult>()
                .HasOne(t => t.Trainee)
                .WithMany(crs => crs.CrsResults)
                .HasForeignKey(t => t.Trainee_Id);
        }
    }
}
