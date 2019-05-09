using System;
using System.Threading.Tasks;

namespace UniversityManager.Infrastructure.Services
{
    public interface IHandlerTaskRunner
    {
        IHandlerTask Run(Func<Task> runAsync);
    }
}
