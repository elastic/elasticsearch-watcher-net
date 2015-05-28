using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface IWatcherHttpRequest : INestSerializable
	{
		[JsonProperty("scheme")]
		[JsonConverter(typeof(StringEnumConverter))]
		ConnectionScheme? Scheme { get; set; }

		[JsonProperty("port")]
		int Port { get; set; }

		[JsonProperty("host")]
		string Host { get; set; }

		[JsonProperty("path")]
		string Path { get; set; }

		[JsonProperty("method")]
		[JsonConverter(typeof(StringEnumConverter))]
		HttpMethod? Method { get; set; }

		[JsonProperty("headers")]
		IDictionary<string, string> Headers { get; set; }

		[JsonProperty("params")]
		IDictionary<string, object> Params { get; set; }

		[JsonProperty("auth")]
		IWatcherAuthentication Authentication { get; set; }

		[JsonProperty("body")]
		string Body { get; set; }
	}

	public class WatcherHttpRequest : IWatcherHttpRequest
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

	public class WatcherHttpRequestDescriptor : IWatcherHttpRequest
	{
		private IWatcherHttpRequest Self { get { return this; } }

		public WatcherHttpRequestDescriptor Scheme(ConnectionScheme scheme)
		{
			Self.Scheme = scheme;
			return this;
		}

		public WatcherHttpRequestDescriptor Port(int port)
		{
			Self.Port = port;
			return this;
		}

		public WatcherHttpRequestDescriptor Host(string host)
		{
			Self.Host = host;
			return this;
		}

		public WatcherHttpRequestDescriptor Path(string path)
		{
			Self.Path = path;
			return this;
		}

		public WatcherHttpRequestDescriptor Method(HttpMethod method)
		{
			Self.Method = method;
			return this;
		}

		public WatcherHttpRequestDescriptor Headers(Func<FluentDictionary<string, string>, FluentDictionary<string, string>> headersDictionary)
		{
			Self.Headers = headersDictionary(new FluentDictionary<string, string>());
			return this;
		}

		public WatcherHttpRequestDescriptor Params(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> paramsDictionary)
		{
			Self.Params = paramsDictionary(new FluentDictionary<string, object>());
			return this;
		}

		public WatcherHttpRequestDescriptor Authentication(Func<WatcherAuthenticationDescriptor, IWatcherAuthentication> authSelector)
		{
			Self.Authentication = authSelector(new WatcherAuthenticationDescriptor());
			return this;
		}

		public WatcherHttpRequestDescriptor Body(string body)
		{
			Self.Body = body;
			return this;
		}

		ConnectionScheme? IWatcherHttpRequest.Scheme { get; set; }
		int IWatcherHttpRequest.Port { get; set; }
		string IWatcherHttpRequest.Host { get; set; }
		string IWatcherHttpRequest.Path { get; set; }
		HttpMethod? IWatcherHttpRequest.Method { get; set; }
		IDictionary<string, string> IWatcherHttpRequest.Headers { get; set; }
		IDictionary<string, object> IWatcherHttpRequest.Params { get; set; }
		IWatcherAuthentication IWatcherHttpRequest.Authentication { get; set; }
		string IWatcherHttpRequest.Body { get; set; }
	}
}
