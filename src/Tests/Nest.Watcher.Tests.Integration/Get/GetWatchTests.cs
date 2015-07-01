using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Get
{
	[TestFixture]
	public class GetWatchTests : IntegrationTests
	{
		[Test]
		public void GetWatch_Basic_Fluent()
		{
			var id = PutWatch();
			var response = this.Client.GetWatch(id);
			AssertBasic(response, id);
		}

		[Test]
		public void GetWatch_Basic_OIS()
		{
			var id = PutWatch();
			var response = this.Client.GetWatch(new GetWatchRequest(id));
			AssertBasic(response, id);
		}

		[Test]
		public void GetWatch_Missing_Fluent()
		{
			var id = "missing_watch";
			var response = this.Client.GetWatch(id);
			AssertMissing(response, id);
		}

		[Test]
		public void GetWatch_Missing_OIS()
		{
			var id = "missing_watch";
			var response = this.Client.GetWatch(new GetWatchRequest(id));
			AssertMissing(response, id);
		}

		private void AssertBasic(IGetWatchResponse response, string expectedId)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Found.Should().BeTrue();
			response.Id.Should().Be(expectedId);
			response.Status.Should().NotBeNull();
			response.Status.Actions.Should().NotBeEmpty();
			var testIndex = response.Status.Actions["test_index"];
			testIndex.Acknowledgement.Should().NotBeNull();
			testIndex.Acknowledgement.Timestamp.Should().NotBeNull();
			testIndex.Acknowledgement.State.Should().Be("awaits_successful_execution");
			response.Watch.Should().NotBeNull();
			response.Watch.Trigger.Should().NotBeNull();
			response.Watch.Trigger.Schedule.Should().NotBeNull();
			response.Watch.Condition.Should().NotBeNull();
			response.Watch.Input.Should().NotBeNull();
			response.Watch.Actions.Should().NotBeEmpty();
			response.Watch.Actions.Count().Should().Be(1);

		}

		private void AssertMissing(IGetWatchResponse response, string expectedId)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(404);
			response.Found.Should().BeFalse();
			response.Watch.Should().BeNull();
			response.Id.Should().Be(expectedId);
		}
	}
}
