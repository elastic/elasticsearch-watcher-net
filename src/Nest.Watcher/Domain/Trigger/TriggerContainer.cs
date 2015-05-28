using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<TriggerContainer>))]
	public interface ITriggerContainer : INestSerializable
	{
		[JsonProperty("schedule")]
		IScheduleContainer Schedule { get; set; }
	}

	[JsonObject]
	public class TriggerContainer : ITriggerContainer
	{
		public TriggerContainer()
		{
		}

		public TriggerContainer(TriggerBase trigger)
		{
			trigger.ContainIn(this);
		}

		public IScheduleContainer Schedule { get; set; }
	}

	public class TriggerDescriptor : TriggerContainer
	{
		private ITriggerContainer Self { get { return this; } }
	
		public TriggerDescriptor Schedule(Func<ScheduleDescriptor, IScheduleContainer> selector)
		{
			Self.Schedule = selector(new ScheduleDescriptor());
			return this;
		}
	}
}
