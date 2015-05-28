using Nest.Watcher.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IPutWatchRequest : INamePath<PutWatchRequestParameters>
	{
		[JsonProperty("metadata")]
		IDictionary<string, object> Metadata { get; set; }

		[JsonProperty("trigger")]
		TriggerContainer Trigger { get; set; }

		[JsonProperty("input")]
		InputContainer Input { get; set; }

		[JsonProperty("throttle_period")]
		string ThrottlePeriod { get; set; }

		[JsonProperty("condition")]
		ConditionContainer Condition { get; set; }

		[JsonProperty("transform")]
		TransformContainer Transform { get; set; }

		[JsonProperty("actions")]
		[JsonConverter(typeof(ActionDictionaryConverter))]
		IDictionary<string, IAction> Actions { get; set; }
	}

	public partial class PutWatchRequest : NamePathBase<PutWatchRequestParameters>, IPutWatchRequest
	{
		public PutWatchRequest(string id) : base(id) { }

		public IDictionary<string, object> Metadata { get; set; }

		public TriggerContainer Trigger { get; set; }

		public InputContainer Input { get; set; }

		public string ThrottlePeriod { get; set; }

		public ConditionContainer Condition { get; set; }

		public TransformContainer Transform { get; set; }

		public IDictionary<string, IAction> Actions { get; set; }

		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<PutWatchRequestParameters> pathInfo)
		{
			PutWatchPathInfo.Update(pathInfo, this);
		}
	}

	internal static class PutWatchPathInfo
	{
		public static void Update(ElasticsearchPathInfo<PutWatchRequestParameters> pathInfo, IPutWatchRequest request)
		{
			pathInfo.HttpMethod = PathInfoHttpMethod.PUT;
			pathInfo.Id = request.Name;
		}
	}

	[DescriptorFor("WatcherPutWatch")]
	public partial class PutWatchDescriptor : NamePathDescriptor<PutWatchDescriptor, PutWatchRequestParameters>, IPutWatchRequest
	{
		private IPutWatchRequest Self { get { return this; } }
		IDictionary<string, object> IPutWatchRequest.Metadata  { get; set; }
		TriggerContainer IPutWatchRequest.Trigger  { get; set; }
		InputContainer IPutWatchRequest.Input  { get; set; }
		string IPutWatchRequest.ThrottlePeriod  { get; set; }
		ConditionContainer IPutWatchRequest.Condition  { get; set; }
		TransformContainer IPutWatchRequest.Transform  { get; set; }
		IDictionary<string, IAction> IPutWatchRequest.Actions  { get; set; }

		public PutWatchDescriptor Metadata(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> metadataDictionary)
		{
			Self.Metadata = metadataDictionary(new FluentDictionary<string, object>());
			return this;
		}

		public PutWatchDescriptor Trigger(Func<TriggerDescriptor, TriggerContainer> triggerSelector)
		{
			Self.Trigger = triggerSelector(new TriggerDescriptor());
			return this;
		}

		public PutWatchDescriptor Input(Func<InputDescriptor, InputContainer> inputSelector)
		{
			Self.Input = inputSelector(new InputDescriptor());
			return this;
		}

		public PutWatchDescriptor ThrottlePeriod(string throttlePeriod)
		{
			Self.ThrottlePeriod = throttlePeriod;
			return this;
		}

		public PutWatchDescriptor Condition(Func<ConditionDescriptor, ConditionContainer> conditionSelector)
		{
			Self.Condition = conditionSelector(new ConditionDescriptor());
			return this;
		}

		public PutWatchDescriptor Transform(Func<TransformDescriptor, TransformContainer> transformSelector)
		{
			Self.Transform = transformSelector(new TransformDescriptor());
			return this;
		}

		public PutWatchDescriptor Actions(Func<FluentDictionary<string, IAction>, FluentDictionary<string, IAction>> actionsDictionary)
		{
			Self.Actions = actionsDictionary(new FluentDictionary<string, IAction>());
			return this;
		}

		protected override void UpdatePathInfo(IConnectionSettingsValues settings, ElasticsearchPathInfo<PutWatchRequestParameters> pathInfo)
		{
			PutWatchPathInfo.Update(pathInfo, this);
		}
	}
}
