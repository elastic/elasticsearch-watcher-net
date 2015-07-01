using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public class WatchStatus
	{
		[JsonProperty("actions")]
		public Dictionary<string, ActionStatus> Actions { get; set; }
	}

	public class ActionStatus
	{
		[JsonProperty("ack")]
		public WatchAcknowledgementState Acknowledgement { get; set; }
	}
}
