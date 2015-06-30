using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	public class WatcherPathInfo<TParameters> : ElasticsearchPathInfo<TParameters>
		where TParameters : IRequestParameters, new()
	{
		public string WatchId { get; set; }
		public string ActionId { get; set; }
		public Metric Metric { get; set; }
	}
}
