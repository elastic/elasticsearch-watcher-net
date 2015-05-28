
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Elasticsearch.Net;

//Generated of commit 

namespace Nest
{
	
	
	///<summary>Request parameters descriptor for WatcherAckWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html
	///</pre>
	///</summary>
	public class AcknowledgeWatchRequestParameters : FluentRequestParameters<AcknowledgeWatchRequestParameters> 
	{
		
		internal string _master_timeout { get; set; }
		///<summary>Specify timeout for watch write operation</summary>
		public AcknowledgeWatchRequestParameters MasterTimeout(string master_timeout)
		{
			this._master_timeout = master_timeout;
			this.AddQueryString("master_timeout", this._master_timeout);
			return this;
		}
		
	}
	
	
	///<summary>Request parameters descriptor for WatcherDeleteWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-delete-watch.html
	///</pre>
	///</summary>
	public class DeleteWatchRequestParameters : FluentRequestParameters<DeleteWatchRequestParameters> 
	{
		
		internal string _master_timeout { get; set; }
		///<summary>Specify timeout for watch write operation</summary>
		public DeleteWatchRequestParameters MasterTimeout(string master_timeout)
		{
			this._master_timeout = master_timeout;
			this.AddQueryString("master_timeout", this._master_timeout);
			return this;
		}
		
		
		internal bool _force { get; set; }
		///<summary>Specify if this request should be forced and ignore locks</summary>
		public DeleteWatchRequestParameters Force(bool force)
		{
			this._force = force;
			this.AddQueryString("force", this._force);
			return this;
		}
		
	}
	
	
	///<summary>Request parameters descriptor for WatcherExecuteWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html
	///</pre>
	///</summary>
	public class ExecuteWatchRequestParameters : FluentRequestParameters<ExecuteWatchRequestParameters> 
	{
	}
	
	
	///<summary>Request parameters descriptor for WatcherGetWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-get-watch.html
	///</pre>
	///</summary>
	public class GetWatchRequestParameters : FluentRequestParameters<GetWatchRequestParameters> 
	{
	}
	
	
	///<summary>Request parameters descriptor for WatcherInfo
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-info.html
	///</pre>
	///</summary>
	public class WatcherInfoRequestParameters : FluentRequestParameters<WatcherInfoRequestParameters> 
	{
	}
	
	
	///<summary>Request parameters descriptor for WatcherPutWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html
	///</pre>
	///</summary>
	public class PutWatchRequestParameters : FluentRequestParameters<PutWatchRequestParameters> 
	{
		
		internal string _master_timeout { get; set; }
		///<summary>Specify timeout for watch write operation</summary>
		public PutWatchRequestParameters MasterTimeout(string master_timeout)
		{
			this._master_timeout = master_timeout;
			this.AddQueryString("master_timeout", this._master_timeout);
			return this;
		}
		
	}
	
	
	///<summary>Request parameters descriptor for WatcherRestart
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html
	///</pre>
	///</summary>
	public class RestartWatcherRequestParameters : FluentRequestParameters<RestartWatcherRequestParameters> 
	{
	}
	
	
	///<summary>Request parameters descriptor for WatcherStart
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html
	///</pre>
	///</summary>
	public class StartWatcherRequestParameters : FluentRequestParameters<StartWatcherRequestParameters> 
	{
	}
	
	
	///<summary>Request parameters descriptor for WatcherStats
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html
	///</pre>
	///</summary>
	public class WatcherStatsRequestParameters : FluentRequestParameters<WatcherStatsRequestParameters> 
	{
	}
	
	
	///<summary>Request parameters descriptor for WatcherStop
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html
	///</pre>
	///</summary>
	public class StopWatcherRequestParameters : FluentRequestParameters<StopWatcherRequestParameters> 
	{
	}
	
	
}
 