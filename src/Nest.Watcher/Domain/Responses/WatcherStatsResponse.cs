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

		[JsonProperty("execution_thread_pool")]
		ExecutionThreadPool ExecutionThreadPool { get; }

		[JsonProperty("current_watches")]
		IEnumerable<WatchRecordStats> CurrentWatches { get; }

		[JsonProperty("queued_watches")]
		IEnumerable<WatchRecordQueuedStats> QueuedWatches { get; }

	}

	public class WatchRecordStats
	{
		[JsonProperty("watch_id")]
		private string WatchId { get; }

		[JsonProperty("watch_record_id")]
		private string WatchRecordId { get; }

		[JsonProperty("triggered_timed")]
		private DateTime? TriggeredTime { get; }

		[JsonProperty("execution_time")]
		private DateTime? ExecutionTime { get; }

	}
	public class WatchRecordQueuedStats : WatchRecordStats
	{
		[JsonProperty("execution_phase")]
		ExecutionPhase? ExecutionPhase { get; }
	}

	public class WatcherStatsResponse : BaseResponse, IWatcherStatsResponse
	{
		public string WatcherState { get; internal set; }
		public int WatchCount { get; internal set; }
		public ExecutionThreadPool ExecutionThreadPool { get; internal set; }

		public IEnumerable<WatchRecordStats> CurrentWatches { get; internal set; }

		public IEnumerable<WatchRecordQueuedStats> QueuedWatches { get; internal set; }
	}
}
