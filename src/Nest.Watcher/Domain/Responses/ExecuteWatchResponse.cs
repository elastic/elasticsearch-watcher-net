using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nest.Watcher.Serialization;

namespace Nest
{
	public interface IExecuteWatchResponse : IResponse
	{
		[JsonProperty("watch_id")]
		string WatchId { get; set; }

		[JsonProperty("state")]
		ActionExecutionState? State { get; set; }

		[JsonProperty("condition")]
		ConditionContainer Condition { get; set; }

		[JsonProperty("input")]
		InputContainer Input { get; set; }

		[JsonProperty("trigger_event")]
		IDictionary<string, ITriggerEventContainer> TriggerEvent { get; set; }

		[JsonProperty("execution_result")]
		ExecutionResult ExecutionResult { get; set; }

	}

	public class ExecutionResult
	{
		[JsonProperty("execution_time")]
		public DateTime? ExecutionTime { get; set; }

		[JsonProperty("input")]
		public InputContainer Input { get; set; }

		[JsonProperty("condition")]
		public ExecutionResultCondition Condition { get; set; }

		[JsonProperty("actions")]
		public List<ExecutionResultAction> Actions { get; set; }
	}

	[JsonObject]
	public class ExecutionResultCondition
	{
		[JsonProperty("met")]
		public bool? Met { get; set; }

		[JsonProperty("always")]
		public IAlwaysCondition Always { get; set; }

		[JsonProperty("never")]
		public INeverCondition Never { get; set; }

		[JsonProperty("script")]
		public IScriptCondition Script { get; set; }
	}

	[JsonObject]
	[JsonConverter(typeof(ExecutionResultActionConverter))]
	public class ExecutionResultAction
	{
		internal ActionResultContainer _Container = new ActionResultContainer();

		public string Id { get; set; }
		public EmailActionResult Email { get { return _Container.Email; } }
		public IndexActionResult Index { get { return _Container.Index; } }
		public WebhookActionResult Webhook { get { return _Container.Webhook; } }
		public LoggingActionResult Logging { get { return _Container.Logging; } }
	}

	public class ActionResultContainer
	{
		public EmailActionResult Email { get; set; }
		public IndexActionResult Index { get; set; }
		public WebhookActionResult Webhook { get; set; }
		public LoggingActionResult Logging { get; set; }
	}

	[JsonObject]
	public abstract class ActionResultBase
	{
		[JsonProperty("success")]
		public bool Success { get; set; }
	}

	[JsonObject]
	public class EmailActionResult : ActionResultBase
	{
		[JsonProperty("reason")]
		public string Reason { get; set; }
	}

	[JsonObject]
	public class IndexActionResult : ActionResultBase
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("response")]
		public IndexActionResultIndexResponse Response { get; set; }
	}

	[JsonObject]
	public class IndexActionResultIndexResponse
	{

		[JsonProperty("index")]
		public string Index { get; set; }

		[JsonProperty("created")]
		public bool? Created { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("version")]
		public int Version { get; set; }
	}

	public class WebhookActionResult : ActionResultBase
	{
		// TODO
	}

	[JsonObject]
	public class LoggingActionResult : ActionResultBase
	{
		[JsonProperty("logged_text")]
		public string LoggedText { get; set; }
	}

	public class ExecuteWatchResponse : BaseResponse, IExecuteWatchResponse
	{
		public string WatchId { get; set; }

		public ActionExecutionState? State { get; set; }
		public ConditionContainer Condition { get; set; }
		public InputContainer Input { get; set; }
		public IDictionary<string, ITriggerEventContainer> TriggerEvent { get; set; }
		public ExecutionResult ExecutionResult { get; set; }
	}
}
