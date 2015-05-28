using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest.Watcher.Serialization
{
	public class SimulatedActionsConverter : JsonConverter
	{

		public override bool CanConvert(Type objectType) { return true; }

		public override bool CanRead { get { return true; } }
		
		public override bool CanWrite { get { return true;  } }

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.String)
				return SimulatedActions.All;
			return SimulatedActions.Some(serializer.Deserialize<List<string>>(reader));
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var s = value as SimulatedActions;
			if (s == null) return;

			if (s.UseAll) writer.WriteValue("_all");
			else serializer.Serialize(writer, s.Actions);
		}
	}
}
