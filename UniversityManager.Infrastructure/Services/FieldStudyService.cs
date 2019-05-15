using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Core.Domain;
using UniversityManager.Core.Repositories;
using UniversityManager.Infrastructure.DTOs;
using UniversityManager.Infrastructure.Exceptions;
using UniversityManager.Infrastructure.Services.Interfaces;

namespace UniversityManager.Infrastructure.Services
{
    public class FieldStudyService : IFieldStudyService
    {
        private readonly IFieldStudyRepository _fieldStudyRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;

        public FieldStudyService(IFieldStudyRepository fieldStudyRepository, IMapper mapper)
        {
            _fieldStudyRepository = fieldStudyRepository;
            _mapper = mapper;
        }

        public async Task Add(string name, Guid facultyId)
        {
            var fieldStudy = await _fieldStudyRepository.Get(name);
            if (fieldStudy != null)
            {
                throw new ServiceException(ErrorCodes.EmailInUse,
                    $"FieldStudy with name: '{name}' already exists.");
            }

            var faculty = await _facultyRepository.Get(facultyId);
            fieldStudy = new FieldStudy(name, faculty);
            await _fieldStudyRepository.Add(fieldStudy);
        }

        public async Task<FieldStudyDto> Get(string name)
        {
            var fieldStudy = await _fieldStudyRepository.Get(name);

            return _mapper.Map<FieldStudy, FieldStudyDto>(fieldStudy);
        }

        public async Task<FieldStudyDto> Get(Guid id)
        {
            var fieldStudy = await _fieldStudyRepository.Get(id);

            return _mapper.Map<FieldStudy, FieldStudyDto>(fieldStudy);
        }

        public async Task<IEnumerable<FieldStudyDto>> Browse()
        {
            var fieldStudies = await _fieldStudyRepository.GetAll();

            return _mapper.Map<IEnumerable<FieldStudy>, IEnumerable<FieldStudyDto>>(fieldStudies);
        }
    }
}
