using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.DTOs;
using UniversityManager.Infrastructure.Exceptions;

namespace UniversityManager.Infrastructure.Services
{
    public class StudySubjectService : IStudySubjectService
    {
        private readonly IStudySubjectRepository _studySubjectRepository;
        private readonly IMapper _mapper;
        private readonly IFieldStudyRepository _fieldStudyRepository;

        public StudySubjectService(IStudySubjectRepository studySubjectRepository, IMapper mapper)
        {
            _studySubjectRepository = studySubjectRepository;
            _mapper = mapper;
        }

        public async Task Add(string name, Guid fieldStudyId, int semester)
        {
            var studySubject = await _studySubjectRepository.Get(name);
            if (studySubject != null)
            {
                throw new ServiceException(ErrorCodes.EmailInUse,
                    $"StudySubject with name: '{name}' already exists.");
            }

            var fieldStudy = await _fieldStudyRepository.Get(fieldStudyId);
            studySubject = new StudySubject(name, fieldStudy, semester);
            await _studySubjectRepository.Add(studySubject);
        }

        public async Task<StudySubjectDto> Get(string name)
        {
            var user = await _studySubjectRepository.Get(name);

            return _mapper.Map<StudySubject, StudySubjectDto>(user);
        }

        public async Task<StudySubjectDto> Get(Guid id)
        {
            var user = await _studySubjectRepository.Get(id);

            return _mapper.Map<StudySubject, StudySubjectDto>(user);
        }

        public async Task<IEnumerable<StudySubjectDto>> Browse()
        {
            var studySubjects = await _studySubjectRepository.GetAll();

            return _mapper.Map<IEnumerable<StudySubject>, IEnumerable<StudySubjectDto>>(studySubjects);
        }
    }
}
