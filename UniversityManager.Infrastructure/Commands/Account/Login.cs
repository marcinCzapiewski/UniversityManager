using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManager.Infrastructure.Commands.Account
{
    public class Login : ICommand
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
