using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest.Domain.ActionExecution
{
	public class ExecutionResult
	{
		public IEnumerable<ActionResult> Action { get; set; }
		public DateTime? ExecutionTime { get; set; }
		public InputContainer Input { get; set; }
	}

	public class ActionResult
	{
		
	}
}
