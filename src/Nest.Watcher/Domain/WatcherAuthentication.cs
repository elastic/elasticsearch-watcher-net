using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface IWatcherAuthentication : INestSerializable
	{
		[JsonProperty("basic")]
		IWatcherBasicAuthentication Basic { get; set; }
	}

	public class WatcherAuthentication : IWatcherAuthentication
	{
		public IWatcherBasicAuthentication Basic { get; set; }
	}

	[JsonObject]
	public interface IWatcherBasicAuthentication : INestSerializable
	{
		[JsonProperty("username")]
		string Username { get; set; }
		[JsonProperty("password")]
		string Password { get; set; }
	}

	[JsonObject]
	public class WatcherBasicAuthentication : IWatcherBasicAuthentication
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}

	public class WatcherAuthenticationDescriptor : IWatcherAuthentication
	{
		private IWatcherAuthentication Self { get { return this; } }

		public WatcherAuthenticationDescriptor Basic(Func<WatcherBasicAuthenticationDescriptor, IWatcherBasicAuthentication> basicAuthSelector)
		{
			Self.Basic = basicAuthSelector(new WatcherBasicAuthenticationDescriptor());
			return this;
		}

		IWatcherBasicAuthentication IWatcherAuthentication.Basic { get; set; }
	}

	public class WatcherBasicAuthenticationDescriptor : IWatcherBasicAuthentication
	{
		private IWatcherBasicAuthentication Self { get { return this; } }

		public WatcherBasicAuthenticationDescriptor Username(string username)
		{
			Self.Username = username;
			return this;
		}

		public WatcherBasicAuthenticationDescriptor Password(string password)
		{
			Self.Password = password;
			return this;
		}

		string IWatcherBasicAuthentication.Username { get; set; }
		string IWatcherBasicAuthentication.Password { get; set; }
	}
}
