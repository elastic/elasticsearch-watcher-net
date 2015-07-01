using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	



	[JsonObject(MemberSerialization=MemberSerialization.OptIn)]
	public interface IAcknowledgeWatchRequest : IWatchIdOptionalActionIdPath<AcknowledgeWatchRequestParameters>
	{
	}

	public partial class AcknowledgeWatchRequest : WatchIdOptionalActionIdPathBase<AcknowledgeWatchRequestParameters>, IAcknowledgeWatchRequest
	{
		public AcknowledgeWatchRequest(string watchId) : base(watchId)
		{
		}

		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<AcknowledgeWatchRequestParameters> pathInfo)
		{
			AcknowledgeWatchPathInfo.Update(pathInfo, this);
		}
	}

	internal static class AcknowledgeWatchPathInfo
	{
		public static  void Update(ElasticsearchPathInfo<AcknowledgeWatchRequestParameters> pathInfo, IAcknowledgeWatchRequest request)
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.PUT;
		}
	}

	[DescriptorFor("WatcherAckWatch")]
	public partial class AcknowledgeWatchDescriptor : WatchIdOptionalActionIdPathDescriptor<AcknowledgeWatchDescriptor, AcknowledgeWatchRequestParameters>, IAcknowledgeWatchRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<AcknowledgeWatchRequestParameters> pathInfo)
		{
			AcknowledgeWatchPathInfo.Update(pathInfo, this);
		}
	}
}
