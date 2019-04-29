using Microsoft.EntityFrameworkCore;

namespace UniversityManager.Infrastructure.EF
{
    public class UniversityManagerContext : DbContext
    {
        private readonly SqlSettings _settings;

        public UniversityManagerContext(DbContextOptions options, SqlSettings settings)
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
        }
    }
}
