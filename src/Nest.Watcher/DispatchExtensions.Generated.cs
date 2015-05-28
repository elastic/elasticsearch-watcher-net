using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;

//Generated File Please Do Not Edit Manually


namespace Nest
{
	///<summary>
	///Raw operations with elasticsearch
	///</summary>
	internal static class Dispatcher
	{
	
		
		internal static ElasticsearchResponse<T> WatcherAckWatchDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<AcknowledgeWatchRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/watch/{id}/_ack
					if (!pathInfo.Id.IsNullOrEmpty())
						return client.WatcherAckWatch<T>(pathInfo.Id,u => pathInfo.RequestParameters);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_watcher/watch/{id}/_ack
					if (!pathInfo.Id.IsNullOrEmpty())
						return client.WatcherAckWatchPost<T>(pathInfo.Id,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherAckWatch() into any of the following paths: \r\n - /_watcher/watch/{id}/_ack");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherAckWatchDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<AcknowledgeWatchRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/watch/{id}/_ack
					if (!pathInfo.Id.IsNullOrEmpty())
						return client.WatcherAckWatchAsync<T>(pathInfo.Id,u => pathInfo.RequestParameters);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_watcher/watch/{id}/_ack
					if (!pathInfo.Id.IsNullOrEmpty())
						return client.WatcherAckWatchPostAsync<T>(pathInfo.Id,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherAckWatch() into any of the following paths: \r\n - /_watcher/watch/{id}/_ack");
		}
		
		
		internal static ElasticsearchResponse<T> WatcherDeleteWatchDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<DeleteWatchRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_watcher/watch/{id}
					if (!pathInfo.Id.IsNullOrEmpty())
						return client.WatcherDeleteWatch<T>(pathInfo.Id,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherDeleteWatch() into any of the following paths: \r\n - /_watcher/watch/{id}");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherDeleteWatchDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<DeleteWatchRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.DELETE:
					//DELETE /_watcher/watch/{id}
					if (!pathInfo.Id.IsNullOrEmpty())
						return client.WatcherDeleteWatchAsync<T>(pathInfo.Id,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherDeleteWatch() into any of the following paths: \r\n - /_watcher/watch/{id}");
		}
		
		
		internal static ElasticsearchResponse<T> WatcherExecuteWatchDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<ExecuteWatchRequestParameters> pathInfo , object body)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/watch/{id}/_execute
					if (!pathInfo.Id.IsNullOrEmpty() && body != null)
						return client.WatcherExecuteWatch<T>(pathInfo.Id,body,u => pathInfo.RequestParameters);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_watcher/watch/{id}/_execute
					if (!pathInfo.Id.IsNullOrEmpty() && body != null)
						return client.WatcherExecuteWatchPost<T>(pathInfo.Id,body,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherExecuteWatch() into any of the following paths: \r\n - /_watcher/watch/{id}/_execute");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherExecuteWatchDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<ExecuteWatchRequestParameters> pathInfo , object body)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/watch/{id}/_execute
					if (!pathInfo.Id.IsNullOrEmpty() && body != null)
						return client.WatcherExecuteWatchAsync<T>(pathInfo.Id,body,u => pathInfo.RequestParameters);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_watcher/watch/{id}/_execute
					if (!pathInfo.Id.IsNullOrEmpty() && body != null)
						return client.WatcherExecuteWatchPostAsync<T>(pathInfo.Id,body,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherExecuteWatch() into any of the following paths: \r\n - /_watcher/watch/{id}/_execute");
		}
		
		
		internal static ElasticsearchResponse<T> WatcherGetWatchDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<GetWatchRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_watcher/watch/{id}
					if (!pathInfo.Id.IsNullOrEmpty())
						return client.WatcherGetWatch<T>(pathInfo.Id,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherGetWatch() into any of the following paths: \r\n - /_watcher/watch/{id}");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherGetWatchDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<GetWatchRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_watcher/watch/{id}
					if (!pathInfo.Id.IsNullOrEmpty())
						return client.WatcherGetWatchAsync<T>(pathInfo.Id,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherGetWatch() into any of the following paths: \r\n - /_watcher/watch/{id}");
		}
		
		
		internal static ElasticsearchResponse<T> WatcherInfoDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<WatcherInfoRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_watcher/
					return client.WatcherInfo<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherInfo() into any of the following paths: \r\n - /_watcher/");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherInfoDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<WatcherInfoRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_watcher/
					return client.WatcherInfoAsync<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherInfo() into any of the following paths: \r\n - /_watcher/");
		}
		
		
		internal static ElasticsearchResponse<T> WatcherPutWatchDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<PutWatchRequestParameters> pathInfo , object body)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/watch/{id}
					if (!pathInfo.Id.IsNullOrEmpty() && body != null)
						return client.WatcherPutWatch<T>(pathInfo.Id,body,u => pathInfo.RequestParameters);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_watcher/watch/{id}
					if (!pathInfo.Id.IsNullOrEmpty() && body != null)
						return client.WatcherPutWatchPost<T>(pathInfo.Id,body,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherPutWatch() into any of the following paths: \r\n - /_watcher/watch/{id}");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherPutWatchDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<PutWatchRequestParameters> pathInfo , object body)
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/watch/{id}
					if (!pathInfo.Id.IsNullOrEmpty() && body != null)
						return client.WatcherPutWatchAsync<T>(pathInfo.Id,body,u => pathInfo.RequestParameters);
					break;

				case PathInfoHttpMethod.POST:
					//POST /_watcher/watch/{id}
					if (!pathInfo.Id.IsNullOrEmpty() && body != null)
						return client.WatcherPutWatchPostAsync<T>(pathInfo.Id,body,u => pathInfo.RequestParameters);
					break;

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherPutWatch() into any of the following paths: \r\n - /_watcher/watch/{id}");
		}
		
		
		internal static ElasticsearchResponse<T> WatcherRestartDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<RestartWatcherRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/_restart
					return client.WatcherRestart<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherRestart() into any of the following paths: \r\n - /_watcher/_restart");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherRestartDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<RestartWatcherRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/_restart
					return client.WatcherRestartAsync<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherRestart() into any of the following paths: \r\n - /_watcher/_restart");
		}
		
		
		internal static ElasticsearchResponse<T> WatcherStartDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<StartWatcherRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/_start
					return client.WatcherStart<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherStart() into any of the following paths: \r\n - /_watcher/_start");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherStartDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<StartWatcherRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/_start
					return client.WatcherStartAsync<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherStart() into any of the following paths: \r\n - /_watcher/_start");
		}
		
		
		internal static ElasticsearchResponse<T> WatcherStatsDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<WatcherStatsRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_watcher/stats
					return client.WatcherStats<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherStats() into any of the following paths: \r\n - /_watcher/stats");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherStatsDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<WatcherStatsRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.GET:
					//GET /_watcher/stats
					return client.WatcherStatsAsync<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherStats() into any of the following paths: \r\n - /_watcher/stats");
		}
		
		
		internal static ElasticsearchResponse<T> WatcherStopDispatch<T>(this IElasticsearchClient client, ElasticsearchPathInfo<StopWatcherRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/_stop
					return client.WatcherStop<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherStop() into any of the following paths: \r\n - /_watcher/_stop");
		}
		
		
		internal static Task<ElasticsearchResponse<T>> WatcherStopDispatchAsync<T>(this IElasticsearchClient client, ElasticsearchPathInfo<StopWatcherRequestParameters> pathInfo )
		{
			switch(pathInfo.HttpMethod)
			{
				case PathInfoHttpMethod.PUT:
					//PUT /_watcher/_stop
					return client.WatcherStopAsync<T>(u => pathInfo.RequestParameters);

			}
			throw new DispatchException("Could not dispatch IElasticClient.WatcherStop() into any of the following paths: \r\n - /_watcher/_stop");
		}
		
	}	
}
