using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest.Watcher.Serialization
{
	public class ActionDictionaryConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override bool CanRead { get { return true; } }
		
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var dictionary = new Dictionary<string, IAction>();
			var actions = JObject.Load(reader);
			foreach(var child in actions.Children())
			{
				var property = child as JProperty;
				var name = property.Name;
				var action = property.Children().First() as JObject;
				if (action["index"] != null)
					dictionary.Add(name, action["index"].ToObject<IndexAction>());
				else if (action["email"] != null)
					dictionary.Add(name, action["email"].ToObject<EmailAction>());
				else if (action["webhook"] != null)
					dictionary.Add(name, action["webhook"].ToObject<WebhookAction>());
				else if (action["logging"] != null)
					dictionary.Add(name, action["logging"].ToObject<LoggingAction>());
			}
			if (dictionary.Count > 0)
				return dictionary;
			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteStartObject();
			var actions = value as IDictionary<string, IAction>;
			foreach(var kvp in actions)
			{
				if (kvp.Value is IEmailAction)
					WriteActionEntry(kvp.Key, "email", kvp.Value, writer, serializer);
				else if (kvp.Value is IIndexAction)
					WriteActionEntry(kvp.Key, "index", kvp.Value, writer, serializer);
				else if (kvp.Value is IWebhookAction)
					WriteActionEntry(kvp.Key, "webhook", kvp.Value, writer, serializer);
				else if (kvp.Value is ILoggingAction)
					WriteActionEntry(kvp.Key, "logging", kvp.Value, writer, serializer);
				else
					throw new ArgumentException("Unknown IAction type");
			}
			writer.WriteEndObject();
		}

		private void WriteActionEntry(string id, string name, object action, JsonWriter writer, JsonSerializer serializer)
		{
			writer.WritePropertyName(id);
			writer.WriteStartObject();
			writer.WritePropertyName(name);
			serializer.Serialize(writer, action);
			writer.WriteEndObject();
		}
	}
}
