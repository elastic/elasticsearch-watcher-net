using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using NUnit.Framework;

namespace Nest.Watcher.Tests.Unit.Put
{
	[TestFixture]
	public class PathActionJsonTests : UnitTest
	{
		[Test]
		public void EmailAction()
		{
			var expectedRequest = new
			{
				actions = new
				{
					emailSomeone = new
					{
						email = new
						{
							account = "account",
							from = "from",
							to = new [] {"to"},
							cc = "cc",
							bcc = "dotnet@test.example",
							reply_to = new [] { "replyto" },
							subject = "subject",
							body = new { html = "x" },
							priority = "high",
							attach_data = new { x = 1, y = "x" },
							transform = new
							{
								script = new { inline = "inline" }
							}
						}
					}
				}
			};
			var response = this.Client.PutWatch("some-watch", p => p
				.Actions(a => a
					.Add("emailSomeone", new EmailAction
					{
						Account = "account",
						AttachData = new { x = 1, y = "x" },
						Bcc = "dotnet@test.example",
						Body = new EmailBody { Html = "x" },
						Cc = "cc",
						From = "from",
						Priority = EmailPriority.High,
						ReplyTo = new [] { "replyto" },
						Subject = "subject",
						To = new [] {"to"},
						Transform = new ScriptTransform
						{
							Inline = "inline"
						}
					})
				)
			);
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void LogAction()
		{
			var expectedRequest = new
			{
				actions = new
				{
					logSomething = new
					{
						logging = new
						{
							text = "text",
							category = "category",
							level = "debug",
							transform = new
							{
								script = new { inline = "inline" }
							}
						}
					}
				}
			};
			var response = this.Client.PutWatch("some-watch", p => p
				.Actions(a => a
					.Add("logSomething", new LoggingAction
					{
						Text = "text",
						Category = "category",
						Level =  LogLevel.Debug,
						Transform = new ScriptTransform
						{
							Inline = "inline"
						}
					})
				)
			);
			this.JsonEquals(expectedRequest, response);
		}

	}
}
