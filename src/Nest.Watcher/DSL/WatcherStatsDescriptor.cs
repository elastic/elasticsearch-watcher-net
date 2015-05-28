using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IWatcherStatsRequest : IRequest<WatcherStatsRequestParameters>
	{
	}

	public partial class WatcherStatsRequest : BasePathRequest<WatcherStatsRequestParameters>, IWatcherStatsRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<WatcherStatsRequestParameters> pathInfo)
		{
			WatcherStatsPathInfo.Update(pathInfo);
		}
	}

	internal static class WatcherStatsPathInfo
	{
		public static void Update(ElasticsearchPathInfo<WatcherStatsRequestParameters> pathInfo)
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.GET;
		}
	}

	public partial class WatcherStatsDescriptor : BasePathDescriptor<WatcherStatsDescriptor, WatcherStatsRequestParameters>, IWatcherStatsRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<WatcherStatsRequestParameters> pathInfo)
		{
			WatcherStatsPathInfo.Update(pathInfo);
		}
	}
}
