using System;
using Newtonsoft.Json;
using Nest.Resolvers.Converters;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(ReadAsTypeConverter<InputContainer>))]
	public interface IInputContainer : INestSerializable
	{
		[JsonProperty("http")]
		IHttpInput Http { get; set; }

		[JsonProperty("search")]
		ISearchInput Search { get; set; }

		[JsonProperty("simple")]
		ISimpleInput Simple { get; set; }
	}

	[JsonObject]
	public class InputContainer : IInputContainer
	{
		public InputContainer() {}

		public InputContainer(InputBase input)
		{
			input.ContainIn(this);
		}

		public InputContainer(ISimpleInput input)
		{
			//edge case because simple input is a dictionary and not a subclass of InputBase
			((IInputContainer) this).Simple = input;
		}

		IHttpInput IInputContainer.Http { get; set; }
		ISearchInput IInputContainer.Search { get; set; }
		ISimpleInput IInputContainer.Simple { get; set; }
	}

	public class InputDescriptor : InputContainer
	{
		private IInputContainer Self { get { return this; } }

		public InputDescriptor Search(Func<SearchInputDescriptor, ISearchInput> selector)
		{
			Self.Search = selector(new SearchInputDescriptor());
			return this;
		}

		public InputDescriptor Http(Func<HttpInputDescriptor, IHttpInput> selector)
		{
			Self.Http = selector(new HttpInputDescriptor());
			return this;
		}
		
		public InputDescriptor Simple(Func<SimpleInputDescriptor, ISimpleInput> selector)
		{
			Self.Simple = selector(new SimpleInputDescriptor());
			return this;
		}
	}
}