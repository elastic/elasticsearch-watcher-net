using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Elasticsearch.Net;

namespace Nest.Watcher.Tests.Integration.Acknowledge
{
	[TestFixture]
	public class AcknowledgeWatchTests : IntegrationTests
	{
		[Test]
		public void AcknowledgeWatch_Basic_Fluent()
		{
			var watchId = PutWatch();
			var health = this.Client.ClusterHealth(h => h.WaitForStatus(WaitForStatus.Yellow));
			var ackResponse = this.Client.AcknowledgeWatch(watchId);
			AssertBasic(ackResponse);
		}

		[Test]
		public void AcknowledgeWatch_Basic_OIS()
		{
			var watchId = PutWatch();
			var health = this.Client.ClusterHealth(h => h.WaitForStatus(WaitForStatus.Yellow));
			var ackResponse = this.Client.AcknowledgeWatch(new AcknowledgeWatchRequest(watchId));
			AssertBasic(ackResponse);
		}

		private void AssertBasic(IAcknowledgeWatchResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Status.Should().NotBeNull();
			response.Status.AcknowledgementState.State.Should().Be("awaits_execution");
		}
	}
}
