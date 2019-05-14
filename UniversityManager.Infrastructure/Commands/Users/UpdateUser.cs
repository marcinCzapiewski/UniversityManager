namespace UniversityManager.Infrastructure.Commands.Users
{
    public class UpdateUser : ICommand
    {
        public string OldEmail { get; set; }
        public string OldUsername { get; set; }
        public string NewEmail { get; set; }
        public string NewUsername { get; set; }
    }
}

