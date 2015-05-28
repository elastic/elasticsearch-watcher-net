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
	}

	public class LoggingAction : Action, ILoggingAction
	{
		public string Text { get; set; }
	}

}
