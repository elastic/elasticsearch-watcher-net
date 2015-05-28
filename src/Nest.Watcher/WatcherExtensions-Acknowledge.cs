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
		public static IAcknowledgeWatchResponse AcknowledgeWatch(this IElasticClient client, string id, Func<AcknowledgeWatchDescriptor, AcknowledgeWatchDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new AcknowledgeWatchDescriptor().Name(id));
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<AcknowledgeWatchDescriptor, AcknowledgeWatchRequestParameters, AcknowledgeWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherAckWatchDispatch<AcknowledgeWatchResponse>(p)
			);
		}

		public static IAcknowledgeWatchResponse AcknowledgeWatch(this IElasticClient client, IAcknowledgeWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).Dispatch<IAcknowledgeWatchRequest, AcknowledgeWatchRequestParameters, AcknowledgeWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherAckWatch<AcknowledgeWatchResponse>(p.Id)
			);
		}

		public static Task<IAcknowledgeWatchResponse> AcknowledgeWatchAsync(this IElasticClient client, string id, Func<AcknowledgeWatchDescriptor, AcknowledgeWatchDescriptor> selector = null)
		{
			selector = selector ?? (s => s);
			var descriptor = selector(new AcknowledgeWatchDescriptor().Name(id));
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<AcknowledgeWatchDescriptor, AcknowledgeWatchRequestParameters, AcknowledgeWatchResponse, IAcknowledgeWatchResponse>(
				descriptor,
				(p, d) => client.Raw.WatcherAckWatchDispatchAsync<AcknowledgeWatchResponse>(p) 
			);
		}

		public static Task<IAcknowledgeWatchResponse> AcknowledgeWatchAsync(this IElasticClient client, IAcknowledgeWatchRequest request)
		{
			return ((IHighLevelToLowLevelDispatcher)client).DispatchAsync<IAcknowledgeWatchRequest, AcknowledgeWatchRequestParameters, AcknowledgeWatchResponse, IAcknowledgeWatchResponse>(
				request,
				(p, d) => client.Raw.WatcherAckWatchAsync<AcknowledgeWatchResponse>(p.Id)
			);
		}
	}
}
