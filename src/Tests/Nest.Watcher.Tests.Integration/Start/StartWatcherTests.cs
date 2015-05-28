using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Elasticsearch.Net;

namespace Nest.Watcher.Tests.Integration.Start
{
	[TestFixture]
	public class StartWatcherTests : IntegrationTests
	{
		[Test]
		public void StartWatcher_Basic_Fluent()
		{
			var startResponse = this.Client.StartWatcher();
			AssertBasic(startResponse);
		}

		[Test]
		public void StartWatcher_Basic_OIS()
		{
			var startResponse = this.Client.StartWatcher(new StartWatcherRequest());
			AssertBasic(startResponse);
		}

		private void AssertBasic(IStartWatcherResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Acknowledged.Should().BeTrue();
		}
	}
}
