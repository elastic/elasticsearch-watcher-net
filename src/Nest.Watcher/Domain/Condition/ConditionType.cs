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
	public enum ConditionType
	{
		[EnumMember(Value="always")]
		Always,
		[EnumMember(Value="never")]
		Never,
		[EnumMember(Value="script")]
		Script
	}
}
