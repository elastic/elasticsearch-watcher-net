using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface ICondition : INestSerializable
	{
	}

	public abstract class ConditionBase
	{
		public static implicit operator ConditionContainer(ConditionBase condition)
		{
			if (condition == null) return null;
			var c = new ConditionContainer();
			condition.ContainIn(c);
			return c;
		}

		internal abstract void ContainIn(IConditionContainer container);
	}
}
