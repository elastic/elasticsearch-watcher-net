using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest.Watcher.Serialization
{
	public class SimpleInputConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) { return true; }

		public override bool CanRead { get { return true; } }

		public override bool CanWrite { get { return true;  } }
		
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.StartObject)
				return null;

			var dictionary = serializer.Deserialize<IDictionary<string, object>>(reader);
			return new SimpleInput(dictionary);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var s = value as ISimpleInput;
			if (s == null || s.Payload == null) return;

			serializer.Serialize(writer, s.Payload);
		}
	}
}
