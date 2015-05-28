using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{

	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<WeeklySchedule>))]
	public interface IWeeklySchedule : ISchedule
	{
		[JsonProperty("on")]
		Day On { get; set; }

		[JsonProperty("at")]
		IEnumerable<string> At { get; set; }
	}

	public class WeeklySchedule : ScheduleBase, IWeeklySchedule
	{
		public Day On { get; set; }

		public IEnumerable<string> At { get; set; }

		internal override void ContainIn(IScheduleContainer container)
		{
			container.Weekly = this;
		}
	}

	public class WeeklyScheduleDescriptor : IWeeklySchedule
	{
		private IWeeklySchedule Self { get { return this; } }

		public WeeklyScheduleDescriptor On(Day day)
		{
			Self.On = day;
			return this;
		}

		public WeeklyScheduleDescriptor At(IEnumerable<string> times)
		{
			Self.At = times;
			return this;
		}

		public WeeklyScheduleDescriptor At(params string[] times)
		{
			Self.At = times;
			return this;
		}

		Day IWeeklySchedule.On {get;set;}
		IEnumerable<string> IWeeklySchedule.At { get; set; }
	}
}
