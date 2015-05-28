using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IStartWatcherRequest : IRequest<StartWatcherRequestParameters>
	{
	}

	public partial class StartWatcherRequest : BasePathRequest<StartWatcherRequestParameters>, IStartWatcherRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<StartWatcherRequestParameters> pathInfo)
		{
			StartWatcherPathInfo.Update(pathInfo);
		}
	}

	internal static class StartWatcherPathInfo
	{
		public static void Update(ElasticsearchPathInfo<StartWatcherRequestParameters> pathInfo)
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.PUT;
		}
	}

	[DescriptorFor("WatcherStart")]
	public partial class StartWatcherDescriptor : BasePathDescriptor<StartWatcherDescriptor, StartWatcherRequestParameters>, IStartWatcherRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<StartWatcherRequestParameters> pathInfo)
		{
			StartWatcherPathInfo.Update(pathInfo);
		}
	}
}
