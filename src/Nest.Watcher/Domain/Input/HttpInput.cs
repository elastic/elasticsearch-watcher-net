using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonConverter(typeof(ReadAsTypeConverter<HttpInput>))]
	public interface IHttpInput : IInput, INestSerializable
	{
		[JsonProperty("extract")]
		IEnumerable<string> Extract { get; set; }

		[JsonProperty("request")]
		IWatcherHttpRequest Request { get; set; }
	}

	public class HttpInput : InputBase, IHttpInput
	{
		public IEnumerable<string> Extract { get; set; }

		public IWatcherHttpRequest Request { get; set; }

		internal override void ContainIn(IInputContainer container)
		{
			container.Http = this;
		}
	}
	

	public class HttpInputDescriptor : IHttpInput
	{
		private IHttpInput Self { get { return this; }}

		IEnumerable<string> IHttpInput.Extract { get; set; }
		IWatcherHttpRequest IHttpInput.Request { get; set; }
		
		public HttpInputDescriptor Request(Func<WatcherHttpRequestDescriptor, IWatcherHttpRequest> httpRequestSelector)
		{
			Self.Request = httpRequestSelector(new WatcherHttpRequestDescriptor());
			return this;
		}

		public HttpInputDescriptor Extract(IEnumerable<string> extract)
		{
			Self.Extract = extract;
			return this;
		}

		public HttpInputDescriptor Extract(params string[] extract)
		{
			Self.Extract = extract;
			return this;
		}

	}

}
