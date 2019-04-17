using System;

namespace Manager.Domain.Contracts
{
    public class AirplaneContractResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Model { get; set; }
        public short PassengersQuantity { get; set; }
        public DateTime CreateDateLog { get; set; }
    }
}
