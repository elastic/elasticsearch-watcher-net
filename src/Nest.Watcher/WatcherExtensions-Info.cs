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
		public static IWatcherInfoResponse WatcherInfo(this IElasticClient client, Func<WatcherInfoDescriptor, WatcherInfoDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<WatcherInfoDescriptor, WatcherInfoRequestParameters, WatcherInfoResponse>(
				selector,
				(p, d) => client.Raw.WatcherInfoDispatch<WatcherInfoResponse>(p)
			);
		}

		public static IWatcherInfoResponse WatcherInfo(this IElasticClient client, IWatcherInfoRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IWatcherInfoRequest, WatcherInfoRequestParameters, WatcherInfoResponse>(
				request,
				(p, d) => client.Raw.WatcherInfoDispatch<WatcherInfoResponse>(p)
			);
		}

		public static Task<IWatcherInfoResponse> WatcherInfoAsync(this IElasticClient client, Func<WatcherInfoDescriptor, WatcherInfoDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<WatcherInfoDescriptor, WatcherInfoRequestParameters, WatcherInfoResponse, IWatcherInfoResponse>(
				selector,
				(p, d) => client.Raw.WatcherInfoDispatchAsync<WatcherInfoResponse>(p)
			);
		}

		public static Task<IWatcherInfoResponse> WatcherInfoAsync(this IElasticClient client, IWatcherInfoRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IWatcherInfoRequest, WatcherInfoRequestParameters, WatcherInfoResponse, IWatcherInfoResponse>(
				request,
				(p, d) => client.Raw.WatcherInfoDispatchAsync<WatcherInfoResponse>(p)
			);
		}
	}
}
