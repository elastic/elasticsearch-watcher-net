using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public class WatchAcknowledgementState
	{
		[JsonProperty("state")]
		public string State { get; set; }
		[JsonProperty("timestamp")]
		public string Timestamp { get; set; }
	}
}
