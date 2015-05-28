using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject]
	public interface IRestartWatcherResponse : IResponse
	{
		[JsonProperty("acknowledged")]
		bool Acknowledged { get; }
	}

	public class RestartWatcherResponse : BaseResponse, IRestartWatcherResponse
	{
		public bool Acknowledged { get; internal set; }
	}
}
