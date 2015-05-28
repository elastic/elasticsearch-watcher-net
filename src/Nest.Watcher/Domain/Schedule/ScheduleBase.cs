using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface ISchedule : INestSerializable
	{
	}

	public abstract class ScheduleBase 
	{
		public static implicit operator ScheduleContainer(ScheduleBase schedule)
		{
			if (schedule == null) return null;
			var c = new ScheduleContainer();
			schedule.ContainIn(c);
			return c;
		}

		internal abstract void ContainIn(IScheduleContainer container);

	}
}
