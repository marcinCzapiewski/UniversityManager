using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManager.Core.Domain
{
    public class Login
    {
        public Guid Id { get; protected set; }
        public DateTime LoggedAt { get; protected set; }
        public User User { get; protected set; }
    }
}
