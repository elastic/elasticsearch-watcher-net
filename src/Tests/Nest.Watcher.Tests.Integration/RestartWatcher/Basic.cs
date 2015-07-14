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
	public class Basic : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var restartResponse = this.Client.RestartWatcher();
			Assert(restartResponse);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var restartResponse = this.Client.RestartWatcher(new RestartWatcherRequest());
			Assert(restartResponse);
		}

		protected virtual void Assert(IRestartWatcherResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Acknowledged.Should().BeTrue();
		}
	}
}
