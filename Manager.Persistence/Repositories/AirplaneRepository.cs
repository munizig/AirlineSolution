using Manager.Domain.Entities;
using Manager.Domain.Repositories;
using Manager.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Persistence.Repositories
{
    public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
    {
        private AirlineContext AirlineContext;
        public AirplaneRepository(AirlineContext context) : base(context)
        {
            AirlineContext = context;
        }

        public Airplane GetByCode(string code)
        {
            if (!string.IsNullOrWhiteSpace(code))
                return DbSet.AsNoTracking().FirstOrDefault(x => x.Code.ToUpper() == code);

            return null;
        }

        public IEnumerable<Airplane> GetAll()
        {
            return AirlineContext.Airplane.Include(x => x.Model).ToList();
        }
    }
}