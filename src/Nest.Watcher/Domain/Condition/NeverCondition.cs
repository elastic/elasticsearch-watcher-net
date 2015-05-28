using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<NeverCondition>))]
	public interface INeverCondition : ICondition
	{
	}

	public class NeverCondition : ConditionBase, INeverCondition
	{
		internal override void ContainIn(IConditionContainer container)
		{
			container.Never = this;
		}
	}
}
