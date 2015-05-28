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
		public static IRestartWatcherResponse RestartWatcher(this IElasticClient client, Func<RestartWatcherDescriptor, RestartWatcherDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<RestartWatcherDescriptor, RestartWatcherRequestParameters, RestartWatcherResponse>(
				selector,
				(p, d) => client.Raw.WatcherRestartDispatch<RestartWatcherResponse>(p)
			); ;
		}

		public static IRestartWatcherResponse RestartWatcher(this IElasticClient client, IRestartWatcherRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IRestartWatcherRequest, RestartWatcherRequestParameters, RestartWatcherResponse>(
				request,
				(p, d) => client.Raw.WatcherRestartDispatch<RestartWatcherResponse>(p)
			); ;
		}

		public static Task<IRestartWatcherResponse> RestartWatcherAsync(this IElasticClient client, Func<RestartWatcherDescriptor, RestartWatcherDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<RestartWatcherDescriptor, RestartWatcherRequestParameters, RestartWatcherResponse, IRestartWatcherResponse>(
				selector,
				(p, d) => client.Raw.WatcherRestartDispatchAsync<RestartWatcherResponse>(p)
			); ; ;
		}

		public static Task<IRestartWatcherResponse> RestartWatcherAsync(this IElasticClient client, IRestartWatcherRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IRestartWatcherRequest, RestartWatcherRequestParameters, RestartWatcherResponse, IRestartWatcherResponse>(
				request,
				(p, d) => client.Raw.WatcherRestartDispatchAsync<RestartWatcherResponse>(p)
			);
		}
	}
}
