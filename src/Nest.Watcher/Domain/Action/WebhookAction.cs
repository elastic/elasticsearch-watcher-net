using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nest.Resolvers.Converters;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<WebhookAction>))]
	public interface IWebhookAction : IAction, IWatcherHttpRequest
	{
	}
	
	public class WebhookAction : Action, IWebhookAction
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
