using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.EF;

namespace UniversityManager.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly UniversityManagerContext _context;

        public AttendanceRepository(UniversityManagerContext context)
        {
            _context = context;
        }

        public async Task Add(Attendance studySubject)
        {
            await _context.Attendances.AddAsync(studySubject);
            await _context.SaveChangesAsync();
        }

        public async Task<Attendance> Get(Guid id)
            => await _context.Attendances.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Attendance>> GetAll()
            => await _context.Attendances.ToListAsync();

        public async Task<IEnumerable<Attendance>> GetLectureAttendances(Guid LectureId)
            => await _context.Attendances.Where(x => x.Lecture.Id == LectureId).ToListAsync();

        public async Task<IEnumerable<Attendance>> GetStudentAttendances(Guid StudentId)
            => await _context.Attendances.Where(x => x.Student.Id == StudentId).ToListAsync();
        public async Task Remove(Guid id)
        {
            var attendance = await Get(id);
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
        }
    }
}
