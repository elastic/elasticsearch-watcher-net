using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum LogLevel
	{
		[EnumMember(Value = "trace")]
		Trace,
		[EnumMember(Value = "debug")]
		Debug,
		[EnumMember(Value = "info")]
		Info,
		[EnumMember(Value = "warn")]
		Warn,
		[EnumMember(Value = "error")]
		Error
	}
}