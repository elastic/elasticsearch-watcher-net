using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public class WatcherExecutionQueue
	{
		[JsonProperty("size")]
		public int Size { get; internal set; }

		[JsonProperty("max_size")]
		public int MaxSize { get; internal set; }
	}
}
