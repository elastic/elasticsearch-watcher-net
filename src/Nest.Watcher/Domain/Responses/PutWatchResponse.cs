using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject]
	public interface IPutWatchResponse : IResponse
	{
		[JsonProperty("_id")]
		string Id { get; }
		[JsonProperty("_version")]
		int Version { get; }
		[JsonProperty("created")]
		bool Created { get; }
	}

	public class PutWatchResponse : BaseResponse, IPutWatchResponse
	{
		public string Id { get; internal set; }
		public int Version { get; internal set; }
		public bool Created { get; internal set; }
	}
}
