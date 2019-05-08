using NLog;
using System;
using System.Threading.Tasks;
using UniversityManager.Core.Domain.Exceptions;

namespace UniversityManager.Infrastructure.Services
{
    public interface IHandlerTask
    {
        IHandlerTask Always(Func<Task> always);
        IHandlerTask OnCustomError(Func<UniversityManagerException, Task> onCustomError,
            bool propagateException = false, bool executeOnError = false);
        IHandlerTask OnCustomError(Func<UniversityManagerException, Logger, Task> onCustomError,
            bool propagateException = false, bool executeOnError = false);
        IHandlerTask OnError(Func<Exception, Task> onError, bool propagateException = false);
        IHandlerTask OnError(Func<Exception, Logger, Task> onError, bool propagateException = false);
        IHandlerTask OnSuccess(Func<Task> onSuccess);
        IHandlerTask PropagateException();
        IHandlerTask DoNotPropagateException();
        IHandler Next();
        Task ExecuteAsync();
    }
}
