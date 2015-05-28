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
		public static IStartWatcherResponse StartWatcher(this IElasticClient client, Func<StartWatcherDescriptor, StartWatcherDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<StartWatcherDescriptor, StartWatcherRequestParameters, StartWatcherResponse>(
				selector,
				(p, d) => client.Raw.WatcherStartDispatch<StartWatcherResponse>(p)
			);
		}

		public static IStartWatcherResponse StartWatcher(this IElasticClient client, IStartWatcherRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IStartWatcherRequest, StartWatcherRequestParameters, StartWatcherResponse>(
				request,
				(p, d) => client.Raw.WatcherStartDispatch<StartWatcherResponse>(p)
			);
		}

		public static Task<IStartWatcherResponse> StartWatcherAsync(this IElasticClient client, Func<StartWatcherDescriptor, StartWatcherDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<StartWatcherDescriptor, StartWatcherRequestParameters, StartWatcherResponse, IStartWatcherResponse>(
				selector,
				(p, d) => client.Raw.WatcherStartDispatchAsync<StartWatcherResponse>(p)
			); ;
		}

		public static Task<IStartWatcherResponse> StartWatcherAsync(this IElasticClient client, IStartWatcherRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IStartWatcherRequest, StartWatcherRequestParameters, StartWatcherResponse, IStartWatcherResponse>(
				request,
				(p, d) => client.Raw.WatcherStartDispatchAsync<StartWatcherResponse>(p)
			);
		}
	}
}
