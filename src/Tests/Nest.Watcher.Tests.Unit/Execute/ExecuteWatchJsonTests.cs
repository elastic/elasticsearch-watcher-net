using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Nest.Watcher.Tests.Unit.Execute
{
	[TestFixture]
	public class ExecuteWatchJsonTests : UnitTest
	{

		[Test]
		public void SimulatedAll()
		{
			var expectedRequest = new { simulated_actions = "_all" };

			var result = this.Client.ExecuteWatch(new ExecuteWatchRequest("my_watch")
			{
				SimulatedActions = SimulatedActions.All
			});

			this.JsonEquals(expectedRequest, result);
		}

		[Test]
		public void SimulatedSome()
		{
			var expectedRequest = new
			{
				simulated_actions = new [] { "action1", "action2" }
			};

			var result = this.Client.ExecuteWatch(new ExecuteWatchRequest("my_watch")
			{
				SimulatedActions = SimulatedActions.Some("action1", "action2")
			});

			this.JsonEquals(expectedRequest, result);
		}

		[Test]
		public void Request()
		{
			var dt = DateTime.UtcNow;

			var expectedRequest = new
			{
				alternative_input = new {someKey = "SomeValue"},
				ignore_condition = false,
				ignore_throttle = true,
				record_execution = false,
				action_modes = new
				{
					_all = "force_simulate"
				},
				simulated_actions = new [] { "action1", "action2" },
				trigger_event = new
				{
					schedule = new
					{
						scheduled_time = dt,
						triggered_time = dt
					}
				}
			};

			var result = this.Client.ExecuteWatch(new ExecuteWatchRequest("my_watch")
			{
				AlternativeInput = new Dictionary<string, object> {{ "someKey", "SomeValue"}},
				IgnoreCondition = false,
				IgnoreThrottle = true,
				RecordExecution = false,
				TriggerEvent = new ScheduleTriggerEvent
				{
					ScheduledTime = dt,
					TriggeredTime = dt,
				},
				ActionModes= new Dictionary<string, ActionExecutionMode>
				{
					{"_all", ActionExecutionMode.ForceSimulate}
				},
				SimulatedActions = SimulatedActions.Some("action1", "action2")
			});


			this.JsonEquals(expectedRequest, result);
		}

		[Test]
		public void RequestFluent()
		{
			var dt = DateTime.UtcNow;

			var result = this.Client.ExecuteWatch("my_watch", e=>e
				.AlternativeInput(a=>a.Add("someKey", "SomeValue"))
				.IgnoreCondition(false)
				.IgnoreThrottle()
				.RecordExecution(false)
				.TriggerEvent(te=>te
					.Schedule(s=>s
						.ScheduledTime(dt)
						.TriggeredTime(dt)
					)
				)
				.ActionModes(a=>a.Add("_all", ActionExecutionMode.ForceSimulate))
				.SimulatedActions(SimulatedActions.Some("action1", "action2"))
			);

			var expectedRequest = new
			{
				alternative_input = new {someKey = "SomeValue"},
				ignore_condition = false,
				ignore_throttle = true,
				record_execution = false,
				action_modes = new
				{
					_all = "force_simulate"
				},
				simulated_actions = new [] { "action1", "action2" },
				trigger_event = new
				{
					schedule = new
					{
						scheduled_time = dt,
						triggered_time = dt
					}
				}
			};

			this.JsonEquals(expectedRequest, result);
		}

	}
}
