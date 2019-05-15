using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.EF;

namespace UniversityManager.Infrastructure.Repositories
{
    public class StudySubjectRepository : IStudySubjectRepository, IRepository
    {
        private readonly UniversityManagerContext _context;

        public StudySubjectRepository(UniversityManagerContext context)
        {
            _context = context;
        }

        public async Task Add(StudySubject studySubject)
        {
            await _context.StudySubjects.AddAsync(studySubject);
            await _context.SaveChangesAsync();
        }

        public async Task<StudySubject> Get(string name)
            => await _context.StudySubjects.SingleOrDefaultAsync(x => x.Name == name);

        public async Task<StudySubject> Get(Guid id)
            => await _context.StudySubjects.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<StudySubject>> GetAll()
            => await _context.StudySubjects.ToListAsync();


        public async Task Remove(Guid id)
        {
            var studySubject = await Get(id);
            _context.StudySubjects.Remove(studySubject);
            await _context.SaveChangesAsync();
        }

        public async Task Update(StudySubject studySubject)
        {
            _context.StudySubjects.Update(studySubject);
            await _context.SaveChangesAsync();
        }
    }
}
