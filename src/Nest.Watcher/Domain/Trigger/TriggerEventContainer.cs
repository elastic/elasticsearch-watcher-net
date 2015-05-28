using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonConverter(typeof(ReadAsTypeConverter<TriggerEventContainer>))]
	public interface ITriggerEventContainer : INestSerializable
	{
		[JsonProperty("schedule")]
		IScheduleTriggerEvent Schedule { get; set; }
	}

	[JsonObject]
	public class TriggerEventContainer : ITriggerEventContainer
	{
		public TriggerEventContainer()
		{
		}

		public TriggerEventContainer(TriggerEventBase trigger)
		{
			trigger.ContainIn(this);
		}

		IScheduleTriggerEvent ITriggerEventContainer.Schedule { get; set; }
	}

	public class TriggerEventDescriptor : TriggerEventContainer
	{
		private ITriggerEventContainer Self { get { return this; } }

		public TriggerEventDescriptor Schedule(Func<ScheduleTriggerEventDescriptor, IScheduleTriggerEvent> selector)
		{
			Self.Schedule = selector(new ScheduleTriggerEventDescriptor());
			return this;
		}

	}
}
