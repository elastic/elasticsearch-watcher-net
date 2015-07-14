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
	public class Basic : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var watchId = PutWatch();
			var date = new DateTime(2015, 05, 05, 20, 58, 02);
			var executeWatch = this.Client.ExecuteWatch(watchId, w => w
				.TriggerData(te => te
					.Schedule(tes => tes
						.ScheduledTime(date)
						.TriggeredTime(date)
					)
				)
				.AlternativeInput(i => i.Add("foo", "bar"))
				.IgnoreCondition()
				.ActionModes(a => a
					.Add("_all", ActionExecutionMode.ForceSimulate)
				)
				.RecordExecution(true)
			);

			Assert(executeWatch, watchId);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var watchId = PutWatch();
			var date = new DateTime(2015, 05, 05, 20, 58, 02);
			var executeWatch = this.Client.ExecuteWatch(new ExecuteWatchRequest(watchId)
				{
					TriggerData = new TriggerEventContainer(new ScheduleTriggerEvent
					{
						ScheduledTime = date,
						TriggeredTime = date
					}),
					AlternativeInput = new Dictionary<string, object>
					{
						{ "foo", "bar" }
					},
					IgnoreCondition = true,
					RecordExecution = true,
					ActionModes = new Dictionary<string, ActionExecutionMode>
					{
						{ "_all" , ActionExecutionMode.ForceSimulate}
					}
				});
			Assert(executeWatch, watchId);
		}

		protected virtual void Assert(IExecuteWatchResponse response, string watchId)
		{
			response.IsValid.Should().BeTrue();
			response.WatchRecord.Should().NotBeNull();
			response.WatchRecord.WatchId.Should().Be(watchId);
			response.WatchRecord.State.Should().NotBeNull().And.Be(ActionExecutionState.Executed);
			response.WatchRecord.TriggerEvent.Should().NotBeNull();
			response.WatchRecord.TriggerEvent.Type.Should().Be("manual");
			response.WatchRecord.TriggerEvent.TriggeredTime.Should().HaveValue();
			response.WatchRecord.TriggerEvent.Manual.Should().NotBeNull();
			response.WatchRecord.TriggerEvent.Manual.Schedule.Should().NotBeNull();
			response.WatchRecord.TriggerEvent.Manual.Schedule.ScheduledTime.Should().HaveValue();

			response.WatchRecord.Result.Should().NotBeNull();
			response.WatchRecord.Result.Condition.Should().NotBeNull();
			response.WatchRecord.Result.Condition.Type.Should().Be(ConditionType.Always);
			response.WatchRecord.Result.Condition.Status.Should().Be(Status.Success);
			response.WatchRecord.Result.Condition.Met.Should().BeTrue();

			response.WatchRecord.Result.Actions.Should().NotBeNullOrEmpty();
			response.WatchRecord.Result.Actions.Count().Should().Be(3);

			var emailAction = response.WatchRecord.Result.Actions.Where(a => a.Id == "email_admin").FirstOrDefault();
			emailAction.Should().NotBeNull();
			emailAction.Type.Should().Be(ActionType.Email);
			emailAction.Reason.Should().NotBeEmpty();
			emailAction.Status.Should().Be(Status.Failure);
			emailAction.Email.Should().BeNull();

			var indexAction = response.WatchRecord.Result.Actions.Where(a => a.Id == "index_action").FirstOrDefault();
			indexAction.Should().NotBeNull();
			indexAction.Type.Should().Be(ActionType.Index);
			indexAction.Status.Should().Be(Status.Success);
			indexAction.Index.Response.Should().NotBeNull();
			indexAction.Index.Response.Index.Should().Be("test");
			indexAction.Index.Response.Type.Should().Be("doctype2");
			indexAction.Index.Response.Created.Should().BeTrue();
			indexAction.Index.Response.Version.Should().Be(1);

			var loggingAction = response.WatchRecord.Result.Actions.Where(a => a.Id == "logging_action").FirstOrDefault();
			loggingAction.Should().NotBeNull();
			loggingAction.Type.Should().Be(ActionType.Logging);
			loggingAction.Status.Should().Be(Status.Success);
			loggingAction.Logging.LoggedText.Should().Be("hello from nest");

			response.WatchRecord.Result.ExecutionTime.Should().HaveValue();
		}

		protected override string PutWatch()
		{
			//var health = this.Client.ClusterHealth(h => h.WaitForStatus(WaitForStatus.Green));
			var watchId = CreateUniqueWatchId();
			var putWatch = this.Client.PutWatch(watchId, w => w
				.Trigger(t => t.Schedule(s => s.Cron("0 0 0 1 * ? 2099")))
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
					.Script(ss => ss
						.Inline("ctx.payload.hits.total > 1")
					)
				)
				.Actions(act => act
					.Add("email_admin", new EmailAction
					{
						To = "someone@domain.host.com",
						Subject = "404 recently encountered"
					})
					.Add("index_action", new IndexAction
					{
						Index = "test",
						DocType = "doctype2"
					})
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
