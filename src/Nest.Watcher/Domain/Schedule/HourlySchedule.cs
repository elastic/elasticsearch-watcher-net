using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<HourlySchedule>))]
	public interface IHourlySchedule : ISchedule
	{
		[JsonProperty("minute")]
		IEnumerable<int> Minute { get; set; }
	}

	public class HourlySchedule : ScheduleBase, IHourlySchedule
	{
		public IEnumerable<int> Minute { get; set; }

		internal override void ContainIn(IScheduleContainer container)
		{
			container.Hourly = this;
		}

	}

	public class HourlyScheduleDescriptor : IHourlySchedule
	{
		private IHourlySchedule Self { get { return this; } }

		public HourlyScheduleDescriptor Minute(params int[] minutes)
		{
			Self.Minute = minutes;
			return this;
		}

		public HourlyScheduleDescriptor Minute(IEnumerable<int> minutes)
		{
			Self.Minute = minutes;
			return this;
		}

		IEnumerable<int> IHourlySchedule.Minute { get; set; }
	}
}
