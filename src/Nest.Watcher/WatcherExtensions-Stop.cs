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
		public static IStopWatcherResponse StopWatcher(this IElasticClient client, Func<StopWatcherDescriptor, StopWatcherDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<StopWatcherDescriptor, StopWatcherRequestParameters, StopWatcherResponse>(
				selector,
				(p, d) => client.Raw.WatcherStopDispatch<StopWatcherResponse>(p)
			);
		}

		public static IStopWatcherResponse StopWatcher(this IElasticClient client, IStopWatcherRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IStopWatcherRequest, StopWatcherRequestParameters, StopWatcherResponse>(
				request,
				(p, d) => client.Raw.WatcherStopDispatch<StopWatcherResponse>(p)
			);
		}

		public static Task<IStopWatcherResponse> StopWatcherAsync(this IElasticClient client, Func<StopWatcherDescriptor, StopWatcherDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<StopWatcherDescriptor, StopWatcherRequestParameters, StopWatcherResponse, IStopWatcherResponse>(
				selector,
				(p, d) => client.Raw.WatcherStopDispatchAsync<StopWatcherResponse>(p)
			); ;
		}

		public static Task<IStopWatcherResponse> StopWatcherAsync(this IElasticClient client, IStopWatcherRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IStopWatcherRequest, StopWatcherRequestParameters, StopWatcherResponse, IStopWatcherResponse>(
				request,
				(p, d) => client.Raw.WatcherStopDispatchAsync<StopWatcherResponse>(p)
			); ;
		}
	}
}
