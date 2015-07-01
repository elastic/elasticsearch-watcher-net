using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	public interface IOptionalMetricPath<TParameters> : IRequest<TParameters>
		where TParameters : IRequestParameters, new()
	{
		Metric Metric { get; set; }
	}

	public abstract class OptionalMetricPathBase<TParameters> : BasePathRequest<TParameters>, IOptionalMetricPath<TParameters>
		where TParameters : IRequestParameters, new()
	{
		public Metric Metric { get; set; }

		protected override void SetRouteParameters(IConnectionSettingsValues settings, ElasticsearchPathInfo<TParameters> pathInfo)
		{
			OptionalMetricRouteParameters.SetRouteParameters(this, settings, pathInfo);
		}
	}

	public abstract class OptionalMetricPathDescriptor<TDescriptor, TParameters> : BasePathDescriptor<TDescriptor, TParameters>, IOptionalMetricPath<TParameters>
		where TDescriptor : OptionalMetricPathDescriptor<TDescriptor, TParameters>, new()
		where TParameters : FluentRequestParameters<TParameters>, new()
	{
		private IOptionalMetricPath<TParameters> Self { get { return this; } }

		Metric IOptionalMetricPath<TParameters>.Metric { get; set; }

		public TDescriptor Metric(Metric metric)
		{
			Self.Metric = metric;
			return (TDescriptor)this;
		}

		protected override void SetRouteParameters(IConnectionSettingsValues settings, ElasticsearchPathInfo<TParameters> pathInfo)
		{
			OptionalMetricRouteParameters.SetRouteParameters(this, settings, pathInfo);
		}
	}

	internal static class OptionalMetricRouteParameters
	{
		public static void SetRouteParameters<TParameters>(
			IOptionalMetricPath<TParameters> path,
			IConnectionSettingsValues settings, 
			ElasticsearchPathInfo<TParameters> pathInfo)
			where TParameters : IRequestParameters, new()
		{
			var watcherPathInfo = new WatcherPathInfo<TParameters>(pathInfo);
			if (path.Metric != null)
				watcherPathInfo.Metric = path.Metric;
		}
	}
}
