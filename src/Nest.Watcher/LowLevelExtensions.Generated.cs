using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Elasticsearch.Net.Connection.Configuration;

///Generated File Please Do Not Edit Manually
	
namespace Nest
{
	///<summary>
	///Raw operations with elasticsearch
	///</summary>
	internal static class WatcherClientExtensions
	{
	
		
		///<summary>Represents a PUT on /_watcher/watch/{watch_id}/_ack
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherAckWatch<T>(this IElasticsearchClient client, string watch_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			var url = "_watcher/watch/{0}/_ack".F(client.Encoded(watch_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{watch_id}/_ack
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherAckWatchAsync<T>(this IElasticsearchClient client, string watch_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			var url = "_watcher/watch/{0}/_ack".F(client.Encoded(watch_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{watch_id}/_ack
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherAckWatch(this IElasticsearchClient client, string watch_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			var url = "_watcher/watch/{0}/_ack".F(client.Encoded(watch_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{watch_id}/_ack
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherAckWatchAsync(this IElasticsearchClient client, string watch_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			var url = "_watcher/watch/{0}/_ack".F(client.Encoded(watch_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{watch_id}/{action_id}/_ack
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="action_id">A comma-separated list of the action ids to be acked</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherAckWatch<T>(this IElasticsearchClient client, string watch_id, string action_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			action_id.ThrowIfNullOrEmpty("action_id");
			var url = "_watcher/watch/{0}/{1}/_ack".F(client.Encoded(watch_id), client.Encoded(action_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{watch_id}/{action_id}/_ack
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="action_id">A comma-separated list of the action ids to be acked</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherAckWatchAsync<T>(this IElasticsearchClient client, string watch_id, string action_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			action_id.ThrowIfNullOrEmpty("action_id");
			var url = "_watcher/watch/{0}/{1}/_ack".F(client.Encoded(watch_id), client.Encoded(action_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{watch_id}/{action_id}/_ack
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="action_id">A comma-separated list of the action ids to be acked</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherAckWatch(this IElasticsearchClient client, string watch_id, string action_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			action_id.ThrowIfNullOrEmpty("action_id");
			var url = "_watcher/watch/{0}/{1}/_ack".F(client.Encoded(watch_id), client.Encoded(action_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{watch_id}/{action_id}/_ack
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="action_id">A comma-separated list of the action ids to be acked</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherAckWatchAsync(this IElasticsearchClient client, string watch_id, string action_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			action_id.ThrowIfNullOrEmpty("action_id");
			var url = "_watcher/watch/{0}/{1}/_ack".F(client.Encoded(watch_id), client.Encoded(action_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{watch_id}/_ack
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherAckWatchPost<T>(this IElasticsearchClient client, string watch_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			var url = "_watcher/watch/{0}/_ack".F(client.Encoded(watch_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"POST", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{watch_id}/_ack
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherAckWatchPostAsync<T>(this IElasticsearchClient client, string watch_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			var url = "_watcher/watch/{0}/_ack".F(client.Encoded(watch_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"POST", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{watch_id}/_ack
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherAckWatchPost(this IElasticsearchClient client, string watch_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			var url = "_watcher/watch/{0}/_ack".F(client.Encoded(watch_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"POST", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{watch_id}/_ack
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherAckWatchPostAsync(this IElasticsearchClient client, string watch_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			var url = "_watcher/watch/{0}/_ack".F(client.Encoded(watch_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"POST", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{watch_id}/{action_id}/_ack
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="action_id">A comma-separated list of the action ids to be acked</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherAckWatchPost<T>(this IElasticsearchClient client, string watch_id, string action_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			action_id.ThrowIfNullOrEmpty("action_id");
			var url = "_watcher/watch/{0}/{1}/_ack".F(client.Encoded(watch_id), client.Encoded(action_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"POST", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{watch_id}/{action_id}/_ack
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="action_id">A comma-separated list of the action ids to be acked</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherAckWatchPostAsync<T>(this IElasticsearchClient client, string watch_id, string action_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			action_id.ThrowIfNullOrEmpty("action_id");
			var url = "_watcher/watch/{0}/{1}/_ack".F(client.Encoded(watch_id), client.Encoded(action_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"POST", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{watch_id}/{action_id}/_ack
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="action_id">A comma-separated list of the action ids to be acked</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherAckWatchPost(this IElasticsearchClient client, string watch_id, string action_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			action_id.ThrowIfNullOrEmpty("action_id");
			var url = "_watcher/watch/{0}/{1}/_ack".F(client.Encoded(watch_id), client.Encoded(action_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"POST", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{watch_id}/{action_id}/_ack
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-ack-watch.html</para>	
	    ///</summary>
		///<param name="watch_id">Watch ID</param>
		///<param name="action_id">A comma-separated list of the action ids to be acked</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherAckWatchPostAsync(this IElasticsearchClient client, string watch_id, string action_id, Func<AcknowledgeWatchRequestParameters, AcknowledgeWatchRequestParameters> requestParameters = null)
		{
			watch_id.ThrowIfNullOrEmpty("watch_id");
			action_id.ThrowIfNullOrEmpty("action_id");
			var url = "_watcher/watch/{0}/{1}/_ack".F(client.Encoded(watch_id), client.Encoded(action_id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new AcknowledgeWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"POST", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a DELETE on /_watcher/watch/{id}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-delete-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherDeleteWatch<T>(this IElasticsearchClient client, string id, Func<DeleteWatchRequestParameters, DeleteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new DeleteWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"DELETE", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a DELETE on /_watcher/watch/{id}
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-delete-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherDeleteWatchAsync<T>(this IElasticsearchClient client, string id, Func<DeleteWatchRequestParameters, DeleteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new DeleteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"DELETE", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a DELETE on /_watcher/watch/{id}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-delete-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherDeleteWatch(this IElasticsearchClient client, string id, Func<DeleteWatchRequestParameters, DeleteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new DeleteWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"DELETE", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a DELETE on /_watcher/watch/{id}
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-delete-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherDeleteWatchAsync(this IElasticsearchClient client, string id, Func<DeleteWatchRequestParameters, DeleteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new DeleteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"DELETE", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{id}/_execute
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherExecuteWatch<T>(this IElasticsearchClient client, string id, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}/_execute".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{id}/_execute
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherExecuteWatchAsync<T>(this IElasticsearchClient client, string id, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}/_execute".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{id}/_execute
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherExecuteWatch(this IElasticsearchClient client, string id, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}/_execute".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{id}/_execute
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherExecuteWatchAsync(this IElasticsearchClient client, string id, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}/_execute".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/_execute
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherExecuteWatch<T>(this IElasticsearchClient client, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			var url = "_watcher/watch/_execute".F();
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/_execute
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherExecuteWatchAsync<T>(this IElasticsearchClient client, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			var url = "_watcher/watch/_execute".F();
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/_execute
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherExecuteWatch(this IElasticsearchClient client, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			var url = "_watcher/watch/_execute".F();
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/_execute
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherExecuteWatchAsync(this IElasticsearchClient client, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			var url = "_watcher/watch/_execute".F();
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{id}/_execute
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherExecuteWatchPost<T>(this IElasticsearchClient client, string id, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}/_execute".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{id}/_execute
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherExecuteWatchPostAsync<T>(this IElasticsearchClient client, string id, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}/_execute".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{id}/_execute
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherExecuteWatchPost(this IElasticsearchClient client, string id, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}/_execute".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{id}/_execute
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherExecuteWatchPostAsync(this IElasticsearchClient client, string id, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}/_execute".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/_execute
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherExecuteWatchPost<T>(this IElasticsearchClient client, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			var url = "_watcher/watch/_execute".F();
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/_execute
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherExecuteWatchPostAsync<T>(this IElasticsearchClient client, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			var url = "_watcher/watch/_execute".F();
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/_execute
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherExecuteWatchPost(this IElasticsearchClient client, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			var url = "_watcher/watch/_execute".F();
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/_execute
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-execute-watch.html</para>	
	    ///</summary>
		///<param name="body">Execution control</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherExecuteWatchPostAsync(this IElasticsearchClient client, object body, Func<ExecuteWatchRequestParameters, ExecuteWatchRequestParameters> requestParameters = null)
		{
			var url = "_watcher/watch/_execute".F();
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new ExecuteWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/watch/{id}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-get-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherGetWatch<T>(this IElasticsearchClient client, string id, Func<GetWatchRequestParameters, GetWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			requestParameters = requestParameters ?? (s => s);
			var passIn = new GetWatchRequestParameters();
			requestParams = requestParameters(passIn);
			if (requestParams.RequestConfiguration == null) 
					requestParams.RequestConfiguration = new RequestConfiguration { AllowedStatusCodes = new [] { 404 } };
			else {
									 if (requestParams.RequestConfiguration.AllowedStatusCodes == null) {
						requestParams.RequestConfiguration.AllowedStatusCodes =  new [] { 404 };
					}
			}
				


			return client.DoRequest<T>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/watch/{id}
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-get-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherGetWatchAsync<T>(this IElasticsearchClient client, string id, Func<GetWatchRequestParameters, GetWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			requestParameters = requestParameters ?? (s => s);
			var passIn = new GetWatchRequestParameters();
			requestParams = requestParameters(passIn);
			if (requestParams.RequestConfiguration == null) 
					requestParams.RequestConfiguration = new RequestConfiguration { AllowedStatusCodes = new [] { 404 } };
			else {
									 if (requestParams.RequestConfiguration.AllowedStatusCodes == null) {
						requestParams.RequestConfiguration.AllowedStatusCodes =  new [] { 404 };
					}
			}
				


			return client.DoRequestAsync<T>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/watch/{id}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-get-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherGetWatch(this IElasticsearchClient client, string id, Func<GetWatchRequestParameters, GetWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			requestParameters = requestParameters ?? (s => s);
			var passIn = new GetWatchRequestParameters();
			requestParams = requestParameters(passIn);
			if (requestParams.RequestConfiguration == null) 
					requestParams.RequestConfiguration = new RequestConfiguration { AllowedStatusCodes = new [] { 404 } };
			else {
									 if (requestParams.RequestConfiguration.AllowedStatusCodes == null) {
						requestParams.RequestConfiguration.AllowedStatusCodes =  new [] { 404 };
					}
			}
				


			return client.DoRequest<DynamicDictionary>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/watch/{id}
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-get-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherGetWatchAsync(this IElasticsearchClient client, string id, Func<GetWatchRequestParameters, GetWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			requestParameters = requestParameters ?? (s => s);
			var passIn = new GetWatchRequestParameters();
			requestParams = requestParameters(passIn);
			if (requestParams.RequestConfiguration == null) 
					requestParams.RequestConfiguration = new RequestConfiguration { AllowedStatusCodes = new [] { 404 } };
			else {
									 if (requestParams.RequestConfiguration.AllowedStatusCodes == null) {
						requestParams.RequestConfiguration.AllowedStatusCodes =  new [] { 404 };
					}
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-info.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherInfo<T>(this IElasticsearchClient client, Func<WatcherInfoRequestParameters, WatcherInfoRequestParameters> requestParameters = null)
		{
			var url = "_watcher/";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherInfoRequestParameters());
			}
				


			return client.DoRequest<T>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-info.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherInfoAsync<T>(this IElasticsearchClient client, Func<WatcherInfoRequestParameters, WatcherInfoRequestParameters> requestParameters = null)
		{
			var url = "_watcher/";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherInfoRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-info.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherInfo(this IElasticsearchClient client, Func<WatcherInfoRequestParameters, WatcherInfoRequestParameters> requestParameters = null)
		{
			var url = "_watcher/";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherInfoRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-info.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherInfoAsync(this IElasticsearchClient client, Func<WatcherInfoRequestParameters, WatcherInfoRequestParameters> requestParameters = null)
		{
			var url = "_watcher/";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherInfoRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{id}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">The watch</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherPutWatch<T>(this IElasticsearchClient client, string id, object body, Func<PutWatchRequestParameters, PutWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new PutWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{id}
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">The watch</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherPutWatchAsync<T>(this IElasticsearchClient client, string id, object body, Func<PutWatchRequestParameters, PutWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new PutWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{id}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">The watch</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherPutWatch(this IElasticsearchClient client, string id, object body, Func<PutWatchRequestParameters, PutWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new PutWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/watch/{id}
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">The watch</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherPutWatchAsync(this IElasticsearchClient client, string id, object body, Func<PutWatchRequestParameters, PutWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new PutWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"PUT", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{id}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">The watch</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherPutWatchPost<T>(this IElasticsearchClient client, string id, object body, Func<PutWatchRequestParameters, PutWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new PutWatchRequestParameters());
			}
				


			return client.DoRequest<T>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{id}
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">The watch</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherPutWatchPostAsync<T>(this IElasticsearchClient client, string id, object body, Func<PutWatchRequestParameters, PutWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new PutWatchRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{id}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">The watch</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherPutWatchPost(this IElasticsearchClient client, string id, object body, Func<PutWatchRequestParameters, PutWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new PutWatchRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a POST on /_watcher/watch/{id}
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-put-watch.html</para>	
	    ///</summary>
		///<param name="id">Watch ID</param>
		///<param name="body">The watch</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherPutWatchPostAsync(this IElasticsearchClient client, string id, object body, Func<PutWatchRequestParameters, PutWatchRequestParameters> requestParameters = null)
		{
			id.ThrowIfNullOrEmpty("id");
			var url = "_watcher/watch/{0}".F(client.Encoded(id));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new PutWatchRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"POST", url, body, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_restart
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherRestart<T>(this IElasticsearchClient client, Func<RestartWatcherRequestParameters, RestartWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_restart";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new RestartWatcherRequestParameters());
			}
				


			return client.DoRequest<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_restart
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherRestartAsync<T>(this IElasticsearchClient client, Func<RestartWatcherRequestParameters, RestartWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_restart";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new RestartWatcherRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_restart
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherRestart(this IElasticsearchClient client, Func<RestartWatcherRequestParameters, RestartWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_restart";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new RestartWatcherRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_restart
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherRestartAsync(this IElasticsearchClient client, Func<RestartWatcherRequestParameters, RestartWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_restart";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new RestartWatcherRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_start
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherStart<T>(this IElasticsearchClient client, Func<StartWatcherRequestParameters, StartWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_start";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new StartWatcherRequestParameters());
			}
				


			return client.DoRequest<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_start
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherStartAsync<T>(this IElasticsearchClient client, Func<StartWatcherRequestParameters, StartWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_start";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new StartWatcherRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_start
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherStart(this IElasticsearchClient client, Func<StartWatcherRequestParameters, StartWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_start";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new StartWatcherRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_start
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherStartAsync(this IElasticsearchClient client, Func<StartWatcherRequestParameters, StartWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_start";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new StartWatcherRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/stats
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherStats<T>(this IElasticsearchClient client, Func<WatcherStatsRequestParameters, WatcherStatsRequestParameters> requestParameters = null)
		{
			var url = "_watcher/stats";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherStatsRequestParameters());
			}
				


			return client.DoRequest<T>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/stats
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherStatsAsync<T>(this IElasticsearchClient client, Func<WatcherStatsRequestParameters, WatcherStatsRequestParameters> requestParameters = null)
		{
			var url = "_watcher/stats";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherStatsRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/stats
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherStats(this IElasticsearchClient client, Func<WatcherStatsRequestParameters, WatcherStatsRequestParameters> requestParameters = null)
		{
			var url = "_watcher/stats";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherStatsRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/stats
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherStatsAsync(this IElasticsearchClient client, Func<WatcherStatsRequestParameters, WatcherStatsRequestParameters> requestParameters = null)
		{
			var url = "_watcher/stats";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherStatsRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/stats/{metric}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html</para>	
	    ///</summary>
		///<param name="metric">Controls what additional stat metrics should be include in the response</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherStats<T>(this IElasticsearchClient client, Metric metric, Func<WatcherStatsRequestParameters, WatcherStatsRequestParameters> requestParameters = null)
		{
			metric.ThrowIfNull("metric");
			var url = "_watcher/stats/{0}".F(client.Encoded(metric));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherStatsRequestParameters());
			}
				


			return client.DoRequest<T>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/stats/{metric}
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html</para>	
	    ///</summary>
		///<param name="metric">Controls what additional stat metrics should be include in the response</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherStatsAsync<T>(this IElasticsearchClient client, Metric metric, Func<WatcherStatsRequestParameters, WatcherStatsRequestParameters> requestParameters = null)
		{
			metric.ThrowIfNull("metric");
			var url = "_watcher/stats/{0}".F(client.Encoded(metric));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherStatsRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/stats/{metric}
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html</para>	
	    ///</summary>
		///<param name="metric">Controls what additional stat metrics should be include in the response</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherStats(this IElasticsearchClient client, Metric metric, Func<WatcherStatsRequestParameters, WatcherStatsRequestParameters> requestParameters = null)
		{
			metric.ThrowIfNull("metric");
			var url = "_watcher/stats/{0}".F(client.Encoded(metric));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherStatsRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a GET on /_watcher/stats/{metric}
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-stats.html</para>	
	    ///</summary>
		///<param name="metric">Controls what additional stat metrics should be include in the response</param>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherStatsAsync(this IElasticsearchClient client, Metric metric, Func<WatcherStatsRequestParameters, WatcherStatsRequestParameters> requestParameters = null)
		{
			metric.ThrowIfNull("metric");
			var url = "_watcher/stats/{0}".F(client.Encoded(metric));
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new WatcherStatsRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"GET", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_stop
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static ElasticsearchResponse<T> WatcherStop<T>(this IElasticsearchClient client, Func<StopWatcherRequestParameters, StopWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_stop";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new StopWatcherRequestParameters());
			}
				


			return client.DoRequest<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_stop
		///<para></para>Returns: A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>A task that'll return an ElasticsearchResponse&lt;T&gt; holding the reponse body deserialized as T.
		///<para> - If T is of type byte[] deserialization will be shortcircuited</para>
		///<para> - If T is of type VoidResponse the response stream will be ignored completely</para>
		///</returns>
		internal static Task<ElasticsearchResponse<T>> WatcherStopAsync<T>(this IElasticsearchClient client, Func<StopWatcherRequestParameters, StopWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_stop";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new StopWatcherRequestParameters());
			}
				


			return client.DoRequestAsync<T>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_stop
		///<para></para>Returns: ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>ElasticsearchResponse&lt;T&gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static ElasticsearchResponse<DynamicDictionary> WatcherStop(this IElasticsearchClient client, Func<StopWatcherRequestParameters, StopWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_stop";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new StopWatcherRequestParameters());
			}
				


			return client.DoRequest<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
		
		///<summary>Represents a PUT on /_watcher/_stop
		///<para></para>Returns: Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
	    ///<para>See also: http://www.elastic.co/guide/en/watcher/current/appendix-api-service.html</para>	
	    ///</summary>
		///<param name="requestParameters">
		///Optional function to specify any additional request parameters 
		///<para>Querystring values, connection configuration specific to this request, deserialization state.</para>
		///</param>
		///<returns>Task that'll return an ElasticsearchResponse&lt;T$gt; holding the response body deserialized as DynamicDictionary
		///<para> - Dynamic dictionary is a special dynamic type that allows json to be traversed safely</para>
		///<para> - i.e result.Response.hits.hits[0].property.nested["nested_deeper"]</para>
		///<para> - can be safely dispatched to a nullable type even if intermediate properties do not exist</para>
		///</returns>
		internal static Task<ElasticsearchResponse<DynamicDictionary>> WatcherStopAsync(this IElasticsearchClient client, Func<StopWatcherRequestParameters, StopWatcherRequestParameters> requestParameters = null)
		{
			var url = "_watcher/_stop";
			IRequestParameters requestParams = null;
				
			if (requestParameters != null)
			{
				requestParams = requestParameters(new StopWatcherRequestParameters());
			}
				


			return client.DoRequestAsync<DynamicDictionary>(
				"PUT", url, data: null, 
				requestParameters: requestParams
			);
		}
	
	  }
	  }
	
