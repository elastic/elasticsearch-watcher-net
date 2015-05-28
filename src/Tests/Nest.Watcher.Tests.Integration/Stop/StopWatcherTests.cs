using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Elasticsearch.Net;

namespace Nest.Watcher.Tests.Integration.Stop
{
	[TestFixture]
	public class StopWatcherTests : IntegrationTests
	{
		[Test]
		public void StopWatcher_Basic_Fluent()
		{
			var stopResponse = this.Client.StopWatcher();
			AssertBasic(stopResponse);
			var startResponse = this.Client.StartWatcher();
			AssertBasic(startResponse);
		}

		[Test]
		public void StopWatcher_Basic_OIS()
		{
			var stopResponse = this.Client.StopWatcher(new StopWatcherRequest());
			AssertBasic(stopResponse);
			var startResponse = this.Client.StartWatcher(new StartWatcherRequest());
			AssertBasic(startResponse);
		}

		private void AssertBasic(IStopWatcherResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Acknowledged.Should().BeTrue();
		}

		private void AssertBasic(IStartWatcherResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Acknowledged.Should().BeTrue();
		}
	}
}
