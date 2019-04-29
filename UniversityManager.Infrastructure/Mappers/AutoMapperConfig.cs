using AutoMapper;

namespace UniversityManager.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(config =>
            {

            })
            .CreateMapper();
    }
}
