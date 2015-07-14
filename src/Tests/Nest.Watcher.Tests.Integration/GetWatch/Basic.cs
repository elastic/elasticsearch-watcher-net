using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Get
{
	[TestFixture]
	public class Basic : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var id = PutWatch();
			var response = this.Client.GetWatch(id);
			Assert(response, id);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var id = PutWatch();
			var response = this.Client.GetWatch(new GetWatchRequest(id));
			Assert(response, id);
		}

		protected virtual void Assert(IGetWatchResponse response, string expectedId)
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
	}
}
