using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using FluentAssertions;
using NUnit.Framework;

namespace Nest.Watcher.Tests.Unit.Put
{
	[TestFixture]
	public class PathConditionsJsonTests : UnitTest
	{
		private readonly string _ctx = "ctx.payload.hits.total";

		[Test]
		public void Never()
		{
			var expectedRequest = new
			{
				condition = new { never = new { } }
			};
			var response = this.Client.PutWatch("some-watch", p => p
				.Condition(c=>c.Never())
			);
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void Always()
		{
			var expectedRequest = new
			{
				condition = new { always = new { } }
			};
			var response = this.Client.PutWatch("some-watch", p => p
				.Condition(c=>c.Always())
			);
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void Script()
		{
			var expectedRequest = new
			{
				condition = new { script = new { inline = "x" } }
			};
			var response = this.Client.PutWatch("some-watch", p => p
				.Condition(c=>c
					.Script(s=>s
						.Inline("x")
					)
				)
			);
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void CompareEqualTo()
		{
			var expectedRequest = new {
				condition = new { compare = new Dictionary<string, object>
				{
					{ _ctx, new { eq = 5 }}
				}}
			};
			var response = this.Client.PutWatch("some-watch", p => p .Condition(c=>c .EqualTo(_ctx, 5)));
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void CompareNotEqualTo()
		{
			var expectedRequest = new {
				condition = new { compare = new Dictionary<string, object>
				{
					{ _ctx, new { not_eq = 5 }}
				}}
			};
			var response = this.Client.PutWatch("some-watch", p => p .Condition(c=>c .NotEqualTo(_ctx, 5)));
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void CompareGreaterThan()
		{
			var expectedRequest = new {
				condition = new { compare = new Dictionary<string, object>
				{
					{ _ctx, new { gt = 5 }}
				}}
			};
			var response = this.Client.PutWatch("some-watch", p => p .Condition(c=>c.GreaterThan(_ctx, 5)));
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void CompareGreaterThanOrEqualTo()
		{
			var expectedRequest = new {
				condition = new { compare = new Dictionary<string, object>
				{
					{ _ctx, new { gte = 5 }}
				}}
			};
			var response = this.Client.PutWatch("some-watch", p => p.Condition(c=>c.GreaterThanOrEqualTo(_ctx, 5)));
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void CompareLowerThan()
		{
			var expectedRequest = new {
				condition = new { compare = new Dictionary<string, object>
				{
					{ _ctx, new { lt = 5 }}
				}}
			};
			var response = this.Client.PutWatch("some-watch", p => p.Condition(c=>c.LowerThan(_ctx, 5)));
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void CompareLowerThanOrEqualTo()
		{
			var expectedRequest = new {
				condition = new { compare = new Dictionary<string, object>
				{
					{ _ctx, new { lte = 5 }}
				}}
			};
			var response = this.Client.PutWatch("some-watch", p => p .Condition(c=>c .LowerThanOrEqualTo(_ctx, 5)));
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void CanDeserializeUsingCustomCompareConverter()
		{
			var expectedRequest = new {
				condition = new { compare = new Dictionary<string, object>
				{
					{ _ctx, new { lte = 5 }}
				}}
			};
			var asBytes = this.Client.Serializer.Serialize(expectedRequest);
			var asTyped = this.Client.Serializer.Deserialize<PutWatchRequest>(new MemoryStream(asBytes));

			asTyped.Should().NotBeNull();
			asTyped.Condition.Should().NotBeNull();
			IConditionContainer c = asTyped.Condition;
			c.Compare.Should().NotBeNull();
			c.Compare.Comparison.Should().Be("lte");
			var value = c.Compare.Value as long?;
			value.Should().HaveValue();
			value.Value.Should().Be(5);
		}

	}
}
