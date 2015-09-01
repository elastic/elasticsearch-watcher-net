using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest.Watcher.Tests.Integration.Execute
{
	[TestFixture]
	public class InlineWatch : IntegrationTest
	{
		private readonly DateTime _scheduledTime = new DateTime(2015, 05, 05, 20, 58, 2);

		[Test]
		public override void Fluent()
		{

			var executeWatch = this.Client.ExecuteWatch(e => e
				.TriggerData(t => t
					.ScheduledTime(_scheduledTime)
					.TriggeredTime(_scheduledTime)
				)
				.AlternativeInput(ai => ai
					.Add("foo", "bar")
				)
				.IgnoreCondition()
				.Watch(w => w
					.Trigger(tr => tr
						.Schedule(tschd => tschd
							.Cron("0 0 0 1 * ? 2099")
						)
					)
					.Input(i => i
						.Search(s => s
							.Request(r => r
								.Body<object>(b => b
									.Query(q => q
										.Filtered(fq => fq
											.Query(qq => qq
												.Match(m => m
													.OnField("response")
													.Query("404")
												)
											)
											.Filter(f => f
												.Range(rf => rf
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
						.Script(sc => sc
							.Inline("ctx.payload.hits.total > 1")
						)
					)
					.Actions(aas => aas
						.Add("email_admin", new EmailAction
						{
							To = new [] {"someone@domain.host.com"},
							Subject = "404 recently encountered"
						})
					)
				)
			);

			Assert(executeWatch);
		}
		
		[Test]
		public override void ObjectInitializer()
		{
			var executeWatch = this.Client.ExecuteWatch(new ExecuteWatchRequest
				{
					TriggerData = new ScheduleTriggerEvent
					{
						ScheduledTime = _scheduledTime,
						TriggeredTime = _scheduledTime
					},
					AlternativeInput = new Dictionary<string, object> { { "foo", "bar" } },
					IgnoreCondition = true,
					Watch = new PutWatchRequest
					{
						Trigger = new TriggerContainer(new ScheduleContainer { Cron = "0 0 0 1 * ? 2099" }),
						Input = new SearchInput
						{
							Request = new SearchInputRequest
							{
								Body = new SearchRequest
								{
									Query = new QueryContainer(new FilteredQuery
									{
										Query = new QueryContainer(new MatchQuery
										{
											Field = "response",
											Query = "404"
										}),
										Filter = new FilterContainer(new RangeFilter 
										{ 
											Field = "@timestamp",
											GreaterThanOrEqualTo = "{{ctx.trigger.scheduled_time}}||-5m",
											LowerThanOrEqualTo = "{{ctx.trigger.triggered_time}}"
										})
									})
								}
							}
						},
						Condition = new ConditionContainer(new ScriptCondition
						{
							Inline = "ctx.payload.hits.total > 1"
						}),
						Actions = new Dictionary<string, IAction>
						{
							{ "email_admin", new EmailAction {
								From = "nest-client@domain.example",
								To = new [] {"someone@domain.host.example"},
								Subject = "404 recently encountered"
							}}
						}
					}
				}
			);
			Assert(executeWatch);
		}

		protected virtual void Assert(IExecuteWatchResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.WatchRecord.TriggerEvent.Should().NotBeNull();
			response.WatchRecord.TriggerEvent.TriggeredTime.Should().Be(_scheduledTime);
			response.WatchRecord.TriggerEvent.Manual.Should().NotBeNull();
			response.WatchRecord.TriggerEvent.Manual.Schedule.Should().NotBeNull();
			response.WatchRecord.TriggerEvent.Manual.Schedule.ScheduledTime.Should().Be(_scheduledTime);

			response.WatchRecord.Result.Input.Type.Should().Be(InputType.Simple);
			response.WatchRecord.Result.Input.Payload.Should().NotBeEmpty();
			response.WatchRecord.Result.Input.Payload["foo"].As<string>().Should().Be("bar");
			response.WatchRecord.Result.Condition.Met.Should().BeTrue();
			response.WatchRecord.Result.Actions.Should().NotBeEmpty();

			var emailAction = response.WatchRecord.Result.Actions.FirstOrDefault(a => a.Id == "email_admin");
			emailAction.Should().NotBeNull();
		}
	}
}
