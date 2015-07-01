using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IGetWatchRequest : IIdPath<GetWatchRequestParameters>
	{
	}

	public partial class GetWatchRequest : WatchIdPathBase<GetWatchRequestParameters>, IGetWatchRequest
	{
		public GetWatchRequest(string id) : base(id)
		{
		}

		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<GetWatchRequestParameters> pathInfo)
		{
			GetWatchPathInfo.Update(pathInfo, this);
		}
	}

	internal static class GetWatchPathInfo
	{
		public static void Update(ElasticsearchPathInfo<GetWatchRequestParameters> pathInfo, IGetWatchRequest request) 
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.GET;
		}
	}

	[DescriptorFor("WatcherGetWatch")]
	public partial class GetWatchDescriptor : WatchIdPathDescriptor<GetWatchDescriptor, GetWatchRequestParameters>, IGetWatchRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<GetWatchRequestParameters> pathInfo)
		{
			GetWatchPathInfo.Update(pathInfo, this);
		}
	}
}
