using Microsoft.EntityFrameworkCore;
using School.Data.Models;

namespace Shcool.Infrustructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);





        }

    }
}
#region Fluent API
//modelBuilder.Entity<Instructor>()
//    .HasOne(x => x.Supervisor)
//    .WithMany(x => x.Instructors)
//    .HasForeignKey(x => x.SupervisorId)
//    .OnDelete(DeleteBehavior.Restrict);

//modelBuilder.Entity<DepartmetSubject>(entity =>
//{
//    entity.HasOne(dc => dc.Department)
//    .WithMany(d => d.DepartmentSubjects)
//            .HasForeignKey(dc => dc.DID)
//            .OnDelete(DeleteBehavior.Restrict);

//    entity.HasOne(dc => dc.Subjects)
//      .WithMany(d => d.DepartmetsSubjects)
//    .HasForeignKey(dc => dc.SubID)
//    .OnDelete(DeleteBehavior.Restrict);

//});
//modelBuilder.Entity<Ins_Subject>(entity =>
//{
//    entity.HasOne(dc => dc.Instructor)
//    .WithMany(d => d.Ins_Subjects)
//            .HasForeignKey(dc => dc.InsId)
//            .OnDelete(DeleteBehavior.Restrict);

//    entity.HasOne(dc => dc.Subject)
//      .WithMany(d => d.InsSubjects)
//    .HasForeignKey(dc => dc.SubID)
//    .OnDelete(DeleteBehavior.Restrict);

//});
//modelBuilder.Entity<StudentSubject>(entity =>
//{
//    entity.HasOne(dc => dc.Subject)
//    .WithMany(d => d.StudentsSubjects)
//            .HasForeignKey(dc => dc.SubID)
//            .OnDelete(DeleteBehavior.Restrict);

//    entity.HasOne(dc => dc.Subject)
//      .WithMany(d => d.StudentsSubjects)
//    .HasForeignKey(dc => dc.SubID)
//    .OnDelete(DeleteBehavior.Restrict);

//});
#endregion
