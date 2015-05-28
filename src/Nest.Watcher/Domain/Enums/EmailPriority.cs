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
	public enum EmailPriority
	{
		[EnumMember(Value="lowest")]
		Lowest,
		[EnumMember(Value = "low")]
		Low,
		[EnumMember(Value = "normal")]
		Normal,
		[EnumMember(Value = "high")]
		High,
		[EnumMember(Value = "highest")]
		Highest
	}
}
