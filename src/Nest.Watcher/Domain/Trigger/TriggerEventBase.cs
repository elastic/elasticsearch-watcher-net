namespace Nest
{
	public abstract class TriggerEventBase : ITriggerEvent
	{
		public static implicit operator TriggerEventContainer(TriggerEventBase trigger)
		{
			if (trigger == null) return null;
			var c = new TriggerEventContainer();
			trigger.ContainIn(c);
			return c;
		}

		internal abstract void ContainIn(ITriggerEventContainer container);
	}
}