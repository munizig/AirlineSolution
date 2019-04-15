using AutoMapper;
using Manager.Domain.Contracts;
using Manager.Domain.Entities;

namespace Manager.Application.AutoMapper
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<AirplaneContract, Airplane>()
				.ForMember(src => src.Model, opt => opt.Ignore())
				.ReverseMap();
		}
	}
}
