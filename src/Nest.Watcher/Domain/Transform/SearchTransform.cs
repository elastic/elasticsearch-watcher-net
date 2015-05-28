using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using Nest.Resolvers.Converters;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<SearchTransform>))]
	public interface ISearchTransform : ITransform
	{
		[JsonProperty("search_type")]
		SearchType? SearchType { get; set; }
		[JsonProperty("indices")]
		IEnumerable<string> Indices { get; set; }
		[JsonProperty("indices_options")]
		IIndicesOptions IndicesOptions { get; set; }
		[JsonProperty("type")]
		IEnumerable<TypeNameMarker> Type { get; set; }
		[JsonProperty("body")]
		ISearchRequest Body { get; set; }
		[JsonProperty("template")]
		ISearchTemplateRequest Template { get; set; }
	}

	public class SearchTransform : TransformBase, ISearchTransform
	{
		public SearchType? SearchType { get; set; }
		public IEnumerable<string> Indices { get; set; }
		public IIndicesOptions IndicesOptions { get; set; }
		public IEnumerable<TypeNameMarker> Type { get; set; }
		public ISearchRequest Body { get; set; }
		public ISearchTemplateRequest Template { get; set; }

		internal override void ContainIn(ITransformContainer container)
		{
			container.Search = this;
		}
	}

	public class SearchTransformDescriptor : ISearchTransform
	{
		private ISearchTransform Self { get { return this; } }

		public SearchTransformDescriptor SearchType(SearchType searchType)
		{
			Self.SearchType = searchType;
			return this;
		}

		public SearchTransformDescriptor Indices(IEnumerable<string> indices)
		{
			Self.Indices = indices;
			return this;
		}

		public SearchTransformDescriptor Indices(params string[] indices)
		{
			Self.Indices = indices;
			return this;
		}

		public SearchTransformDescriptor IndicesOptions(Func<IndicesOptionsDescriptor, IIndicesOptions> selector)
		{
			Self.IndicesOptions = selector(new IndicesOptionsDescriptor());
			return this;
		}

		public SearchTransformDescriptor Type(IEnumerable<string> type)
		{
			Self.Type = type.Select(t => (TypeNameMarker)t);
			return this;
		}

		public SearchTransformDescriptor Type(params string[] type)
		{
			Self.Type = type.Select(t => (TypeNameMarker)t);
			return this;
		}

		public SearchTransformDescriptor Type<T>()
		{
			Self.Type = new List<TypeNameMarker> { new TypeNameMarker { Type = typeof(T) } };
			return this;
		}

		public SearchTransformDescriptor Body<T>(Func<SearchDescriptor<T>, SearchDescriptor<T>> selector)
			where T : class
		{
			Self.Body = selector(new SearchDescriptor<T>());
			return this;
		}

		public SearchTransformDescriptor Template<T>(Func<SearchTemplateDescriptor<T>, SearchTemplateDescriptor<T>> selector)
			where T : class
		{
			Self.Template = selector(new SearchTemplateDescriptor<T>());
			return this;
		}

		SearchType? ISearchTransform.SearchType { get; set; }
		IEnumerable<string> ISearchTransform.Indices { get; set; }
		IIndicesOptions ISearchTransform.IndicesOptions { get; set; }
		IEnumerable<TypeNameMarker> ISearchTransform.Type { get; set; }
		ISearchRequest ISearchTransform.Body { get; set; }
		ISearchTemplateRequest ISearchTransform.Template { get; set; }
	}
}
