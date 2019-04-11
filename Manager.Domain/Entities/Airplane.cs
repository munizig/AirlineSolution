using System;
using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    public partial class Airplane
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public short ModelId { get; set; }
        public short PassengersQuantity { get; set; }
        public DateTime CreateDateLog { get; set; }

        public AirplaneModel Model { get; set; }
    }
}
