using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Nest.Watcher.Serialization
{
	public class CompareConditionConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) { return true; }

		public override bool CanRead { get { return true; } }

		public override bool CanWrite { get { return true;  } }
		
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.StartObject) return null;
			
			var compare = JObject.Load(reader);
			if (compare.Count == 0) return null;

			var pathProperty = compare.Children<JProperty>().First();
			if (pathProperty.Count == 0) return null;
			var path = pathProperty.Name;

			var conditionProperty = pathProperty.Value.Children<JProperty>().First();
			if (conditionProperty.Count == 0) return null;
			var condition = conditionProperty.Name;
			var value = serializer.Deserialize<object>(conditionProperty.Value.CreateReader());

			switch (condition)
			{
				case "eq": return new EqualCondition(path, value);
				case "not_eq": return new NotEqualCondition(path, value);
				case "gt": return new GreaterThanCondition(path, value);
				case "gte": return new GreaterThanOrEqualCondition(path, value);
				case "lt": return new LowerThanCondition(path, value);
				case "lte": return new LowerThanOrEqualCondition(path, value);
				default:
					return null;
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var s = value as ICompareCondition;
			if (s == null || s.Path.IsNullOrEmpty()) return;
			
			writer.WriteStartObject();
			{
				writer.WritePropertyName(s.Path);
				writer.WriteStartObject();
				{
					writer.WritePropertyName(s.Comparison);
					writer.WriteValue(s.Value);
				}
				writer.WriteEndObject();
			}
			writer.WriteEndObject();


		}
	}
}
