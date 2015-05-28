using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IStopWatcherRequest : IRequest<StopWatcherRequestParameters>
	{
	}

	public partial class StopWatcherRequest : BasePathRequest<StopWatcherRequestParameters>, IStopWatcherRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<StopWatcherRequestParameters> pathInfo)
		{
			StopWatcherPathInfo.Update(pathInfo);
		}
	}

	internal static class StopWatcherPathInfo
	{
		public static void Update(ElasticsearchPathInfo<StopWatcherRequestParameters> pathInfo)
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.PUT;
		}
	}

	[DescriptorFor("WatcherStop")]
	public partial class StopWatcherDescriptor : BasePathDescriptor<StopWatcherDescriptor, StopWatcherRequestParameters>, IStopWatcherRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<StopWatcherRequestParameters> pathInfo)
		{
			StopWatcherPathInfo.Update(pathInfo);
		}
	}
}
