using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	public interface IWatcherStatsResponse : IResponse
	{
		[JsonProperty("watcher_state")]
		string WatcherState { get; }
		
		[JsonProperty("watch_count")]
		int WatchCount { get; }

		[JsonProperty("execution_queue")]
		WatcherExecutionQueue ExecutionQueue { get; }
	}
	
	public class WatcherStatsResponse : BaseResponse, IWatcherStatsResponse
	{
		public string WatcherState { get; internal set; }
		public int WatchCount { get; internal set; }
		public WatcherExecutionQueue ExecutionQueue { get; internal set; }
	}
}
