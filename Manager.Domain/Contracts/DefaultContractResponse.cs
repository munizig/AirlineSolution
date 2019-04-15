using System;
using System.Net;
using Newtonsoft.Json;

namespace Manager.Domain.Contracts
{
	public class DefaultContractResponse
	{
		public int StatusCode { get; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Message { get; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object Data { get; }

		public DefaultContractResponse(HttpStatusCode status, string message)
		{
			StatusCode = Convert.ToInt32(status);
			Message = message;
		}

		public DefaultContractResponse(HttpStatusCode status, object data)
		{
			StatusCode = Convert.ToInt32(status);
			Data = data;
		}
	}
}
