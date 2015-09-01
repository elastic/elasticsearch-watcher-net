using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Nest.Watcher.Tests.Integration
{
	public abstract class IntegrationTest
	{
		public abstract void Fluent();
		public abstract void ObjectInitializer();

		protected List<string> _watchIds = new List<string>();

		public IElasticClient Client
		{
			get
			{
				var url = Environment.GetEnvironmentVariable("WATCHER_TEST_URI") ?? "http://localhost:9200";
				var uri = new Uri(url);
				var settings = new ConnectionSettings(uri)
					.PrettyJson()
					.ExposeRawResponse();
				var client = new ElasticClient(settings);
				return client;
			}
		}

		[TestFixtureTearDown]
		public void TearDown()
		{
			_watchIds.ForEach(id => this.Client.DeleteWatch(id));
		}

		protected string CreateUniqueWatchId()
		{
			var id = "nest-" + Guid.NewGuid().ToString();
			_watchIds.Add(id);
			return id;
		}

		protected virtual string PutWatch()
		{
			var watchId = CreateUniqueWatchId();
			var response = this.Client.PutWatch(watchId, p => p
				.Metadata(m => m.Add("x", "y"))
				.Trigger(t => t
					.Schedule(s => s
						.Hourly(h => h.Minute(0, 5))
					)
				)
				.Input(i => i
					.Search(s => s
						.Request(r => r
							.Body<object>(b => b
								.MatchAll()
							)
						)
					)
				)
				.Condition(c => c.Always())
				.Actions(a => a
					.Add("test_index", new IndexAction { Index = "test", DocType = "test2" })
					.Add("test_email", new EmailAction { To = new [] { "someone@domain.host.com"}, Subject = "404 recently encountered" })
				)
			);
			response.IsValid.Should().BeTrue();
			response.Id.Should().Be(watchId);
			return watchId;
		}
	}
}
