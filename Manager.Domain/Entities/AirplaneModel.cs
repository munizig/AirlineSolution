using System;
using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    public partial class AirplaneModel
    {
        public AirplaneModel()
        {
            Airplane = new HashSet<Airplane>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public ICollection<Airplane> Airplane { get; set; }
    }
}
