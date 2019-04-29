using System.Threading.Tasks;

namespace UniversityManager.Infrastructure.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task Handle(T command);
    }
}
