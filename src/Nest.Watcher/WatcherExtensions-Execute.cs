using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	public static partial class WatcherExtensions
	{
		//TODO should selector be null here?
		public static IExecuteWatchResponse ExecuteWatch(this IElasticClient client, string watchId, Func<ExecuteWatchDescriptor, ExecuteWatchDescriptor> selector)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new ExecuteWatchDescriptor().Name(watchId));
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<ExecuteWatchDescriptor, ExecuteWatchRequestParameters, ExecuteWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherExecuteWatchDispatch<ExecuteWatchResponse>(p, d)
			);
		}

		public static IExecuteWatchResponse ExecuteWatch(this IElasticClient client, IExecuteWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IExecuteWatchRequest, ExecuteWatchRequestParameters, ExecuteWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherExecuteWatchDispatch<ExecuteWatchResponse>(p, d)
			);
		}

		public static Task<IExecuteWatchResponse> ExecuteWatchAsync(this IElasticClient client, string watchId, Func<ExecuteWatchDescriptor, ExecuteWatchDescriptor> selector)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new ExecuteWatchDescriptor().Name(watchId));
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<ExecuteWatchDescriptor, ExecuteWatchRequestParameters, ExecuteWatchResponse, IExecuteWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherExecuteWatchDispatchAsync<ExecuteWatchResponse>(p, d)
			);
		}

		public static Task<IExecuteWatchResponse> ExecuteWatchAsync(this IElasticClient client, IExecuteWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IExecuteWatchRequest, ExecuteWatchRequestParameters, ExecuteWatchResponse, IExecuteWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherExecuteWatchDispatchAsync<ExecuteWatchResponse>(p, d)
			);
		}
	}
}
