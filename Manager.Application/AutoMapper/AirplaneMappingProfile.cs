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
            CreateMap<Airplane, AirplaneContractResponse>();
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
