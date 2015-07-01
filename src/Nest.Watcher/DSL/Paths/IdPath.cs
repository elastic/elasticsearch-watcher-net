using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	public interface IIdPath<TParameters> : IRequest<TParameters>
		where TParameters : IRequestParameters, new()
	{
		string Id { get; set; }
	}

	public abstract class IdPathBase<TParameters> : BasePathRequest<TParameters>, IIdPath<TParameters>
		where TParameters : IRequestParameters, new()
	{
		public string Id { get; set; }

		public IdPathBase(string watchId)
		{

		}

		protected override void SetRouteParameters(IConnectionSettingsValues settings, ElasticsearchPathInfo<TParameters> pathInfo)
		{
			IdRouteParameters.SetRouteParameters(this, settings, pathInfo);
		}
	}

	public abstract class IdPathDescriptor<TDescriptor, TParameters> : BasePathDescriptor<TDescriptor, TParameters>, IIdPath<TParameters>
		where TDescriptor : IdPathDescriptor<TDescriptor, TParameters>, new()
		where TParameters : FluentRequestParameters<TParameters>, new()
	{
		private IIdPath<TParameters> Self { get { return this; } }
		string IIdPath<TParameters>.Id { get; set; }

		public TDescriptor Id(string id)
		{
			Self.Id = id;
			return (TDescriptor)this;
		}

		protected override void SetRouteParameters(IConnectionSettingsValues settings, ElasticsearchPathInfo<TParameters> pathInfo)
		{
			IdRouteParameters.SetRouteParameters(this, settings, pathInfo);
		}
	}

		internal static class IdRouteParameters
	{
		public static void SetRouteParameters<TParameters>(
			IIdPath<TParameters> path,
			IConnectionSettingsValues settings,
			ElasticsearchPathInfo<TParameters> pathInfo)
			where TParameters : IRequestParameters, new()
		{
			var watcherPathInfo = new WatcherPathInfo<TParameters>(pathInfo);
			watcherPathInfo.Id = path.Id;
			watcherPathInfo.WatchId = path.Id;
		}
	}
}
