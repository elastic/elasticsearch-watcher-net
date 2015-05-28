using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	public interface IStartWatcherResponse : IResponse
	{
		[JsonProperty("acknowledged")]
		bool Acknowledged { get; }
	}

	public class StartWatcherResponse : BaseResponse, IStartWatcherResponse
	{
		public bool Acknowledged { get; internal set; }
	}
}
