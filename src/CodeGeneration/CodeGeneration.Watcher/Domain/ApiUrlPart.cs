using System.Collections.Generic;

namespace CodeGeneration.Watcher.Domain
{
	public class ApiUrlPart
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		public IEnumerable<string> Options { get; set; }
	}
}