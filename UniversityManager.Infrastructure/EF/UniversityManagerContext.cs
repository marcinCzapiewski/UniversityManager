using Microsoft.EntityFrameworkCore;
using UniversityManager.Core.Domain;

namespace UniversityManager.Infrastructure.EF
{
    public class UniversityManagerContext : DbContext
    {
        private readonly SqlSettings _settings;
        
        public DbSet<User> Users { get; set; }

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
    }
}
