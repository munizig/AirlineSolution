using Manager.Domain.Contracts;
using Manager.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Manager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : BaseController
    {
        public IAirplaneService AirplaneService { get; }

        public AirplanesController(IAirplaneService airplaneService)
        {
            AirplaneService = airplaneService ??
                throw new ArgumentNullException(nameof(airplaneService));
        }

        // GET: api/Airplane
        [HttpGet]
        public IActionResult Get()
        {
            var result = AirplaneService.GetAll();
            if (result != null)
                return Ok(result);

            return NoContent();
        }

        // GET: api/Airplane/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var result = AirplaneService.GetById(id);
            if (result != null)
                return Ok(result);

            return NoContent();
        }

        // POST: api/Airplane
        [HttpPost]
        public IActionResult Post([FromBody] AirplaneContract airplaneContract)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(AirplaneService.Create(airplaneContract));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(
                    new DefaultContractResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        // PUT: api/Airplane/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] AirplaneContract airplaneContract)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                AirplaneService.Update(airplaneContract);

                return Ok(airplaneContract);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(
                    new DefaultContractResponse(HttpStatusCode.BadRequest, ex.Message));
            }
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
