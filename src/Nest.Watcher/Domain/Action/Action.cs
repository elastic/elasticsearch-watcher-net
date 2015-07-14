using Nest.Watcher.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface IAction
	{
		[JsonProperty("transform")]
		TransformContainer Transform { get; set; }

		[JsonIgnore]
		string ThrottlePeriod { get; set; }
	}

	public abstract class Action : IAction
	{
		public TransformContainer Transform { get; set; }

		public string ThrottlePeriod { get; set; }
	}
}
