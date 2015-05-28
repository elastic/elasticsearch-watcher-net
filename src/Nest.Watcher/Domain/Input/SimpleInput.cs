using System.Collections.Generic;
using System.Runtime.InteropServices;
using Nest.Watcher.Serialization;
using Newtonsoft.Json;

namespace Nest
{
	[JsonConverter(typeof(SimpleInputConverter))]
	public interface ISimpleInput : IInput, INestSerializable
	{
		IDictionary<string, object> Payload { get; }
	}

	public class SimpleInput : InputBase, ISimpleInput
	{
		private IDictionary<string, object> _payload;
		public IDictionary<string, object> Payload { get { return _payload; } }

		public SimpleInput() { }

		public SimpleInput(IDictionary<string, object> dict)
			: this()
		{
			this._payload = dict;
		}

		public void Add(string key, object value)
		{
			if (_payload == null) _payload = new Dictionary<string, object>();
			_payload.Add(key, value);
		}
		
		public static implicit operator InputContainer(SimpleInput input)
		{
			if (input == null) return null;
			var c = new InputContainer();
			IInputContainer ic = c;
			ic.Simple = input;
			return c;
		}

		internal override void ContainIn(IInputContainer container)
		{
			container.Simple = this;
		}
	}
	public class SimpleInputDescriptor : ISimpleInput
	{
		private IDictionary<string, object> _payload;

		IDictionary<string, object> ISimpleInput.Payload { get { return _payload; } }

		public SimpleInputDescriptor()
		{
		}

		public SimpleInputDescriptor(IDictionary<string, object> copy)
		{
			this._payload = copy;
		}

		public SimpleInputDescriptor Add(string key, object value)
		{
			if (_payload == null) _payload = new Dictionary<string, object>();
			_payload.Add(key, value);
			return this;
		}
		public SimpleInputDescriptor Remove(string key)
		{
			if (_payload == null) return this;
			_payload.Remove(key);
			return this;
		}
	}
}