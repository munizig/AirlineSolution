using Manager.Domain.Entities;
using Manager.Domain.Repositories;
using Manager.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Persistence.Repositories
{
	public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
	{
		public AirplaneRepository(AirlineContext context) : base(context)
		{

		}
	}
}