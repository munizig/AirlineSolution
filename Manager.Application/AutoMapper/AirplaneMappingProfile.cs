using AutoMapper;
using Manager.Domain.Contracts;
using Manager.Domain.Entities;
using System;

namespace Manager.Application.AutoMapper
{
    public class AirplaneMappingProfile : Profile
    {
        public AirplaneMappingProfile()
        {
            CreateMap<Airplane, AirplaneContractResponse>()
                .ForMember(dest=> dest.ModelName, opt => opt.MapFrom(src => src.Model.Name));

            CreateMap<AirplaneContractRequest, Airplane>()
                .ConstructUsing(a => new Airplane()
                {
                    Id = a.Id,
                    Code = a.Code,
                    ModelId = a.ModelId,
                    PassengersQuantity = a.PassengersQuantity
                });
        }
    }
}
