using System;

namespace UniversityManager.Core.Domain
{
    public class Login
    {
        public Guid Id { get; protected set; }
        public DateTime LoggedAt { get; protected set; }
        public User User { get; protected set; }

        protected Login()
        {

        }

        public Login(User user)
        {
            Id = Guid.NewGuid();
            LoggedAt = DateTime.Now;
            User = user;
        }
    }
}
