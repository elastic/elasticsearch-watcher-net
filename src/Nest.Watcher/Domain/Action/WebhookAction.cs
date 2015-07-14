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
	}
	
	public class WebhookAction : Action, IWebhookAction, IWatcherHttpRequest
	{
		public ConnectionScheme? Scheme { get; set; }

		public int Port { get; set; }

		public string Host { get; set; }

		public string Path { get; set; }

		public HttpMethod? Method { get; set; }

		public IDictionary<string, string> Headers { get; set; }

		public IDictionary<string, object> Params { get; set; }

		public IWatcherAuthentication Authentication { get; set; }

		public string Body { get; set; }
	}
}
