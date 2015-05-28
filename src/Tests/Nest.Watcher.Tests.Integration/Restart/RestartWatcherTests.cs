using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using Elasticsearch.Net;

namespace Nest.Watcher.Tests.Integration.Restart
{
	[TestFixture]
	public class RestartWatcherTests : IntegrationTests
	{
		[Test]
		public void RestartWatcher_Basic_Fluent()
		{
			var restartResponse = this.Client.RestartWatcher();
			AssertBasic(restartResponse);
		}

		[Test]
		public void RestartWatcher_Basic_OIS()
		{
			var restartResponse = this.Client.RestartWatcher(new RestartWatcherRequest());
			AssertBasic(restartResponse);
		}

		private void AssertBasic(IRestartWatcherResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Acknowledged.Should().BeTrue();
		}
	}
}
