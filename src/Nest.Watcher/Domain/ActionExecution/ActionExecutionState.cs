using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ActionExecutionState
	{
		[EnumMember(Value = "awaits_execution")]
		AwaitsExecution,
		[EnumMember(Value = "checking")]
		Checking,
		[EnumMember(Value = "execution_not_needed")]
		ExecutionNotNeeded,
		[EnumMember(Value = "throttled")] 
		Throttled,
		[EnumMember(Value = "executed")] 
		Executed,
		[EnumMember(Value = "failed")] 
		Failed,
		[EnumMember(Value = "deleted_while_queued")] 
		DeletedWhileQueued
	}
}
