using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Put
{
	[TestFixture]
	public class WithThrottlePeriod : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			this.Client.ClusterHealth(h => h.WaitForStatus(WaitForStatus.Green));
			var watchId = CreateUniqueWatchId();
			var put = this.Client.PutWatch(watchId, p => p
				.ThrottlePeriod("10s")
				.Trigger(t => t
					.Schedule(s => s.Hourly(h => h.Minute(0, 5)))
				)
				.Input(i=>i.Simple(s=>s.Add("payload", new { send = "yes"})))
				.Condition(c=>c.Always())
				.Actions(a=>a.Add("test_index", new IndexAction
				{
					Index = "test",
					DocType = "test2"
				}))
			);

			this.AssertPutWatchResponse(put, watchId);

			var get = this.Client.GetWatch(watchId);
			this.AssertGetWatchResponse(get, watchId);
		}

		[Test]
		public override void ObjectInitializer()
		{
			this.Client.ClusterHealth(h => h.WaitForStatus(WaitForStatus.Green));
			var watchId = CreateUniqueWatchId();
			var put = this.Client.PutWatch(new PutWatchRequest(watchId)
			{
				ThrottlePeriod = "10s",
				Trigger = new TriggerContainer()
				{
					Schedule = new ScheduleContainer(new HourlySchedule {Minute = new[] {0, 5}})
				},
				Input = new SimpleInput(new Dictionary<string, object> { {"payload", new { send = "yes"}} }),
				Actions = new Dictionary<string, IAction>
				{
					{"test_index", new IndexAction {Index = "test", DocType = "test2"}}
				},
				Condition = new AlwaysCondition()
			});
			this.AssertPutWatchResponse(put, watchId);
			var get = this.Client.GetWatch(watchId);
			this.AssertGetWatchResponse(get, watchId);
		}

		private void AssertPutWatchResponse(IPutWatchResponse response, string watchId)
		{
			response.IsValid.Should().Be(true);
			response.ConnectionStatus.HttpStatusCode.Should().Be(201);
			response.Version.Should().Be(1);
			response.Id.Should().NotBeNullOrWhiteSpace().And.Be(watchId);
		}

		private void AssertGetWatchResponse(IGetWatchResponse response, string watchId)
		{
			response.IsValid.Should().Be(true);
			response.Found.Should().Be(true);
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Id.Should().NotBeNullOrWhiteSpace().And.Be(watchId);
			response.Watch.ThrottlePeriod.Should().Be("10s");
		}
	}
}
