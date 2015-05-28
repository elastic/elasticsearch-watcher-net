using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IWatcherInfoRequest : IRequest<WatcherInfoRequestParameters>
	{
	}

	public partial class WatcherInfoRequest : BasePathRequest<WatcherInfoRequestParameters>, IWatcherInfoRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<WatcherInfoRequestParameters> pathInfo)
		{
			WatcherInfoPathInfo.Update(pathInfo);
		}
	}

	internal static class WatcherInfoPathInfo
	{
		public static void Update(ElasticsearchPathInfo<WatcherInfoRequestParameters> pathInfo)
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.GET;
		}
	}

	[DescriptorFor("WatcherInfo")]
	public partial class WatcherInfoDescriptor : BasePathDescriptor<WatcherInfoDescriptor, WatcherInfoRequestParameters>, IWatcherInfoRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<WatcherInfoRequestParameters> pathInfo)
		{
			WatcherInfoPathInfo.Update(pathInfo);
		}
	}
}
