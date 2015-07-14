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
	public class Basic : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var startResponse = this.Client.StartWatcher();
			Assert(startResponse);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var startResponse = this.Client.StartWatcher(new StartWatcherRequest());
			Assert(startResponse);
		}

		protected virtual void Assert(IStartWatcherResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Acknowledged.Should().BeTrue();
		}
	}
}
