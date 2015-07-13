using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public class ExecutionThreadPool
	{
		[JsonProperty("queue_size")]
		public int QueueSize { get; internal set; }

		[JsonProperty("max_size")]
		public int MaxSize { get; internal set; }
	}
}
