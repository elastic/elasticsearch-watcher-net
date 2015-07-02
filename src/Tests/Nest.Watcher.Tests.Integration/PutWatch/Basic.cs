using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Put
{
	[TestFixture]
	public class Basic : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var watchId = CreateUniqueWatchId();
			var response = this.Client.PutWatch(watchId, p => p
				.Trigger(t => t
					.Schedule(s => s
						.Hourly(h => h
							.Minute(0, 15)
						)
					)
				)
				.Input(i => i
					.Search(si => si
						.Request(r => r
							.Body<object>(b => b
								.MatchAll()
							)
						)
					)
				)
				.Condition(c => c.Always())	
				.Actions(a => a
					.Add("test_index", new IndexAction { Index = "test", DocType = "test2" })
				)
			);

			Assert(response, watchId);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var watchId = CreateUniqueWatchId();
			var response = this.Client.PutWatch(new PutWatchRequest(watchId)
				{
					Trigger = new TriggerContainer
					{
						Schedule = new ScheduleContainer(
							new HourlySchedule
							{
								Minute = new int[] { 0, 15 }
							}
						)
					},
					Input = new SearchInput
					{
						Request = new SearchInputRequest
						{
							Body = new SearchRequest { Query = new QueryContainer(new MatchAllQuery()) }
						}
					},
					Condition = new AlwaysCondition(),
					Actions = new Dictionary<string, IAction>
					{
						{ "test_index", new IndexAction { Index = "test", DocType = "test2" } }
					}
				});

			Assert(response, watchId);
		}

		protected virtual void Assert(IPutWatchResponse response, string expectedId)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(201);
			response.Version.Should().Be(1);
			response.Created.Should().BeTrue();
			response.Id.Should().Be(expectedId);
			response.Version.Should().Be(1);
		}
	}
}
