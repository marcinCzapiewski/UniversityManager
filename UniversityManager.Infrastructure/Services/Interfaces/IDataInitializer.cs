using System.Threading.Tasks;

namespace UniversityManager.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        Task Seed();
    }
}
