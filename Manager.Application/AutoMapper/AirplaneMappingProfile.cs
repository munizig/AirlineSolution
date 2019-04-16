using AutoMapper;
using Manager.Domain.Contracts;
using Manager.Domain.Entities;

namespace Manager.Application.AutoMapper
{
    public class AirplaneMappingProfile : Profile
    {
        public AirplaneMappingProfile()
        {
            CreateMap<Airplane, AirplaneContract>();
            CreateMap<AirplaneContract, Airplane>();
        }
    }
}
