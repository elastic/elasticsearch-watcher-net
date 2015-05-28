using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface IWebhookAction : IAction
	{
		[JsonProperty("request")]
		WatcherHttpRequest Request { get; set; }
	}
	
	public class WebhookAction : Action, IWebhookAction
	{
		public WatcherHttpRequest Request { get; set; }
	}
}
