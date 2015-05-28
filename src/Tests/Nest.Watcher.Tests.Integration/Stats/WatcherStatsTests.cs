using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Stats
{
	[TestFixture]
	public class WatcherStatsTests : IntegrationTests
	{
		[Test]
		public void WatcherStats_Basic_Fluent()
		{
			var response = this.Client.WatcherStats();
			AssertBasic(response);
		}

		[Test]
		public void WatcherStats_Basic_OIS()
		{
			var response = this.Client.WatcherStats(new WatcherStatsRequest());
			AssertBasic(response);
		}

		private void AssertBasic(IWatcherStatsResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.WatcherState.Should().Be("started");
			response.ExecutionQueue.Should().NotBeNull();
		}
	}
}
