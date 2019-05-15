using AutoMapper;
using UniversityManager.Core.Domain;
using UniversityManager.Infrastructure.DTOs;

namespace UniversityManager.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDto>();
                config.CreateMap<Login, LoginDto>();
                config.CreateMap<StudySubject, StudySubjectDto>();
                config.CreateMap<FieldStudy, FieldStudyDto>();
            })
            .CreateMapper();
    }
}
