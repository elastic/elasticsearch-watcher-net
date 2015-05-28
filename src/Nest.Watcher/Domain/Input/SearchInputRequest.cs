using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nest.Watcher.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Nest.Resolvers.Converters;

namespace Nest
{

	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<SearchInputRequest>))]
	public interface ISearchInputRequest : INestSerializable
	{
		[JsonProperty("indices")]
		IEnumerable<string> Indices { get; set; }

		[JsonProperty("types")]
		IEnumerable<string> Types { get; set; }

		[JsonProperty("search_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		SearchType? SearchType { get; set; }

		[JsonProperty("indices_options")]
		IIndicesOptions IndicesOptions { get; set; }

		[JsonProperty("body")]
		[JsonConverter(typeof(ReadAsTypeConverter<SearchRequest>))]
		ISearchRequest Body { get; set; }

		[JsonProperty("template")]
		[JsonConverter(typeof(ReadAsTypeConverter<SearchTemplateRequest>))]
		ISearchTemplateRequest Template { get; set; }
	}

	public class SearchInputRequest : ISearchInputRequest
	{
		public IEnumerable<string> Indices { get; set; }

		public IEnumerable<string> Types { get; set; }

		public SearchType? SearchType { get; set; }

		public IIndicesOptions IndicesOptions { get; set; }

		public ISearchRequest Body { get; set; }

		public ISearchTemplateRequest Template { get; set; }
	}

	public class SearchInputRequestDescriptor : ISearchInputRequest
	{
		private ISearchInputRequest Self { get { return this; }}

		IEnumerable<string> ISearchInputRequest.Indices { get; set; }
		IEnumerable<string> ISearchInputRequest.Types { get; set; }
		SearchType? ISearchInputRequest.SearchType { get; set; }
		IIndicesOptions ISearchInputRequest.IndicesOptions { get; set; }
		ISearchRequest ISearchInputRequest.Body { get; set; }
		ISearchTemplateRequest ISearchInputRequest.Template { get; set; }

		public SearchInputRequestDescriptor Indices(IEnumerable<string> indices)
		{
			Self.Indices = indices;
			return this;
		}

		public SearchInputRequestDescriptor Indices(params string[] indices)
		{
			Self.Indices = indices;
			return this;
		}

		public SearchInputRequestDescriptor Types(IEnumerable<string> types)
		{
			Self.Types = types;
			return this;
		}

		public SearchInputRequestDescriptor Types(params string[] types)
		{
			Self.Types = types;
			return this;
		}

		public SearchInputRequestDescriptor SearchType(SearchType? searchType)
		{
			Self.SearchType = searchType;
			return this;
		}

		public SearchInputRequestDescriptor IndicesOptions(Func<IndicesOptionsDescriptor, IIndicesOptions> selector)
		{
			Self.IndicesOptions = selector(new IndicesOptionsDescriptor());
			return this;
		}

		public SearchInputRequestDescriptor Body<T>(Func<SearchDescriptor<T>, SearchDescriptor<T>> selector)
			where T : class
		{
			Self.Body = selector(new SearchDescriptor<T>());
			return this;
		}

		public SearchInputRequestDescriptor Template<T>(Func<SearchTemplateDescriptor<T>, ISearchTemplateRequest> selector)
			where T : class
		{
			Self.Template = selector(new SearchTemplateDescriptor<T>());
			return this;
		}
	}
}
