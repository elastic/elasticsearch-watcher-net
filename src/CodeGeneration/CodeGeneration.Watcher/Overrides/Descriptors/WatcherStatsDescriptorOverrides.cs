using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGeneration.Watcher.Overrides.Descriptors
{
	public class WatcherStatsDescriptorOverrides : IDescriptorOverrides
	{
		public IEnumerable<string> SkipQueryStringParams
		{
			get
			{
				return new string[]
				{
					"metric"
				};
			}
		}

		public IDictionary<string, string> RenameQueryStringParams { get { return null; } }
	}
}
