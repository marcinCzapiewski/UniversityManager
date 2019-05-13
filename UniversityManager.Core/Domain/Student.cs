using System;
using System.Collections.Generic;

namespace UniversityManager.Core.Domain
{
    public class Student : User
    {
        public FieldStudy FieldStudy { get; protected set; }
        public int Semester { get; protected set; }
        public int IndexNumber { get; protected set; }

        protected Student()
        {

        }

        public Student(Guid userId, string email, string username, string role,
            string password, string salt) : base(userId, email, username, role, password, salt)
        {

        }
    }
}
