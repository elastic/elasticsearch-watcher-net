using Nest.Resolvers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<ConditionContainer>))]
	public interface IConditionContainer : INestSerializable
	{
		[JsonProperty("always")]
		IAlwaysCondition Always { get; set; }

		[JsonProperty("never")]
		INeverCondition Never { get; set; }

		[JsonProperty("script")]
		IScriptCondition Script { get; set; }

		[JsonProperty("compare")]
		ICompareCondition Compare { get; set; }
	}

	public class ConditionContainer : IConditionContainer
	{
		public ConditionContainer()
		{
		}

		public ConditionContainer(ConditionBase condition)
		{
			condition.ContainIn(this);
		}

		IAlwaysCondition IConditionContainer.Always { get; set; }
		INeverCondition IConditionContainer.Never { get; set; }
		IScriptCondition IConditionContainer.Script { get; set; }
		ICompareCondition IConditionContainer.Compare { get; set; }
	}

	public class ConditionDescriptor : ConditionContainer
	{
		private IConditionContainer Self { get { return this; } }

		public ConditionDescriptor Script(Func<ScriptConditionDescriptor, IScriptCondition> selector)
		{
			Self.Script = selector(new ScriptConditionDescriptor());
			return this;
		}

		public ConditionDescriptor Always()
		{
			Self.Always = new AlwaysCondition();
			return this;
		}

		public ConditionDescriptor Never()
		{
			Self.Never = new NeverCondition();
			return this;
		}

		public ConditionDescriptor EqualTo(string path, object value)
		{
			Self.Compare = new EqualCondition(path, value);
			return this;
		}

		public ConditionDescriptor NotEqualTo(string path, object value)
		{
			Self.Compare = new NotEqualCondition(path, value);
			return this;
		}

		public ConditionDescriptor GreaterThan(string path, object value)
		{
			Self.Compare = new GreaterThanCondition(path, value);
			return this;
		}

		public ConditionDescriptor GreaterThanOrEqualTo(string path, object value)
		{
			Self.Compare = new GreaterThanOrEqualCondition(path, value);
			return this;
		}

		public ConditionDescriptor LowerThan(string path, object value)
		{
			Self.Compare = new LowerThanCondition(path, value);
			return this;
		}

		public ConditionDescriptor LowerThanOrEqualTo(string path, object value)
		{
			Self.Compare = new LowerThanOrEqualCondition(path, value);
			return this;
		}

	}
}
