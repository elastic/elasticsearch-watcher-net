using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<ScriptCondition>))]
	public interface IScriptCondition : ICondition
	{
		[JsonProperty("inline")]
		string Inline { get; set; }

		[JsonProperty("lang")]
		string Lang { get; set; }

		[JsonProperty("params")]
		IDictionary<string, object> Params { get; set; }

		[JsonProperty("file")]
		string File { get; set; }

		[JsonProperty("id")]
		string Id { get; set; }
	}

	public class ScriptCondition : ConditionBase, IScriptCondition
	{
		public string Inline { get; set; }
		public string Lang { get; set; }
		public IDictionary<string, object> Params { get; set; }
		public string File { get; set; }
		public string Id { get; set; }

		internal override void ContainIn(IConditionContainer container)
		{
			container.Script = this;
		}
	}

	public class ScriptConditionDescriptor : IScriptCondition
	{
		private IScriptCondition Self { get { return this; } }

		public ScriptConditionDescriptor Inline(string script)
		{
			Self.Inline = script;
			return this;
		}

		public ScriptConditionDescriptor Lang(string lang)
		{
			Self.Lang = lang;
			return this;
		}

		public ScriptConditionDescriptor Params(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> selector)
		{
			Self.Params = selector(new FluentDictionary<string, object>());
			return this;
		}

		public ScriptConditionDescriptor File(string file)
		{
			Self.File = file;
			return this;
		}

		public ScriptConditionDescriptor Id(string id)
		{
			Self.Id = id;
			return this;
		}

		string IScriptCondition.Inline { get; set; }
		string IScriptCondition.Lang { get; set; }
		IDictionary<string, object> IScriptCondition.Params { get; set; }
		string IScriptCondition.File { get; set; }
		string IScriptCondition.Id { get; set; }

	}
}
