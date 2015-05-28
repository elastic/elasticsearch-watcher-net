using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public class WatcherVersion
	{
		[JsonProperty("number")]
		public string Number { get; internal set; }

		[JsonProperty("build_hash")]
		public string BuildHash { get; internal set; }

		[JsonProperty("build_timestamp")]
		public string BuildTimestamp { get; internal set; }

		[JsonProperty("build_snapshot")]
		public bool BuildSnapshot { get; internal set; }
	}
}
