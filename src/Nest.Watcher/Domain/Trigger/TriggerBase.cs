using Nest.Watcher.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface ITrigger
	{
		ISchedule Schedule { get; set; }
	}

	public abstract class TriggerBase
	{
		public static implicit operator TriggerContainer(TriggerBase trigger)
		{
			if (trigger == null) return null;
			var c = new TriggerContainer();
			trigger.ContainIn(c);
			return c;
		}

		internal abstract void ContainIn(ITriggerContainer container);
	}
}
