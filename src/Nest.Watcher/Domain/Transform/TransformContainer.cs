using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<TransformContainer>))]
	public interface ITransformContainer : INestSerializable
	{
		[JsonProperty("search")]
		ISearchTransform Search { get; set; }

		[JsonProperty("script")]
		IScriptTransform Script { get; set; }

		[JsonProperty("chain")]
		IChainTransform Chain { get; set; }
	}

	[JsonObject]
	public class TransformContainer : ITransformContainer
	{
		public TransformContainer()
		{
		}

		public TransformContainer(TransformBase transform)
		{
			transform.ContainIn(this);
		}

		ISearchTransform ITransformContainer.Search { get; set; }
		IScriptTransform ITransformContainer.Script { get; set; }
		IChainTransform ITransformContainer.Chain { get; set; }
	}

	public class TransformDescriptor : TransformContainer
	{
		private ITransformContainer Self { get { return this; } }

		public TransformDescriptor Search(Func<SearchTransformDescriptor, ISearchTransform> selector)
		{
			Self.Search = selector(new SearchTransformDescriptor());
			return this;
		}

		public TransformDescriptor Script(Func<ScriptTransformDescriptor, IScriptTransform> selector)
		{
			Self.Script = selector(new ScriptTransformDescriptor());
			return this;
		}

		// TODO : Chain is an array of ITransform's
		public TransformDescriptor Chain()
		{
			return this;
		}
	}
}
