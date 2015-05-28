using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using Elasticsearch.Net.Connection;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Nest.Watcher.Tests.Unit
{
	public abstract class UnitTest
	{
		public IElasticClient Client { get; private set; }

		public UnitTest()
		{
			var uri = new Uri("http://localhost:9200");
			var settings = new ConnectionSettings(uri);
			var connection = new InMemoryConnection(settings);
			var client = new ElasticClient(settings, connection: connection);
			this.Client = client;
		}

		protected void UriEquals(string method, string pathAndQuery, Func<IElasticClient, IResponse> call)
		{
			var result = call(this.Client);
			var status = result.ConnectionStatus;
			status.RequestMethod.Should().Be(method);
			new Uri(status.RequestUrl).PathAndQuery.Should().Be(pathAndQuery);
		}

		protected void JsonEquals(object expected, IResponse response)
		{
			var expectedString = Encoding.UTF8.GetString(this.Client.Serializer.Serialize(expected));
			var expectedJson = JObject.Parse(expectedString);

			var actualString = Encoding.UTF8.GetString(response.ConnectionStatus.Request);
			var actualJson = JObject.Parse(actualString);
			var matches = JToken.DeepEquals(expectedJson, actualJson);
			if (matches) return;

			var inlineBuilder = new InlineDiffBuilder(new Differ());
			var result = inlineBuilder.BuildDiffModel(expectedString, actualString);
			var diffMessage = result.Lines.Aggregate(new StringBuilder(), (sb, line) =>
			{
				if (line.Type == ChangeType.Inserted)
					sb.Append("+ ");
				else if (line.Type == ChangeType.Deleted)
					sb.Append("- ");
				else
					sb.Append("  ");
				return sb.AppendLine(line.Text);
			});
			var message = string.Format("expected: {0} \r\n\r\n actual: {1}\r\n\r\n diff: {2}",
				expectedString, actualString, diffMessage);
			throw new Exception(message);

		}
	}
}
