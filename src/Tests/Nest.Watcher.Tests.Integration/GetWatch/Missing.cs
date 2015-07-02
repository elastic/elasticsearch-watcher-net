using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Get
{
	[TestFixture]
	public class Missing : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var id = "missing_watch";
			var response = this.Client.GetWatch(id);
			Assert(response, id);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var id = "missing_watch";
			var response = this.Client.GetWatch(new GetWatchRequest(id));
			Assert(response, id);
		}

		protected virtual void Assert(IGetWatchResponse response, string expectedId)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(404);
			response.Found.Should().BeFalse();
			response.Watch.Should().BeNull();
			response.Id.Should().Be(expectedId);
		}
	}
}
