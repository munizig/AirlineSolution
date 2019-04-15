using System;
using System.Collections.Generic;
using Manager.Domain.Contracts;

namespace Manager.Domain.Services
{
	public interface IAirplaneService
	{
		AirplaneContract Create(AirplaneContract airplane);
		void Delete(Guid id);
		List<AirplaneContract> GetAll();
		AirplaneContract GetById(Guid id);
		void Update(AirplaneContract airplane);
	}
}