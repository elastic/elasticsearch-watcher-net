using System;
using Newtonsoft.Json;
using Nest.Resolvers.Converters;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<ScheduleTriggerEvent>))]
	public interface IScheduleTriggerEvent : INestSerializable, ITriggerEvent
	{
		[JsonProperty("triggered_time")]
		DateTime? TriggeredTime { get; set; }

		[JsonProperty("scheduled_time")]
		DateTime? ScheduledTime { get; set; }
	}


	public class ScheduleTriggerEvent : TriggerEventBase, IScheduleTriggerEvent
	{
		public DateTime? TriggeredTime { get; set; }

		public DateTime? ScheduledTime { get; set; }

		internal override void ContainIn(ITriggerEventContainer container)
		{
			container.Schedule = this;
		}
	}

	public class ScheduleTriggerEventDescriptor : IScheduleTriggerEvent
	{
		private IScheduleTriggerEvent Self { get { return this; } }

		DateTime? IScheduleTriggerEvent.TriggeredTime { get; set; }
		DateTime? IScheduleTriggerEvent.ScheduledTime { get; set; }

		public ScheduleTriggerEventDescriptor TriggeredTime(DateTime? triggeredDateTime)
		{
			Self.TriggeredTime = triggeredDateTime;
			return this;
		}

		public ScheduleTriggerEventDescriptor ScheduledTime(DateTime? scheduledTime)
		{
			Self.ScheduledTime = scheduledTime;
			return this;
		}

	}
}