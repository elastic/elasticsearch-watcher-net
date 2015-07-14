using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Delete
{
	public class Basic : IntegrationTest
	{
		[Test]
		public override void Fluent()
		{
			var id = PutWatch();
			var response = this.Client.DeleteWatch(id);
			Assert(response, id);
		}

		[Test]
		public override void ObjectInitializer()
		{
			var id = PutWatch();
			var response = this.Client.DeleteWatch(new DeleteWatchRequest(id));
			Assert(response, id);
		}

		protected virtual void Assert(IDeleteWatchResponse response, string expectedId)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Found.Should().BeTrue();
			response.Id.Should().Be(expectedId);
			response.Version.Should().Be(2);
		}
	}
}
