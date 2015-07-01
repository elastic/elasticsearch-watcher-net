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
		public static IDeleteWatchResponse DeleteWatch(this IElasticClient client, string watchId, Func<DeleteWatchDescriptor, DeleteWatchDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new DeleteWatchDescriptor().Id(watchId));
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<DeleteWatchDescriptor, DeleteWatchRequestParameters, DeleteWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherDeleteWatchDispatch<DeleteWatchResponse>(p)
			);
		}

		public static IDeleteWatchResponse DeleteWatch(this IElasticClient client, IDeleteWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IDeleteWatchRequest, DeleteWatchRequestParameters, DeleteWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherDeleteWatchDispatch<DeleteWatchResponse>(p)
			);
		}

		public static Task<IDeleteWatchResponse> DeleteWatchAsync(this IElasticClient client, string watchId, Func<DeleteWatchDescriptor, DeleteWatchDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new DeleteWatchDescriptor().Id(watchId));
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<DeleteWatchDescriptor, DeleteWatchRequestParameters, DeleteWatchResponse, IDeleteWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherDeleteWatchDispatchAsync<DeleteWatchResponse>(p)
			);
		}

		public static Task<IDeleteWatchResponse> DeleteWatchAsync(this IElasticClient client, IDeleteWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IDeleteWatchRequest, DeleteWatchRequestParameters, DeleteWatchResponse, IDeleteWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherDeleteWatchDispatchAsync<DeleteWatchResponse>(p)
			);
		}
	}
}
