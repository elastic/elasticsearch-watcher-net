using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Nest
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Status
	{
		[EnumMember(Value = "success")]
		Success,
		[EnumMember(Value = "failure")]
		Failure,
		[EnumMember(Value = "simulated")]
		Simulated,
		[EnumMember(Value = "throttled")]
		Throttled            
	}
}
