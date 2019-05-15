using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.EF;

namespace UniversityManager.Infrastructure.Repositories
{
    public class FieldStudyRepository : IFieldStudyRepository
    {
        private readonly UniversityManagerContext _context;

        public FieldStudyRepository(UniversityManagerContext context)
        {
            _context = context;
        }

        public async Task Add(FieldStudy fieldStudy)
        {
            await _context.FieldStudies.AddAsync(fieldStudy);
            await _context.SaveChangesAsync();
        }

        public async Task<FieldStudy> Get(string name)
            => await _context.FieldStudies.SingleOrDefaultAsync(x => x.Name == name);

        public async Task<FieldStudy> Get(Guid id)
            => await _context.FieldStudies.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<FieldStudy>> GetAll()
            => await _context.FieldStudies.ToListAsync();


        public async Task Remove(Guid id)
        {
            var studySubject = await Get(id);
            _context.FieldStudies.Remove(studySubject);
            await _context.SaveChangesAsync();
        }

        public async Task Update(FieldStudy fieldStudy)
        {
            _context.FieldStudies.Update(fieldStudy);
            await _context.SaveChangesAsync();
        }
    }
}
