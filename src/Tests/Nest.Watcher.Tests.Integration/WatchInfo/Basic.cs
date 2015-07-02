using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Info
{
	[TestFixture]
	public class Basic : IntegrationTest
	{
		[Test]

		public override void Fluent()
		{
			var response = this.Client.WatcherInfo();
			Assert(response);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var response = this.Client.WatcherInfo(new WatcherInfoRequest());
			Assert(response);
		}

		protected virtual void Assert(IWatcherInfoResponse response)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			var version = response.Version;
			version.Should().NotBeNull();
			version.Number.Should().NotBeNullOrEmpty();
			version.BuildHash.Should().NotBeNullOrEmpty();
			version.BuildTimestamp.Should().NotBeNullOrEmpty();
		}
	}
}
