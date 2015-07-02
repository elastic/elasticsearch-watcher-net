using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<ScheduleContainer>))]
	public interface IScheduleContainer : INestSerializable
	{
		[JsonProperty("daily")]
		IDailySchedule Daily { get; set; }

		[JsonProperty("monthly")]
		IMonthlySchedule Monthly { get; set; }

		[JsonProperty("hourly")]
		IHourlySchedule Hourly { get; set; }

		[JsonProperty("weekly")]
		IWeeklySchedule Weekly { get; set; }

		[JsonProperty("yearly")]
		IYearlySchedule Yearly { get; set; }

		[JsonProperty("cron")]
		string Cron { get; set; }
	}

	public class ScheduleContainer : TriggerBase, IScheduleContainer
	{
		public ScheduleContainer()
		{
		}

		public ScheduleContainer(ScheduleBase schedule)
		{
			schedule.ContainIn(this);
		}

		public IDailySchedule Daily { get; set; }
		public IMonthlySchedule Monthly { get; set; }
		public IHourlySchedule Hourly { get; set; }
		public IWeeklySchedule Weekly { get; set; }
		public IYearlySchedule Yearly { get; set; }
		public string Cron { get; set; }

		internal override void ContainIn(ITriggerContainer container)
		{
			container.Schedule = this;
		}
	}

	public class ScheduleDescriptor : ScheduleContainer
	{
		private IScheduleContainer Self { get { return this; } }

		public ScheduleDescriptor Daily(Func<DailyScheduleDescriptor, IDailySchedule> selector)
		{
			this.Self.Daily = selector(new DailyScheduleDescriptor());
			return this;
		}

		public ScheduleDescriptor Hourly(Func<HourlyScheduleDescriptor, IHourlySchedule> selector)
		{
			this.Self.Hourly = selector(new HourlyScheduleDescriptor());
			return this;
		}

		public ScheduleDescriptor Monthly(Func<MonthlyScheduleDescriptor, IMonthlySchedule> selector)
		{
			this.Self.Monthly = selector(new MonthlyScheduleDescriptor());
			return this;
		}

		public ScheduleDescriptor Weekly(Func<WeeklyScheduleDescriptor, IWeeklySchedule> selector)
		{
			this.Self.Weekly = selector(new WeeklyScheduleDescriptor());
			return this;
		}

		public ScheduleDescriptor Yearly(Func<YearlyScheduleDescriptor, IYearlySchedule> selector)
		{
			this.Self.Yearly = selector(new YearlyScheduleDescriptor());
			return this;
		}

		public ScheduleDescriptor Cron(string cron)
		{
			this.Self.Cron = cron;
			return this;
		}
	}
}
