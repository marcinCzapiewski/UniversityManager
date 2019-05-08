using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManager.Infrastructure.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
