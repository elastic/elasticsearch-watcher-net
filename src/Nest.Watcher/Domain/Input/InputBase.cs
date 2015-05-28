using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;

namespace Nest
{

	[JsonObject]
	public interface IInput 
	{
	}

	public abstract class InputBase 
	{
		public static implicit operator InputContainer(InputBase input)
		{
			if (input == null) return null;
			var c = new InputContainer();
			input.ContainIn(c);
			return c;
		}

		internal abstract void ContainIn(IInputContainer container);
	}
}
