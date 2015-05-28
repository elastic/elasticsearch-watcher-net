using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nest.Watcher.Serialization;
using Newtonsoft.Json;

namespace Nest
{
	[JsonConverter(typeof(SimulatedActionsConverter))]
	public class SimulatedActions
	{
		public bool UseAll { get; private set; }

		public IEnumerable<string> Actions { get; private set; }

		private SimulatedActions() { }

		public static SimulatedActions All
		{
			get { return new SimulatedActions { UseAll = true }; }
		}

		public static SimulatedActions Some( params string[] actions)
		{

			return new SimulatedActions { Actions = actions };
		}

		public static SimulatedActions Some(IEnumerable<string> actions)
		{

			return new SimulatedActions { Actions = actions };
		}
	}
}
