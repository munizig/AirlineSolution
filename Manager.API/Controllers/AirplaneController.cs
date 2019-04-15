using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Manager.Domain.Contracts;
using Manager.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AirplaneController : BaseController
	{
		public IAirplaneService AirplaneService { get; }

		public AirplaneController(IAirplaneService airplaneService)
		{
			AirplaneService = airplaneService ??
				throw new ArgumentNullException(nameof(airplaneService));
		}

		// GET: api/Airplane
		[HttpGet]
		public IActionResult Get()
		{
			var result = AirplaneService.GetAll();
			if(result != null)
				return Ok(result);

			return NoContent();
		}

		// GET: api/Airplane/5
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(Guid id)
		{
			var result = AirplaneService.GetById(id);
			if(result != null)
				return Ok(result);

			return NoContent();
		}

		// POST: api/Airplane
		[HttpPost]
		public IActionResult Post([FromBody] AirplaneContract airplaneContract)
		{
			if(!ModelState.IsValid)
				return BadRequest();

			var result = AirplaneService.Create(airplaneContract);

			return Ok(result);
		}

		// PUT: api/Airplane/5
		[HttpPut("{id}")]
		public IActionResult Put([FromBody] AirplaneContract airplaneContract)
		{
			if(!ModelState.IsValid)
				return BadRequest();

			AirplaneService.Update(airplaneContract);

			return Ok(airplaneContract);
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			AirplaneService.Delete(id);

			return NoContent();
		}
	}
}
