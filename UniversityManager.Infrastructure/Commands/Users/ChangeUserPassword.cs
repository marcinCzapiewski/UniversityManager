﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManager.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : ICommand
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
