using System;
using System.Collections.Generic;

namespace UniversityManager.Core.Domain
{
    public class Lecturer : User
    {
        public List<StudySubject> StudySubjectsTaught { get; protected set; }
        public Faculty HomeFaculty { get; protected set; }

        protected Lecturer()
        {

        }

        public Lecturer(Guid userId, string email, string username, string role,
            string password, string salt) : base(userId, email, username, role, password, salt)
        {

        }
    }
}
