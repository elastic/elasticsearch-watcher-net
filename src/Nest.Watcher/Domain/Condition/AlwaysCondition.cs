using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{

	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<AlwaysCondition>))]
	public interface IAlwaysCondition : ICondition
	{
	}

	public class AlwaysCondition : ConditionBase, IAlwaysCondition
	{
		internal override void ContainIn(IConditionContainer container)
		{
			container.Always = this;
		}
	}
}
