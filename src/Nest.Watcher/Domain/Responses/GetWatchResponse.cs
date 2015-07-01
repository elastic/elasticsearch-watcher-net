using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject]
	public interface IGetWatchResponse : IResponse
	{
		[JsonProperty("found")]
		bool Found { get; }
		
		[JsonProperty("_id")]
		string Id { get; }
		
		[JsonProperty("_status")]
		WatchStatus Status { get; }

		[JsonProperty("watch")]
		Watch Watch { get; }

	}

	public class GetWatchResponse : BaseResponse, IGetWatchResponse
	{
		public bool Found { get; internal set; }
		public string Id { get; internal set; }
		public WatchStatus Status { get; internal set; }
		public Watch Watch { get; internal set; }
	}
}
