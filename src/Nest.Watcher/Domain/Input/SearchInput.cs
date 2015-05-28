using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using Newtonsoft.Json.Converters;
using Nest.Watcher.Serialization;
using Nest.Resolvers.Converters;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<SearchInput>))]
	public interface ISearchInput : IInput, INestSerializable
	{
		[JsonProperty("extract")]
		IEnumerable<string> Extract { get; set; }

		[JsonProperty("request")]
		ISearchInputRequest Request { get; set; }
	}


	public class SearchInput : InputBase, ISearchInput
	{
		public IEnumerable<string> Extract { get; set; }

		public ISearchInputRequest Request { get; set; }

		internal override void ContainIn(IInputContainer container)
		{
			container.Search = this;
		}
	}

	public class SearchInputDescriptor : ISearchInput
	{
		private ISearchInput Self { get { return this; } }

		IEnumerable<string> ISearchInput.Extract { get; set; }
		ISearchInputRequest ISearchInput.Request { get; set; }

		public SearchInputDescriptor Request(Func<SearchInputRequestDescriptor, ISearchInputRequest> selector)
		{
			Self.Request = selector(new SearchInputRequestDescriptor());
			return this;
		}

		public SearchInputDescriptor Extract(IEnumerable<string> extract)
		{
			Self.Extract = extract;
			return this;
		}

		public SearchInputDescriptor Extract(params string[] extract)
		{
			Self.Extract = extract;
			return this;
		}
	}
}
