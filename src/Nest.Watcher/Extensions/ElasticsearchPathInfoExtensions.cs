using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	public static class ElasticsearchPathInfoExtensions
	{
		public static WatcherPathInfo<TParameters> ToWatcherPathInfo<TParameters>(
			this ElasticsearchPathInfo<TParameters> pathInfo,
			string watchId = null,
			string actionId = null,
			Metric metric = Metric.All
		)
			where TParameters : IRequestParameters, new()
		{
			return new WatcherPathInfo<TParameters>(pathInfo)
			{
				WatchId = watchId,
				ActionId = actionId,
				Metric = metric
			};
		}
	}
}
