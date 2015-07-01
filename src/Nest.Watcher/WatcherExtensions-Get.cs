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
		public static IGetWatchResponse GetWatch(this IElasticClient client, string watchId, Func<GetWatchDescriptor, GetWatchDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new GetWatchDescriptor().Id(watchId));
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<GetWatchDescriptor, GetWatchRequestParameters, GetWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherGetWatchDispatch<GetWatchResponse>(p)
			);
		}

		public static IGetWatchResponse GetWatch(this IElasticClient client, IGetWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IGetWatchRequest, GetWatchRequestParameters, GetWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherGetWatchDispatch<GetWatchResponse>(p)
			);
		}

		public static Task<IGetWatchResponse> GetWatchAsync(this IElasticClient client, string watchId, Func<GetWatchDescriptor, GetWatchDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new GetWatchDescriptor().Id(watchId));
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<GetWatchDescriptor, GetWatchRequestParameters, GetWatchResponse, IGetWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherGetWatchDispatchAsync<GetWatchResponse>(p)
			);
		}

		public static Task<IGetWatchResponse> GetWatchAsync(this IElasticClient client, IGetWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IGetWatchRequest, GetWatchRequestParameters, GetWatchResponse, IGetWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherGetWatchDispatchAsync<GetWatchResponse>(p)
			);
		}
	}
}
