using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject]
	public interface IStopWatcherResponse : IResponse
	{
		[JsonProperty("acknowledged")]
		bool Acknowledged { get; }
	}

	public class StopWatcherResponse : BaseResponse, IStopWatcherResponse
	{
		public bool Acknowledged { get; internal set; }
	}
}
