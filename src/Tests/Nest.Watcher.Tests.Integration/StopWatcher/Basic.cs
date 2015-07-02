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
	public class Basic : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var stopResponse = this.Client.StopWatcher();
			Assert(stopResponse);
			var startResponse = this.Client.StartWatcher();
			Assert(startResponse);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var stopResponse = this.Client.StopWatcher(new StopWatcherRequest());
			Assert(stopResponse);
			var startResponse = this.Client.StartWatcher(new StartWatcherRequest());
			Assert(startResponse);
		}

		protected virtual void Assert(IStopWatcherResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Acknowledged.Should().BeTrue();
		}

		protected virtual void Assert(IStartWatcherResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Acknowledged.Should().BeTrue();
		}
	}
}
