using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Elasticsearch.Net;

namespace Nest.Watcher.Tests.Integration.Execute
{
	[TestFixture]
	public class ThrottledActionResponse : IntegrationTest
	{
		private readonly DateTime _triggeredDateTime = new DateTime(2015, 05, 05, 20, 58, 02);

		[Test]
		public override void Fluent()
		{
			var watchId = PutWatch();
			IExecuteWatchResponse executeWatch = null;
			for (var i = 0; i < 2; i++)
			{
				executeWatch = this.Client.ExecuteWatch(watchId, w => w
					.TriggerData(te => te
						.ScheduledTime(_triggeredDateTime)
						.TriggeredTime(_triggeredDateTime)
					)
					.AlternativeInput(x => x.Add("foo", "bar"))
					.IgnoreCondition()
					.RecordExecution(true)
					);
			}

			Assert(executeWatch, watchId);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var watchId = PutWatch();
			IExecuteWatchResponse executeWatch = null;
			for (var i = 0; i < 2; i++)
			{
				executeWatch = this.Client.ExecuteWatch(new ExecuteWatchRequest(watchId)
				{
					TriggerData = new ScheduleTriggerEvent
					{
						ScheduledTime = _triggeredDateTime,
						TriggeredTime = _triggeredDateTime
					},
					AlternativeInput = new Dictionary<string, object>
					{
						{"foo", "bar"}
					},
					IgnoreCondition = true,
					RecordExecution = true,
				});
			}
			Assert(executeWatch, watchId);
		}

		protected virtual void Assert(IExecuteWatchResponse response, string watchId)
		{
			response.WatchRecord.Result.Actions.Should().NotBeNullOrEmpty();
			response.WatchRecord.Result.Actions.Count().Should().Be(1);
			var loggingAction = response.WatchRecord.Result.Actions.Where(a => a.Id == "logging_action").FirstOrDefault();
			loggingAction.Should().NotBeNull();
			loggingAction.Type.Should().Be(ActionType.Logging);
			loggingAction.Status.Should().Be(Status.Throttled);
			loggingAction.Reason.Should().NotBeNullOrEmpty();
		}

		protected override string PutWatch()
		{
			//var health = this.Client.ClusterHealth(h => h.WaitForStatus(WaitForStatus.Green));
			var watchId = CreateUniqueWatchId();
			var putWatch = this.Client.PutWatch(watchId, w => w
				.Trigger(t => t.Schedule(s => s.Cron("0 0 0 1 * ? 2099")))
				.Metadata(meta => meta.Add("foo", "bar"))
				.Input(inp => inp
					.Search(s => s
						.Request(r => r
							.Indices("logstash")
							.Body<object>(b => b
								.Query(q => q
									.Filtered(ff => ff
										.Query(ffq => ffq
											.Match(m => m
												.OnField("response")
												.Query("404")
											)
										)
										.Filter(ffr => ffr
											.Range(ffrr => ffrr
												.OnField("@timestamp")
												.GreaterOrEquals("{{ctx.trigger.scheduled_time}}||-5m")
												.LowerOrEquals("{{ctx.trigger.triggered_time}}")
											)
										)
									)
								)
							)
						)
					)
				)
				.Condition(c => c
					.GreaterThanOrEqualTo("ctx.payload.hits.total", 0)
				)
				.Actions(act => act
					.Add("logging_action", new LoggingAction
					{
						Text = "hello from nest"
					})
				)
			);

			putWatch.Id.Should().Be(watchId);
			return watchId;
		}
	}
}
