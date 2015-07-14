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
	public enum ActionType
	{
		[EnumMember(Value = "email")]
		Email,
		[EnumMember(Value = "index")]
		Index,
		[EnumMember(Value = "logging")]
		Logging,
		[EnumMember(Value = "webhook")]
		Webhook
	}
}
