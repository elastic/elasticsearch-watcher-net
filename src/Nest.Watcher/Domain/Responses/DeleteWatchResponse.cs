using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	public interface IDeleteWatchResponse : IResponse
	{
		[JsonProperty("_id")]
		string Id { get; }
		[JsonProperty("_version")]
		int Version { get; }
		[JsonProperty("found")]
		bool Found { get; }
	}
	public class DeleteWatchResponse : BaseResponse, IDeleteWatchResponse
	{
		public string Id { get; internal set; }
		public int Version { get; internal set; }
		public bool Found { get; internal set; }
	}
}
