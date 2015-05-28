using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nest.Watcher.Serialization;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(CompareConditionConverter))]
	public interface ICompareCondition : ICondition
	{
		string Path { get; set; }
		string Comparison { get; }
		object Value { get; set; }

	}
	
	public abstract class CompareCondition : ConditionBase, ICompareCondition
	{
		private ICompareCondition Self { get { return this; } }

		protected CompareCondition(string path, object value)
		{
			Self.Path = path;
			Self.Value = value;
		}

		string ICompareCondition.Path { get; set; }
		object ICompareCondition.Value { get; set; }
		string ICompareCondition.Comparison { get { return this.Comparison; } }

		protected abstract string Comparison { get; }

		internal override void ContainIn(IConditionContainer container)
		{
			container.Compare = this;
		}
	}

	public class EqualCondition : CompareCondition
	{
		protected override string Comparison { get { return "eq"; } }

		public EqualCondition(string path, object value) : base(path, value) { }
	}

	public class NotEqualCondition : CompareCondition
	{
		protected override string Comparison { get { return "not_eq"; } }

		public NotEqualCondition(string path, object value) : base(path, value) { }
	}

	public class GreaterThanCondition : CompareCondition
	{
		protected override string Comparison { get { return "gt"; } }

		public GreaterThanCondition(string path, object value) : base(path, value) { }
	}

	public class GreaterThanOrEqualCondition : CompareCondition
	{
		protected override string Comparison { get { return "gte"; } }

		public GreaterThanOrEqualCondition(string path, object value) : base(path, value) { }
	}

	public class LowerThanCondition : CompareCondition
	{
		protected override string Comparison { get { return "lt"; } }

		public LowerThanCondition(string path, object value) : base(path, value) { }
	}

	public class LowerThanOrEqualCondition : CompareCondition
	{
		protected override string Comparison { get { return "lte"; } }

		public LowerThanOrEqualCondition(string path, object value) : base(path, value) { }
	}

}
