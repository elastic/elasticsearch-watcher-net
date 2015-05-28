using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<MonthlySchedule>))]
	public interface IMonthlySchedule : ISchedule
	{
		[JsonProperty("on")]
		int On { get; set; }

		[JsonProperty("at")]
		IEnumerable<string> At { get; set; }
	}

	public class MonthlySchedule : ScheduleBase, IMonthlySchedule
	{
		public int On { get; set; }

		public IEnumerable<string> At { get; set; }

		internal override void ContainIn(IScheduleContainer container)
		{
			container.Monthly = this;
		}
	}

	public class MonthlyScheduleDescriptor : IMonthlySchedule
	{

		private IMonthlySchedule Self { get { return this; } }

		public MonthlyScheduleDescriptor On(int on)
		{
			Self.On = on;
			return this;
		}

		public MonthlyScheduleDescriptor At(IEnumerable<string> times)
		{
			Self.At = times;
			return this;
		}

		public MonthlyScheduleDescriptor At(params string[] times)
		{
			Self.At = times;
			return this;
		}

		int IMonthlySchedule.On { get; set; }

		IEnumerable<string> IMonthlySchedule.At { get; set; }
	}
}
