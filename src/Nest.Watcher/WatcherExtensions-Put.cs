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
		public static IPutWatchResponse PutWatch(this IElasticClient client, string id, Func<PutWatchDescriptor, PutWatchDescriptor> selector)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new PutWatchDescriptor().Name(id));
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<PutWatchDescriptor, PutWatchRequestParameters, PutWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherPutWatchDispatch<PutWatchResponse>(p, d)
			);
		}
		
		public static IPutWatchResponse PutWatch(this IElasticClient client, IPutWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IPutWatchRequest, PutWatchRequestParameters, PutWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherPutWatch<PutWatchResponse>(d.Name, d)
			);
		}

		public static Task<IPutWatchResponse> PutWatchAsync(this IElasticClient client, string id, Func<PutWatchDescriptor, PutWatchDescriptor> selector)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new PutWatchDescriptor().Name(id));
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<PutWatchDescriptor, PutWatchRequestParameters, PutWatchResponse, IPutWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherPutWatchDispatchAsync<PutWatchResponse>(p, d)
			);
		}

		public static Task<IPutWatchResponse> PutWatchAsync(this IElasticClient client, IPutWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IPutWatchRequest, PutWatchRequestParameters, PutWatchResponse, IPutWatchResponse>(
				request,
			    (p, d) => client.Raw.WatcherPutWatchAsync<PutWatchResponse>(p.Name, d)
			);
		}
	}
}
