using System;

namespace UniversityManager.Infrastructure.DTOs
{
    public class LoginDto
    {
        public Guid Id { get; set; }
        public DateTime LoggedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
