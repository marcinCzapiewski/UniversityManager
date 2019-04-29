using System.Threading.Tasks;

namespace UniversityManager.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
        Task Dispatch<T>(T command) where T : ICommand;
    }
}
