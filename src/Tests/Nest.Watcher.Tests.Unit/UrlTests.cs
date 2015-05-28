using NUnit.Framework;

namespace Nest.Watcher.Tests.Unit
{
	[TestFixture]
	public class UrlTests : UnitTest
	{
		[Test]
		public void PutWatch()
		{
			this.UriEquals("PUT", "/_watcher/watch/watch-id", c=>c.PutWatch("watch-id", p=>p));
		}

		[Test]
		public void Acknowledge()
		{
			this.UriEquals("PUT", "/_watcher/watch/watch-id/_ack", c=>c.AcknowledgeWatch("watch-id"));
		}

		[Test]
		public void DeleteWatch()
		{
			this.UriEquals("DELETE", "/_watcher/watch/watch-id", c=>c.DeleteWatch("watch-id"));
		}

		[Test]
		public void ExecuteWatch()
		{
			this.UriEquals("POST", "/_watcher/watch/watch-id/_execute", c=>c.ExecuteWatch("watch-id", p=>p));
		}

		[Test]
		public void GetWatch()
		{
			this.UriEquals("GET", "/_watcher/watch/watch-id", c=>c.GetWatch("watch-id"));
		}

		[Test]
		public void InfoWatch()
		{
			this.UriEquals("GET", "/_watcher/", c=>c.WatcherInfo());
		}

		[Test]
		public void RestartWatcher()
		{
			this.UriEquals("PUT", "/_watcher/_restart", c=>c.RestartWatcher());
		}

		[Test]
		public void StartWatcher()
		{
			this.UriEquals("PUT", "/_watcher/_start", c=>c.StartWatcher());
		}

		[Test]
		public void StopWatcher()
		{
			this.UriEquals("PUT", "/_watcher/_stop", c=>c.StopWatcher());
		}

		[Test]
		public void WatcherStats()
		{
			this.UriEquals("GET", "/_watcher/stats", c=>c.WatcherStats());
		}

	}
}
