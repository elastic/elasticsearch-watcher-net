using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Nest.Resolvers.Converters;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<IndicesOptions>))]
	public interface IIndicesOptions : INestSerializable
	{
		[JsonProperty("expand_wildcards")]
		[JsonConverter(typeof(StringEnumConverter))]
		ExpandWildcards? ExpandWildcards { get; set; }

		[JsonProperty("ignore_unavailable")]
		bool? IgnoreUnavailable { get; set; }

		[JsonProperty("allow_no_indices")]
		bool? AllowNoIndices { get; set; }
	}

	[JsonObject]
	public class IndicesOptions
	{
		public ExpandWildcards? ExpandWildcards { get; set; }

		public bool? IgnoreUnavailable { get; set; }

		public bool? AllowNoIndices { get; set; }
	}

	public class IndicesOptionsDescriptor : IIndicesOptions
	{
		private IIndicesOptions Self { get { return this; }}

		ExpandWildcards? IIndicesOptions.ExpandWildcards { get; set; }
		bool? IIndicesOptions.IgnoreUnavailable { get; set; }
		bool? IIndicesOptions.AllowNoIndices { get; set; }
		
		public IndicesOptionsDescriptor ExpandWildcards(ExpandWildcards? expandWildcards)
		{
			Self.ExpandWildcards = expandWildcards;
			return this;
		}

		public IndicesOptionsDescriptor IgnoreUnavailable(bool ignoreUnavailable = true)
		{
			Self.IgnoreUnavailable = ignoreUnavailable;
			return this;
		}

		public IndicesOptionsDescriptor AllowNoIndices(bool allowNoIndices = true)
		{
			Self.AllowNoIndices = allowNoIndices;
			return this;
		}
	}
}
