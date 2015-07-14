using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ExecutionPhase
	{
		[EnumMember(Value = "input")]
		Input,
		[EnumMember(Value = "condition")]
		Condition,
		[EnumMember(Value = "action")]
		Action
	}
}