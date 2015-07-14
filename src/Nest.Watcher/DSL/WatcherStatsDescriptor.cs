using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IWatcherStatsRequest : IOptionalMetricPath<WatcherStatsRequestParameters>
	{
	}

	public partial class WatcherStatsRequest : OptionalMetricPathBase<WatcherStatsRequestParameters>, IWatcherStatsRequest
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

	public partial class WatcherStatsDescriptor : OptionalMetricPathDescriptor<WatcherStatsDescriptor, WatcherStatsRequestParameters>, IWatcherStatsRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<WatcherStatsRequestParameters> pathInfo)
		{
			WatcherStatsPathInfo.Update(pathInfo);
		}
	}
}
