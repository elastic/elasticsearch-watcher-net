using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Stats
{
	[TestFixture]
	public class Basic : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var response = this.Client.WatcherStats();
			Assert(response);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var response = this.Client.WatcherStats(new WatcherStatsRequest());
			Assert(response);
		}

		protected virtual void Assert(IWatcherStatsResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.WatcherState.Should().Be("started");
			response.ExecutionThreadPool.Should().NotBeNull();
			response.CurrentWatches.Should().NotBeNull();
			response.QueuedWatches.Should().NotBeNull();
		}
	}
}
