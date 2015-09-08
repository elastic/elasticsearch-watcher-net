using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface IEmailAction : IAction
	{
		[JsonProperty("account")]
		string Account { get; set; }
		[JsonProperty("from")]
		string From { get; set; }
		[JsonProperty("to")]
		IEnumerable<string> To { get; set; }
		[JsonProperty("cc")]
		string Cc { get; set; }
		[JsonProperty("bcc")]
		string Bcc { get; set; }
		[JsonProperty("reply_to")]
		IEnumerable<string> ReplyTo { get; set; }
		[JsonProperty("subject")]
		string Subject { get; set; }
		[JsonProperty("body")]
		EmailBody Body { get; set; }
		[JsonProperty("priority")]
		EmailPriority? Priority { get; set; }
		[JsonProperty("attach_data")]
		object AttachData { get; set; }

	}

	[JsonObject]
	public class EmailBody
	{
		[JsonProperty("text")]
		public string Text { get; set; }
		[JsonProperty("html")]
		public string Html { get; set; }
	}

	public class EmailAction : Action, IEmailAction
	{
		public string Account { get; set; }
		public string From { get; set; }
		public IEnumerable<string> To { get; set; }
		public string Cc { get; set; }
		public string Bcc { get; set; }
		public IEnumerable<string> ReplyTo { get; set; }
		public string Subject { get; set; }
		public EmailBody Body { get; set; }
		public EmailPriority? Priority { get; set; }
		public object AttachData { get; set; }
	}

	public class EmailResult
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		
		[JsonProperty("sent_date")]
		public DateTime? SentDate { get; set; }
		
		[JsonProperty("from")]
		public string From { get; set; }

		[JsonProperty("to")]
		public IEnumerable<string> To { get; set; }

		[JsonProperty("cc")]
		public IEnumerable<string> Cc { get; set; }

		[JsonProperty("bcc")]
		public string Bcc { get; set; }

		[JsonProperty("reply_to")]
		public IEnumerable<string> ReplyTo { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }

		[JsonProperty("body")]
		public EmailBody Body { get; set; }

		[JsonProperty("priority")]
		public EmailPriority? Priority { get; set; }

	}

}
