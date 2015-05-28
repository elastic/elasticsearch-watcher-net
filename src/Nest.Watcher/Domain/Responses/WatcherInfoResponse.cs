using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IWatcherInfoResponse : IResponse
	{
		[JsonProperty("version")]
		WatcherVersion Version { get; }
	}

	public class WatcherInfoResponse : BaseResponse, IWatcherInfoResponse
	{
		public WatcherVersion Version { get; internal set; }
	}
}
