using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<TimeOfDay>))]
	public interface ITimeOfDay
	{
		[JsonProperty("hour")]
		IEnumerable<int> Hours { get; set; }
		[JsonProperty("minute")]
		IEnumerable<int> Minutes { get; set; }
	}

	public class TimeOfDay : ITimeOfDay
	{
		public IEnumerable<int> Hours { get; set; }
		public IEnumerable<int> Minutes { get; set; }
	}

	public class TimeOfDayDescriptor : ITimeOfDay
	{
		private ITimeOfDay Self { get { return this; } }
		IEnumerable<int> ITimeOfDay.Hours { get; set; }
		IEnumerable<int> ITimeOfDay.Minutes { get; set; }

		public TimeOfDayDescriptor Hours(IEnumerable<int> hours)
		{
			Self.Hours = hours;
			return this;
		}

		public TimeOfDayDescriptor Hours(params int[] hours)
		{
			Self.Hours = hours;
			return this;
		}

		public TimeOfDayDescriptor Minutes(IEnumerable<int> minutes)
		{
			Self.Minutes = minutes;
			return this;
		}

		public TimeOfDayDescriptor Minutes(params int[] minutes)
		{
			Self.Minutes = minutes;
			return this;
		}
	}

	[JsonObject]
	public interface IDailySchedule : ISchedule
	{
		[JsonProperty("at")]
		ITimeOfDay At { get; set; }
	}

	public class DailySchedule : ScheduleBase, IDailySchedule
	{
		public ITimeOfDay At { get; set; }

		internal override void ContainIn(IScheduleContainer container)
		{
			container.Daily = this;
		}
	}

	public class DailyScheduleDescriptor : IDailySchedule
	{
		private IDailySchedule Self { get { return this; } }

		public DailyScheduleDescriptor At(Func<TimeOfDayDescriptor, ITimeOfDay> selector)
		{
			Self.At = selector(new TimeOfDayDescriptor());
			return this;
		}

		ITimeOfDay IDailySchedule.At { get; set; }
	}
}
