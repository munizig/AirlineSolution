using AutoMapper;
using Manager.Application.Extensions;
using Manager.Domain.Contracts;
using Manager.Domain.Entities;
using Manager.Domain.Repositories;
using Manager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public AirplaneContractResponse GetById(Guid id)
        {
            return Mapper.Map<AirplaneContractResponse>(AirplaneRepository.GetById(id));
        }

        public List<AirplaneContractResponse> GetAll()
        {
            return Mapper.Map<List<AirplaneContractResponse>>(AirplaneRepository.GetAll().ToList());
        }

        public AirplaneContractResponse Create(AirplaneContractRequest airplane)
        {
            try
            {
                if (GetByCode(airplane.Code) == null)
                {
                    var airplaneNew = Mapper.Map<Airplane>(airplane);
                    AirplaneRepository.Add(airplaneNew);
                    AirplaneRepository.SaveChanges();
                    return Mapper.Map<AirplaneContractResponse>(airplaneNew);
                }

                throw new ArgumentException("An Airplane with this Code is already registered.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(AirplaneContractRequest airplane)
        {
            if (airplane.Id != Guid.Empty)
            {
                var updAirplane = Mapper.Map<Airplane>(airplane);
                AirplaneRepository.Update(updAirplane);
                AirplaneRepository.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            AirplaneRepository.Remove(id);
            AirplaneRepository.SaveChanges();
        }

        public AirplaneContractResponse GetByCode(string code)
        {
            if (!string.IsNullOrWhiteSpace(code))
                return Mapper.Map<AirplaneContractResponse>(AirplaneRepository.GetByCode(code.TrimSafe()));

            return null;
        }

    }
}
