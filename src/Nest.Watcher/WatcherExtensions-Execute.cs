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
		public static IExecuteWatchResponse ExecuteWatch(this IElasticClient client, string watchId, Func<ExecuteWatchDescriptor, ExecuteWatchDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			var descriptor = new ExecuteWatchDescriptor();
			if (!watchId.IsNullOrEmpty())
				descriptor.Id(watchId);
			descriptor = selector(descriptor);
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<ExecuteWatchDescriptor, ExecuteWatchRequestParameters, ExecuteWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherExecuteWatchDispatch<ExecuteWatchResponse>(p, d)
			);
		}

		public static IExecuteWatchResponse ExecuteWatch(this IElasticClient client, Func<ExecuteWatchDescriptor, ExecuteWatchDescriptor> selector)
		{
			return ExecuteWatch(client, null, selector);
		}

		public static IExecuteWatchResponse ExecuteWatch(this IElasticClient client, IExecuteWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IExecuteWatchRequest, ExecuteWatchRequestParameters, ExecuteWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherExecuteWatchDispatch<ExecuteWatchResponse>(p, d)
			);
		}

		public static Task<IExecuteWatchResponse> ExecuteWatchAsync(this IElasticClient client, string watchId, Func<ExecuteWatchDescriptor, ExecuteWatchDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			var descriptor = new ExecuteWatchDescriptor();
			if (!watchId.IsNullOrEmpty())
				descriptor.Id(watchId);
			descriptor = selector(descriptor);
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<ExecuteWatchDescriptor, ExecuteWatchRequestParameters, ExecuteWatchResponse, IExecuteWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherExecuteWatchDispatchAsync<ExecuteWatchResponse>(p, d)
			);
		}

		public static Task<IExecuteWatchResponse> ExecuteWatchAsync(this IElasticClient client, Func<ExecuteWatchDescriptor, ExecuteWatchDescriptor> selector)
		{
			return ExecuteWatchAsync(client, null, selector);
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
