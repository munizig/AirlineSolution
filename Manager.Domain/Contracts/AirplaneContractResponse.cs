﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Manager.Domain.Contracts
{
	public class AirplaneContractResponse
	{
		public Guid Id { get; set; }
		public string Code { get; set; }
		public short ModelId { get; set; }
		public short PassengersQuantity { get; set; }
	}
}