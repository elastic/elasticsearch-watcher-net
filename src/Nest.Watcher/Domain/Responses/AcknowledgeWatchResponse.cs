using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	public interface IAcknowledgeWatchResponse : IResponse
	{
		[JsonProperty("_status")]
		WatchStatus Status { get; }
	}

	public class AcknowledgeWatchResponse : BaseResponse, IAcknowledgeWatchResponse
	{
		public WatchStatus Status { get; internal set; }
	}
}
