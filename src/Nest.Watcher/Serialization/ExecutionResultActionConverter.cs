using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest.Watcher.Serialization
{
	public class ExecutionResultActionConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			reader.Read();
			reader.Read();
			var action = new ExecutionResultAction { Id = reader.Value as string };
			reader.Read();
			var type = reader.Value as string;
			reader.Read();
			if (reader.TokenType == JsonToken.StartObject)
			{
				var result = JObject.Load(reader);
				switch (type)
				{
					case "email":
						action._Container.Email = result.ToObject<EmailActionResult>();
						break;
					case "index":
						action._Container.Index = result.ToObject<IndexActionResult>();
						break;
					case "webhook":
						action._Container.Webhook = result.ToObject<WebhookActionResult>();
						break;
					case "logging":
						action._Container.Logging = result.ToObject<LoggingActionResult>();
						break;
				}
			}
			reader.Read();
			return action;
		}

		public override bool CanWrite { get { return false; } }
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
