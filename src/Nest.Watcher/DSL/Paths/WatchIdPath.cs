using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	public interface IIdPath<TParameters> : IRequest<TParameters>
		where TParameters : Elasticsearch.Net.IRequestParameters, new()
	{
		string WatchId { get; set; }
	}

	public abstract class WatchIdPathBase<TParameters> : BasePathRequest<TParameters>, IIdPath<TParameters>
		where TParameters : IRequestParameters, new()
	{
		public string WatchId { get; set; }

		public WatchIdPathBase(string watchId)
		{

		}

		protected override void SetRouteParameters(IConnectionSettingsValues settings, ElasticsearchPathInfo<TParameters> pathInfo)
		{
			WatchIdRouteParameters.SetRouteParameters(this, settings, pathInfo);
		}
	}

	public abstract class WatchIdPathDescriptor<TDescriptor, TParameters> : BasePathDescriptor<TDescriptor, TParameters>, IIdPath<TParameters>
		where TDescriptor : WatchIdPathDescriptor<TDescriptor, TParameters>, new()
		where TParameters : FluentRequestParameters<TParameters>, new()
	{
		private IIdPath<TParameters> Self { get { return this; } }
		string IIdPath<TParameters>.WatchId { get; set; }

		public TDescriptor WatchId(string id)
		{
			Self.WatchId = id;
			return (TDescriptor)this;
		}

		protected override void SetRouteParameters(IConnectionSettingsValues settings, ElasticsearchPathInfo<TParameters> pathInfo)
		{
			WatchIdRouteParameters.SetRouteParameters(this, settings, pathInfo);
		}
	}

		internal static class WatchIdRouteParameters
	{
		public static void SetRouteParameters<TParameters>(
			IIdPath<TParameters> path,
			IConnectionSettingsValues settings,
			ElasticsearchPathInfo<TParameters> pathInfo)
			where TParameters : IRequestParameters, new()
		{
			var watcherPathInfo = new WatcherPathInfo<TParameters>(pathInfo);
			watcherPathInfo.Id = path.WatchId;
			watcherPathInfo.WatchId = path.WatchId;
		}
	}
}
