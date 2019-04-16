using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manager.Domain.Contracts
{
    public class AirplaneContractRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Code is required.")]
        [MaxLength(20)]
        [MinLength(2)]
        [DisplayName("Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The Model is required.")]
        [DisplayName("Model")]
        public short ModelId { get; set; }

        [DisplayName("Passengers Qtt.")]
        [Required(ErrorMessage = "The Passengers Quantity is required.")]
        public short PassengersQuantity { get; set; }
    }
}
