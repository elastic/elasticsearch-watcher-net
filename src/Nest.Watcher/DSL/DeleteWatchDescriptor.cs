using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	public interface IDeleteWatchRequest : IIdPath<DeleteWatchRequestParameters>
	{
	}

	public partial class DeleteWatchRequest : WatchIdPathBase<DeleteWatchRequestParameters>, IDeleteWatchRequest
	{
		public DeleteWatchRequest(string watchId) : base(watchId)
		{
		}

		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<DeleteWatchRequestParameters> pathInfo)
		{
			DeleteWatchPathInfo.Update(pathInfo, this);
		}
	}

	internal static class DeleteWatchPathInfo
	{
		public static void Update(ElasticsearchPathInfo<DeleteWatchRequestParameters> pathInfo, IDeleteWatchRequest request)
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.DELETE;
		}
	}

	[DescriptorFor("WatcherDeleteWatch")]
	public partial class DeleteWatchDescriptor : WatchIdPathDescriptor<DeleteWatchDescriptor, DeleteWatchRequestParameters>, IDeleteWatchRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<DeleteWatchRequestParameters> pathInfo)
		{
			DeleteWatchPathInfo.Update(pathInfo, this);
		}
	}
}
