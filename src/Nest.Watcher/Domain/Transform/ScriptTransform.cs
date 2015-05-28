using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nest.Watcher.Serialization;
using Nest.Resolvers.Converters;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<ScriptTransform>))]
	public interface IScriptTransform : ITransform
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

	public class ScriptTransform : TransformBase, IScriptTransform
	{
		public string Inline { get; set; }
		public string Lang { get; set; }
		public IDictionary<string, object> Params { get; set; }
		public string File { get; set; }
		public string Id { get; set; }

		internal override void ContainIn(ITransformContainer container)
		{
			container.Script = this;
		}
	}

	public class ScriptTransformDescriptor : IScriptTransform
	{
		private IScriptTransform Self { get { return this; } }

		public ScriptTransformDescriptor Inline(string script)
		{
			Self.Inline = script;
			return this;
		}

		public ScriptTransformDescriptor Lang(string lang)
		{
			Self.Lang = lang;
			return this;
		}

		public ScriptTransformDescriptor Params(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> selector)
		{
			Self.Params = selector(new FluentDictionary<string, object>());
			return this;
		}

		public ScriptTransformDescriptor File(string file)
		{
			Self.File = file;
			return this;
		}

		public ScriptTransformDescriptor Id(string id)
		{
			Self.Id = id;
			return this;
		}

		string IScriptTransform.Inline { get; set; }
		string IScriptTransform.Lang { get; set; }
		IDictionary<string, object> IScriptTransform.Params { get; set; }
		string IScriptTransform.File { get; set; }
		string IScriptTransform.Id { get; set; }
	}
}
