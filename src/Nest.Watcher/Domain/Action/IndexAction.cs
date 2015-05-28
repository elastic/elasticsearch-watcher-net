using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface IIndexAction : IAction
	{
		[JsonProperty("index")]
		string Index { get; set; }
		[JsonProperty("doc_type")]
		string DocType { get; set; }
	}

	public class IndexAction : Action, IIndexAction
	{
		public string Index { get; set; }
		public string DocType { get; set; }
	}
}
