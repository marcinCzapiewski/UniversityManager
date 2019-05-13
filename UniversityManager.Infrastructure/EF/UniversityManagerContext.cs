using Microsoft.EntityFrameworkCore;
using UniversityManager.Core.Domain;

namespace UniversityManager.Infrastructure.EF
{
    public class UniversityManagerContext : DbContext
    {
        private readonly SqlSettings _settings;

        public DbSet<User> Users { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudySubject> StudySubject { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<LectureRoom> LectureRooms { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public UniversityManagerContext(DbContextOptions<UniversityManagerContext> options, SqlSettings settings)
            : base(options)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_settings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("university");

                return;
            }

            optionsBuilder.UseSqlServer(_settings.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .Property(p => p.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Student>()
                .Property(p => p.IndexNumber)
                .HasMaxLength(6)
                .IsFixedLength();
        }
    }
}
