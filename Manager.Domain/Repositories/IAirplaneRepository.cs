using System;
using System.Collections.Generic;
using System.Text;
using Manager.Domain.Entities;

namespace Manager.Domain.Repositories
{
    public interface IAirplaneRepository : IRepository<Airplane>
    {
        Airplane GetByCode(string code);
    }
}
