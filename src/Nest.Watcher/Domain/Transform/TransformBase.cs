using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface ITransform : INestSerializable
	{
	}

	public abstract class TransformBase
	{
		public static implicit operator TransformContainer(TransformBase transform)
		{
			if (transform == null) return null;
			var c = new TransformContainer();
			transform.ContainIn(c);
			return c;
		}

		internal abstract void ContainIn(ITransformContainer container);
	}
}
