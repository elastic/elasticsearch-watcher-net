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
		public static IWatcherStatsResponse WatcherStats(this IElasticClient client, Func<WatcherStatsDescriptor, WatcherStatsDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<WatcherStatsDescriptor, WatcherStatsRequestParameters, WatcherStatsResponse>(
				selector,
				(p, d) => client.Raw.WatcherStatsDispatch<WatcherStatsResponse>(p)
			);
		}

		public static IWatcherStatsResponse WatcherStats(this IElasticClient client, IWatcherStatsRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IWatcherStatsRequest, WatcherStatsRequestParameters, WatcherStatsResponse>(
				request,
				(p, d) => client.Raw.WatcherStatsDispatch<WatcherStatsResponse>(p)
			);
		}

		public static Task<IWatcherStatsResponse> WatcherStatsAsync(this IElasticClient client, Func<WatcherStatsDescriptor, WatcherStatsDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<WatcherStatsDescriptor, WatcherStatsRequestParameters, WatcherStatsResponse, IWatcherStatsResponse>(
				selector,
				(p, d) => client.Raw.WatcherStatsDispatchAsync<WatcherStatsResponse>(p)
			); ;
		}

		public static Task<IWatcherStatsResponse> WatcherStatsAsync(this IElasticClient client, IWatcherStatsRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IWatcherStatsRequest, WatcherStatsRequestParameters, WatcherStatsResponse, IWatcherStatsResponse>(
				request,
				(p, d) => client.Raw.WatcherStatsDispatchAsync<WatcherStatsResponse>(p)
			); ;
		}
	}
}
