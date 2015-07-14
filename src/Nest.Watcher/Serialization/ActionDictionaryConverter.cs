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
				if (property == null) continue;
				var name = property.Name;

				var actionJson = property.Value as JObject;
				if (actionJson == null) continue;

				string throttlePeriod = null;
				IAction action = null;
				foreach (var prop in actionJson.Properties())
				{
					if (prop.Name == "throttle_period")
						throttlePeriod = prop.Value.Value<string>();
					else if (prop.Name == "index")
					{
						action = prop.Value.ToObject<IndexAction>();
						dictionary.Add(name, action);
					}
					else if (prop.Name == "email")
					{
						action = prop.Value.ToObject<EmailAction>();
						dictionary.Add(name, action);
					}
					else if (prop.Name == "webhook")
					{
						action = prop.Value.ToObject<WebhookAction>();
						dictionary.Add(name, action);
					}
					else if (prop.Name == "logging")
					{
						action = prop.Value.ToObject<LoggingAction>();
						dictionary.Add(name, action);
					}
				}
				if (action != null) action.ThrottlePeriod = throttlePeriod;
			}

			return dictionary.Count > 0 ? dictionary : null;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteStartObject();
			var actions = (value as IDictionary<string, IAction>) ?? new Dictionary<string, IAction>();
			foreach(var kvp in actions.Where(kv=>kv.Value != null))
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

		private void WriteActionEntry(string id, string name, IAction action, JsonWriter writer, JsonSerializer serializer)
		{
			writer.WritePropertyName(id);
			writer.WriteStartObject();
			if (!action.ThrottlePeriod.IsNullOrEmpty())
			{
				writer.WritePropertyName("throttle_period");
				writer.WriteValue(action.ThrottlePeriod);
			}
			writer.WritePropertyName(name);
			serializer.Serialize(writer, action);
			writer.WriteEndObject();
		}
	}
}
