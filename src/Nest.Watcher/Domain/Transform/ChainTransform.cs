using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<ChainTransform>))]
	public interface IChainTransform : ITransform
	{
		IEnumerable<TransformContainer> Transforms { get; set; }
	}

	public class ChainTransform : TransformBase, IChainTransform
	{
		public IEnumerable<TransformContainer> Transforms { get; set; }

		internal override void ContainIn(ITransformContainer container)
		{
			container.Chain = this;
		}
	}
}
