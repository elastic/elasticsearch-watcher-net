using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Info
{
	[TestFixture]
	public class WatcherInfoTests : IntegrationTests
	{
		[Test]

		public void WatcherInfo_Basic_Fluent()
		{
			var response = this.Client.WatcherInfo();
			AssertBasic(response);
		}

		[Test]
		public void WatcherInfo_Basic_OIS()
		{
			var response = this.Client.WatcherInfo(new WatcherInfoRequest());
			AssertBasic(response);
		}

		private void AssertBasic(IWatcherInfoResponse response)
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
