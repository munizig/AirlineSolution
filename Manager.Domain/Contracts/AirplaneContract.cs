using System;
using System.ComponentModel.DataAnnotations;

namespace Manager.Domain.Contracts
{
	public class AirplaneContract
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "The Code is required.")]
		public string Code { get; set; }

		[Required(ErrorMessage = "The Model is required.")]
		public short ModelId { get; set; }

		[Required(ErrorMessage = "The Passengers Quantity is required.")]
		public short PassengersQuantity { get; set; }

		public DateTime CreateDateLog { get; set; }
	}
}
