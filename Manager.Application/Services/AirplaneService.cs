using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Manager.Domain.Contracts;
using Manager.Domain.Entities;
using Manager.Domain.Repositories;
using Manager.Domain.Services;

namespace Manager.Application.Services
{
	public class AirplaneService : IAirplaneService
	{
		public IAirplaneRepository AirplaneRepository { get; }
		public IMapper Mapper { get; }

		public AirplaneService(IAirplaneRepository airPlaneRepository,
			IMapper mapper)
		{
			AirplaneRepository = airPlaneRepository ??
				throw new ArgumentNullException(nameof(airPlaneRepository));
			Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}


		public AirplaneContract GetById(Guid id)
		{
			return Mapper.Map<AirplaneContract>(AirplaneRepository.GetById(id));
		}

		public List<AirplaneContract> GetAll()
		{
			return Mapper.Map<List<AirplaneContract>>(AirplaneRepository.GetAll().ToList());
		}

		public AirplaneContract Create(AirplaneContract airplane)
		{
			var airplaneNew = Mapper.Map<Airplane>(airplane);
			AirplaneRepository.Add(airplaneNew);
			AirplaneRepository.SaveChanges();
			return Mapper.Map<AirplaneContract>(airplaneNew);
		}

		public void Update(AirplaneContract airplane)
		{
			AirplaneRepository.Update(Mapper.Map<Airplane>(airplane));
			AirplaneRepository.SaveChanges();
		}

		public void Delete(Guid id)
		{
			AirplaneRepository.Remove(id);
			AirplaneRepository.SaveChanges();
		}

	}
}
