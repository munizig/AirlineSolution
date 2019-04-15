using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Manager.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
		public BaseController()
		{

		}

		protected new IActionResult Response(bool success = true, object result = null)
		{
			if(success)
			{
				return Ok(new
				{
					success = true,
					data = result
				});
			}

			return BadRequest(new
			{
				success = false,
				message = ""
			});
		}

		protected new IActionResult Response(object result = null, bool success = true, string message = null)
		{
			if(success)
				return Ok(result);

			return BadRequest(message);
		}
	}
}