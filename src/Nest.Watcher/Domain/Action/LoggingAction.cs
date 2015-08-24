using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface ILoggingAction : IAction
	{
		[JsonProperty("text")]
		string Text { get; set; }

		[JsonProperty("category")]
		string Category { get; set; }

		[JsonProperty("level")]
		LogLevel? Level { get; set; }
	}

	public class LoggingAction : Action, ILoggingAction
	{
		public string Text { get; set; }
		public string Category { get; set; }
		public LogLevel? Level { get; set; }
	}

}
