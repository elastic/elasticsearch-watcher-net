using Nest.Watcher.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public class Watch
	{
		[JsonProperty("metadata")]
		public IDictionary<string, object> Metadata { get; internal set; }

		[JsonProperty("input")]
		public InputContainer Input { get; internal set; }

		[JsonProperty("condition")]
		public ConditionContainer Condition { get; internal set; }

		[JsonProperty("trigger")]
		public TriggerContainer Trigger { get; internal set; }

		[JsonProperty("actions")]
		[JsonConverter(typeof(ActionDictionaryConverter))]
		public IDictionary<string, IAction> Actions { get; internal set; }

		[JsonProperty("status")]
		public WatchStatus Status { get; internal set; }

		[JsonProperty("throttle_period")]
		public string ThrottlePeriod { get; internal set; }
	}
}
