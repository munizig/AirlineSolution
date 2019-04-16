using AutoMapper;

namespace Manager.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new AirplaneMappingProfile());
            });
        }
    }
}
