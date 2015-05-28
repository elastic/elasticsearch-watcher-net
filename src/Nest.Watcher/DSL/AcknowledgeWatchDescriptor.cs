using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{

	[JsonObject(MemberSerialization=MemberSerialization.OptIn)]
	public interface IAcknowledgeWatchRequest : INamePath<AcknowledgeWatchRequestParameters>
	{
	}

	public partial class AcknowledgeWatchRequest : NamePathBase<AcknowledgeWatchRequestParameters>, IAcknowledgeWatchRequest
	{
		public AcknowledgeWatchRequest(string id) : base(id)
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
			pathInfo.Id = request.Name;
			pathInfo.HttpMethod = PathInfoHttpMethod.PUT;
		}
	}

	[DescriptorFor("WatcherAckWatch")]
	public partial class AcknowledgeWatchDescriptor : NamePathDescriptor<AcknowledgeWatchDescriptor, AcknowledgeWatchRequestParameters>, IAcknowledgeWatchRequest
	{
		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<AcknowledgeWatchRequestParameters> pathInfo)
		{
			AcknowledgeWatchPathInfo.Update(pathInfo, this);
		}
	}
}
