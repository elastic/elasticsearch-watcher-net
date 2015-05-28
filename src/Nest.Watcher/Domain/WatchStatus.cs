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
		[JsonProperty("ack")]
		public WatchAcknowledgementState AcknowledgementState { get; set; }
	}
}
