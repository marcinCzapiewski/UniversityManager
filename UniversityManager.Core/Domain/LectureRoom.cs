using System;

namespace UniversityManager.Core.Domain
{
    public class LectureRoom
    {
        public Guid Id { get; protected set; }
        public int Number { get; protected set; }

        protected LectureRoom()
        {

        }
    }
}
