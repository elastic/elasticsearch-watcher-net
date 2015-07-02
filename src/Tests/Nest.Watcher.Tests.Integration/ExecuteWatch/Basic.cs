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
			//var health = this.Client.ClusterHealth(h => h.WaitForStatus(WaitForStatus.Green));
			var watchId = CreateUniqueWatchId();
			var putWatch = this.Client.PutWatch(watchId, w => w
				.Trigger(t=>t.Schedule(s=>s.Cron("0 0 0 1 * ? 2099")))
				.Input(inp=>inp
					.Search(s=>s
						.Request(r=>r
							.Indices("logstash")
							.Body<object>(b=>b
								.Query(q=>q
									.Filtered(ff=>ff
										.Query(ffq=>ffq
											.Match(m=>m
												.OnField("response")
												.Query("404")
											)
										)
										.Filter(ffr=>ffr
											.Range(ffrr=>ffrr
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
				.Condition(c=>c
					.Script(ss=>ss
						.Inline("ctx.payload.hits.total > 1")
					)
				)
				.Actions(act=>act
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
			var date = new DateTime(2015, 05, 05, 20, 58, 02);
			var executeWatch = this.Client.ExecuteWatch(watchId, w => w
				.TriggerEvent(te => te
					.Schedule(tes => tes
						.ScheduledTime(date)
						.TriggeredTime(date)
					)
				)
				.AlternativeInput(i => i.Add("foo", "bar"))
				.IgnoreCondition()
				//Not available in beta
				//.ActionModes(a => a
				//	.Add("_all", ActionExecutionMode.ForceSimulate)
				//)
				.RecordExecution(true)
			);

			executeWatch.IsValid.Should().BeTrue();
			executeWatch.WatchId.Should().Be(watchId);
			executeWatch.State.Should().NotBeNull().And.Be(ActionExecutionState.Executed);
			executeWatch.TriggerEvent.Should().NotBeEmpty().And.ContainKey("manual");
			executeWatch.TriggerEvent["manual"].Schedule.Should().NotBeNull();
			executeWatch.TriggerEvent["manual"].Schedule.ScheduledTime.Should().Be(date);

			executeWatch.ExecutionResult.Should().NotBeNull();
			executeWatch.ExecutionResult.Condition.Should().NotBeNull();
			executeWatch.ExecutionResult.Condition.Met.Should().HaveValue();
			executeWatch.ExecutionResult.Condition.Always.Should().NotBeNull();
			executeWatch.ExecutionResult.Condition.Never.Should().BeNull();
			executeWatch.ExecutionResult.Condition.Script.Should().BeNull();

			executeWatch.ExecutionResult.Actions.Should().NotBeNullOrEmpty();
			executeWatch.ExecutionResult.Actions.Count().Should().Be(3);

			var emailAction = executeWatch.ExecutionResult.Actions.Where(a => a.Id == "email_admin").FirstOrDefault();
			emailAction.Should().NotBeNull();
			emailAction.Email.Should().NotBeNull();
			emailAction.Email.Success.Should().BeFalse();
			if (!emailAction.Email.Success)
				emailAction.Email.Reason.Should().NotBeNullOrEmpty();

			var indexAction = executeWatch.ExecutionResult.Actions.Where(a => a.Id == "index_action").FirstOrDefault();
			indexAction.Should().NotBeNull();
			indexAction.Index.Success.Should().BeTrue();
			indexAction.Index.Response.Should().NotBeNull();
			indexAction.Index.Response.Index.Should().Be("test");
			indexAction.Index.Response.Type.Should().Be("doctype2");
			indexAction.Index.Response.Created.Should().BeTrue();
			indexAction.Index.Response.Version.Should().Be(1);

			var loggingAction = executeWatch.ExecutionResult.Actions.Where(a => a.Id == "logging_action").FirstOrDefault();
			loggingAction.Should().NotBeNull();
			loggingAction.Logging.Success.Should().BeTrue();
			loggingAction.Logging.LoggedText.Should().Be("hello from nest");

			executeWatch.ExecutionResult.ExecutionTime.Should().HaveValue();
		}

		[Test]
		public override void ObjectInitializer()
		{
			throw new NotImplementedException();
		}

		protected virtual void Assert(IExecuteWatchResponse response)
		{

		}
	}
}
