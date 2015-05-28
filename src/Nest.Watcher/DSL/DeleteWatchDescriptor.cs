using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	public interface IDeleteWatchRequest : INamePath<DeleteWatchRequestParameters>
	{
	}

	public partial class DeleteWatchRequest : NamePathBase<DeleteWatchRequestParameters>, IDeleteWatchRequest
	{
		public DeleteWatchRequest(string id) : base(id)
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
			pathInfo.Id = request.Name;
			pathInfo.HttpMethod = PathInfoHttpMethod.DELETE;
		}
	}

	[DescriptorFor("WatcherDeleteWatch")]
	public partial class DeleteWatchDescriptor : NamePathDescriptor<DeleteWatchDescriptor, DeleteWatchRequestParameters>, IDeleteWatchRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<DeleteWatchRequestParameters> pathInfo)
		{
			DeleteWatchPathInfo.Update(pathInfo, this);
		}
	}
}
