using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;

namespace Nest.Watcher.Tests.Integration.Acknowledge
{
	[TestFixture]
	public class IndividualAction : Basic
	{
		[Test]
		public override void Fluent()
		{
			var watchId = PutWatch();
			var health = this.Client.ClusterHealth(h => h.WaitForStatus(WaitForStatus.Yellow));
			var ackResponse = this.Client.AcknowledgeWatch(new AcknowledgeWatchRequest(watchId) { ActionId = "test_index" });
			Assert(ackResponse);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var watchId = PutWatch();
			var health = this.Client.ClusterHealth(h => h.WaitForStatus(WaitForStatus.Yellow));
			var ackResponse = this.Client.AcknowledgeWatch(watchId, ack => ack.ActionId("test_index"));
			Assert(ackResponse);
		}
	}
}
