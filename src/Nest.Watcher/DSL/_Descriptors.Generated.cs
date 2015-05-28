using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Elasticsearch.Net;

//Generated of commit 

namespace Nest
{
	
	///<summary>descriptor for WatcherAckWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html
	///</pre>
	///</summary>
	public partial class AcknowledgeWatchDescriptor 
	{
		
	

		///<summary>Specify timeout for watch write operation</summary>
		public AcknowledgeWatchDescriptor MasterTimeout(string master_timeout)
		{
			this.Request.RequestParameters.MasterTimeout(master_timeout);
			return this;
		}
		
	
	}
	
	
	///<summary>descriptor for WatcherDeleteWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-delete-watch.html
	///</pre>
	///</summary>
	public partial class DeleteWatchDescriptor 
	{
		
	

		///<summary>Specify timeout for watch write operation</summary>
		public DeleteWatchDescriptor MasterTimeout(string master_timeout)
		{
			this.Request.RequestParameters.MasterTimeout(master_timeout);
			return this;
		}
		

		///<summary>Specify if this request should be forced and ignore locks</summary>
		public DeleteWatchDescriptor Force(bool force = true)
		{
			this.Request.RequestParameters.Force(force);
			return this;
		}
		
	
	}
	
	
	///<summary>descriptor for WatcherExecuteWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html
	///</pre>
	///</summary>
	public partial class ExecuteWatchDescriptor 
	{
		
	
	
	}
	
	
	///<summary>descriptor for WatcherGetWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-get-watch.html
	///</pre>
	///</summary>
	public partial class GetWatchDescriptor 
	{
		
	
	
	}
	
	
	///<summary>descriptor for WatcherInfo
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-info.html
	///</pre>
	///</summary>
	public partial class WatcherInfoDescriptor 
	{
		
	
	
	}
	
	
	///<summary>descriptor for WatcherPutWatch
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html
	///</pre>
	///</summary>
	public partial class PutWatchDescriptor 
	{
		
	

		///<summary>Specify timeout for watch write operation</summary>
		public PutWatchDescriptor MasterTimeout(string master_timeout)
		{
			this.Request.RequestParameters.MasterTimeout(master_timeout);
			return this;
		}
		
	
	}
	
	
	///<summary>descriptor for WatcherRestart
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html
	///</pre>
	///</summary>
	public partial class RestartWatcherDescriptor 
	{
		
	
	
	}
	
	
	///<summary>descriptor for WatcherStart
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html
	///</pre>
	///</summary>
	public partial class StartWatcherDescriptor 
	{
		
	
	
	}
	
	
	///<summary>descriptor for WatcherStats
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html
	///</pre>
	///</summary>
	public partial class WatcherStatsDescriptor 
	{
		
	
	
	}
	
	
	///<summary>descriptor for WatcherStop
	///<pre>
	///http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html
	///</pre>
	///</summary>
	public partial class StopWatcherDescriptor 
	{
		
	
	
	}
	
}
 