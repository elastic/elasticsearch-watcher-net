using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using NUnit.Framework;

using j = System.Collections.Generic.Dictionary<string, object>;

namespace Nest.Watcher.Tests.Unit.Put
{
	[TestFixture]
	public class PutWatchJsonTests : UnitTest
	{
		[Test]
		public void PutWatch()
		{
			//input, conditions, actions tested seperately
			var expectedRequest = new
			{
				metadata = new { x = "y" },
				trigger = new
				{
					schedule = new
					{
						hourly = new { minute = new[] { 10, 20 } }
					}
				},
				throttle_period = "1m",
				transform = new
				{
					chain = new
					{
						transforms = new[] {
							new j { { "search", new { body = new { size = 12 }} }},
							new j { { "script", new { inline =  "x"} }},
						}
					}
				}
			};
			var response = this.Client.PutWatch(new PutWatchRequest("watch-id")
			{
				ThrottlePeriod = "1m",
				Transform = new TransformContainer(new ChainTransform
				{
					Transforms = new List<TransformContainer>
					{
						new SearchTransform
						{
							Body = new SearchRequest { Size = 12}
						},
						new ScriptTransform { Inline = "x" }
					}
				}),
				Metadata = new Dictionary<string, object>
				{
					{"x", "y"}
				},
				Trigger = new TriggerContainer(new HourlySchedule { Minute = new[] { 10, 20 } })
			}
			);
			this.JsonEquals(expectedRequest, response);
		}

	}
}
