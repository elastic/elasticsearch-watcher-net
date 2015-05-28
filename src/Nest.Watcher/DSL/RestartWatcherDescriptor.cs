using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IRestartWatcherRequest : IRequest<RestartWatcherRequestParameters>
	{
	}

	public partial class RestartWatcherRequest : BasePathRequest<RestartWatcherRequestParameters>, IRestartWatcherRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<RestartWatcherRequestParameters> pathInfo)
		{
			RestartWatcherPathInfo.Update(pathInfo);
		}
	}

	internal static class RestartWatcherPathInfo
	{
		public static void Update(ElasticsearchPathInfo<RestartWatcherRequestParameters> pathInfo)
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.PUT;
		}
	}

	[DescriptorFor("WatcherRestart")]
	public partial class RestartWatcherDescriptor : BasePathDescriptor<RestartWatcherDescriptor, RestartWatcherRequestParameters>, IRestartWatcherRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<RestartWatcherRequestParameters> pathInfo)
		{
			RestartWatcherPathInfo.Update(pathInfo);
		}
	}
}
