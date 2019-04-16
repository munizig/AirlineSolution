using Manager.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace Manager.Domain.Services
{
    public interface IAirplaneService
    {
        AirplaneContractResponse GetById(Guid id);
        List<AirplaneContractResponse> GetAll();
        AirplaneContractResponse Create(AirplaneContractRequest airplane);
        void Update(AirplaneContractRequest airplane);
        void Delete(Guid id);
        AirplaneContractResponse GetByCode(string code);
    }
}