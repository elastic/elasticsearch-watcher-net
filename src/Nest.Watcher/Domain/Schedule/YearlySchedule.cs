using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<YearlySchedule>))]
	public interface IYearlySchedule : ISchedule
	{
		[JsonProperty("in")]
		Month In { get; set; }

		[JsonProperty("on")]
		int On { get; set; }

		[JsonProperty("at")]
		string At { get; set; }
	}

	public class YearlySchedule : ScheduleBase, IYearlySchedule
	{
		public Month In { get; set; }

		public int On { get; set; }

		public string At { get; set; }

		internal override void ContainIn(IScheduleContainer container)
		{
			container.Yearly = this;
		}
	}

	public class YearlyScheduleDescriptor : IYearlySchedule
	{
		private IYearlySchedule Self { get { return this; } }

		public YearlyScheduleDescriptor In(Month month)
		{
			Self.In = month;
			return this;
		}

		public YearlyScheduleDescriptor On(int day)
		{
			Self.On = day;
			return this;
		}

		public YearlyScheduleDescriptor At(string time)
		{
			Self.At = time;
			return this;
		}

		Month IYearlySchedule.In { get; set; }
		int IYearlySchedule.On { get; set; }
		string IYearlySchedule.At { get; set; }
	}
}
