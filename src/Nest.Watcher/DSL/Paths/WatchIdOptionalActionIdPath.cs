using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	public interface IWatchIdOptionalActionIdPath<TParameters> : IRequest<TParameters>
		where TParameters : IRequestParameters, new()
	{
		string WatchId { get; set; }
		string ActionId { get; set; }
	}

	public abstract class WatchIdOptionalActionIdPathBase<TParameters> : BasePathRequest<TParameters>, IWatchIdOptionalActionIdPath<TParameters>
		where TParameters : IRequestParameters, new()
	{
		public WatchIdOptionalActionIdPathBase(string watchId)
		{
			this.WatchId = watchId;
		}

		public string WatchId { get; set; }
		public string ActionId { get; set; }
	}

	public abstract class WatchIdOptionalActionIdPathDescriptor<TDescriptor, TParameters> : BasePathDescriptor<TDescriptor, TParameters>, IWatchIdOptionalActionIdPath<TParameters>
		where TDescriptor : WatchIdOptionalActionIdPathDescriptor<TDescriptor, TParameters>, new()
		where TParameters : Elasticsearch.Net.FluentRequestParameters<TParameters>, new()
	{
		private IWatchIdOptionalActionIdPath<TParameters> Self { get { return this; } }
		
		string IWatchIdOptionalActionIdPath<TParameters>.WatchId { get; set; }
		string IWatchIdOptionalActionIdPath<TParameters>.ActionId { get; set; }

		public TDescriptor WatchId(string watchId)
		{
			Self.WatchId = watchId;
			return (TDescriptor)this;
		}

		public TDescriptor ActionId(string actionId)
		{
			Self.ActionId = actionId;
			return (TDescriptor)this;
		}
	}
}
