
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Elasticsearch.Net;

//Generated of commit 

namespace Nest
{

		
	///<summary>Request parameters for WatcherAckWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html
	///</pre>
	///</summary>
	public partial class AcknowledgeWatchRequest 
			{
		
		///<summary>Specify timeout for watch write operation</summary>
		public string MasterTimeout 
		{ 
			get { return this.Request.RequestParameters.GetQueryStringValue<string>("master_timeout"); } 
			set { this.Request.RequestParameters.AddQueryString("master_timeout", value); }
		}
		
	}
	
		
	///<summary>Request parameters for WatcherDeleteWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-delete-watch.html
	///</pre>
	///</summary>
	public partial class DeleteWatchRequest 
			{
		
		///<summary>Specify timeout for watch write operation</summary>
		public string MasterTimeout 
		{ 
			get { return this.Request.RequestParameters.GetQueryStringValue<string>("master_timeout"); } 
			set { this.Request.RequestParameters.AddQueryString("master_timeout", value); }
		}
		
		
		///<summary>Specify if this request should be forced and ignore locks</summary>
		public bool Force 
		{ 
			get { return this.Request.RequestParameters.GetQueryStringValue<bool>("force"); } 
			set { this.Request.RequestParameters.AddQueryString("force", value); }
		}
		
	}
	
		
	///<summary>Request parameters for WatcherExecuteWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html
	///</pre>
	///</summary>
	public partial class ExecuteWatchRequest 
			{
		
		///<summary>indicates whether the watch should execute in debug mode</summary>
		public bool Debug 
		{ 
			get { return this.Request.RequestParameters.GetQueryStringValue<bool>("debug"); } 
			set { this.Request.RequestParameters.AddQueryString("debug", value); }
		}
		
	}
	
		
	///<summary>Request parameters for WatcherGetWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-get-watch.html
	///</pre>
	///</summary>
	public partial class GetWatchRequest 
			{
	}
	
		
	///<summary>Request parameters for WatcherInfo
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-info.html
	///</pre>
	///</summary>
	public partial class WatcherInfoRequest 
			{
	}
	
		
	///<summary>Request parameters for WatcherPutWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html
	///</pre>
	///</summary>
	public partial class PutWatchRequest 
			{
		
		///<summary>Specify timeout for watch write operation</summary>
		public string MasterTimeout 
		{ 
			get { return this.Request.RequestParameters.GetQueryStringValue<string>("master_timeout"); } 
			set { this.Request.RequestParameters.AddQueryString("master_timeout", value); }
		}
		
	}
	
		
	///<summary>Request parameters for WatcherRestart
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html
	///</pre>
	///</summary>
	public partial class RestartWatcherRequest 
			{
	}
	
		
	///<summary>Request parameters for WatcherStart
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html
	///</pre>
	///</summary>
	public partial class StartWatcherRequest 
			{
	}
	
		
	///<summary>Request parameters for WatcherStats
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html
	///</pre>
	///</summary>
	public partial class WatcherStatsRequest 
			{
		
		///<summary>Controls what additional stat metrics should be include in the response</summary>
		public Metric Metric 
		{ 
			get { return this.Request.RequestParameters.GetQueryStringValue<Metric>("metric"); } 
			set { this.Request.RequestParameters.AddQueryString("metric", value); }
		}
		
	}
	
		
	///<summary>Request parameters for WatcherStop
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html
	///</pre>
	///</summary>
	public partial class StopWatcherRequest 
			{
	}
	
	
}
 