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
	public enum InputType
	{
		[EnumMember(Value = "http")]
		Http,
		[EnumMember(Value = "search")]
		Search,
		[EnumMember(Value = "simple")]
		Simple
	}
}
