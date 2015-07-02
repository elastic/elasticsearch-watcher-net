using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest.Watcher.Tests.Integration.Execute
{
	[TestFixture]
	public class MinimalBody : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var watchId = PutWatch();
			var executeWatch = this.Client.ExecuteWatch(watchId);
			Assert(executeWatch, watchId);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var watchId = PutWatch();
			var executeWatch = this.Client.ExecuteWatch(new ExecuteWatchRequest(watchId));
			Assert(executeWatch, watchId);
		}

		protected override string PutWatch()
		{
			var watchId = CreateUniqueWatchId();
			var putWatch = this.Client.PutWatch(watchId, p => p
				.Trigger(t => t
					.Schedule(schd => schd
						.Cron("0 0 0 1 * ? 2099")
					)
				)
				.Input(i => i
					.Simple(smp => smp
						.Add("count", 1)
					)
				)
				.Condition(c => c
					.Script(scrpt => scrpt
						.Inline("ctx.payload.count == 1")
					)
				)
				.Actions(a => a
					.Add("logging", new LoggingAction
					{
						Text = "foobar"
					})
				)
			);
			putWatch.IsValid.Should().BeTrue();
			return watchId;
		}

		protected virtual void Assert(IExecuteWatchResponse response, string watchId)
		{
			response.IsValid.Should().BeTrue();
			response.WatchRecord.Should().NotBeNull();
			response.WatchRecord.WatchId.Should().Be(watchId);
			response.WatchRecord.Result.Should().NotBeNull();
			response.WatchRecord.Result.Input.Should().NotBeNull();
			response.WatchRecord.Result.Input.Status.Should().Be(Status.Success);
			response.WatchRecord.Result.Input.Should().NotBeNull();
			response.WatchRecord.Result.Input.Payload.Should().NotBeNull();
			response.WatchRecord.Result.Input.Payload.Should().NotBeEmpty().And.ContainKey("count");
			Convert.ToInt32(response.WatchRecord.Result.Input.Payload["count"]).Should().Be(1);
			response.WatchRecord.Result.Condition.Should().NotBeNull();
			response.WatchRecord.Result.Condition.Status.Should().Be(Status.Success);
			response.WatchRecord.Result.Condition.Met.Should().BeTrue();
			response.WatchRecord.Result.Actions.Should().NotBeEmpty().And.HaveCount(1);
			var loggingAction = response.WatchRecord.Result.Actions.Where(a => a.Id == "logging").FirstOrDefault();
			loggingAction.Should().NotBeNull();
			loggingAction.Type.Should().Be(ActionType.Logging);
			loggingAction.Status.Should().Be(Status.Success);
			loggingAction.Logging.LoggedText.Should().Be("foobar");
		}
	}
}
