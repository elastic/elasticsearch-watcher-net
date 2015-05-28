using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace Nest.Watcher.Tests.Integration.Delete
{
	public class DeleteWatchTests : IntegrationTests
	{
		[Test]
		public void DeleteWatch_Basic_Fluent()
		{
			var id = PutWatch();
			var response = this.Client.DeleteWatch(id);
			AssertBasic(response, id);
		}

		[Test]
		public void DeleteWatch_Basic_OIS()
		{
			var id = PutWatch();
			var response = this.Client.DeleteWatch(new DeleteWatchRequest(id));
			AssertBasic(response, id);
		}

		private void AssertBasic(IDeleteWatchResponse response, string expectedId)
		{
			response.IsValid.Should().BeTrue();
			response.ConnectionStatus.HttpStatusCode.Should().Be(200);
			response.Found.Should().BeTrue();
			response.Id.Should().Be(expectedId);
			response.Version.Should().Be(2);
		}
	}
}
