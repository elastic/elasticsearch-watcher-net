using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elasticsearch.Net;
using NUnit.Framework;

namespace Nest.Watcher.Tests.Unit.Put
{
	[TestFixture]
	public class PutInputJsonTests : UnitTest
	{
		[Test]
		public void SearchInput()
		{
			var expectedRequest = new 
			{
				input = new {
					search = new {
						request = new {
							indices = new [] { "a", "b"},
							types = new [] { "c", "d"},
							search_type = "count",
							indices_options = new
							{
								expand_wildcards= "closed",
								ignore_unavailable = true,
								allow_no_indices = true,
							},
							body = new {
								query = new {
									match_all = new {}
								}
							}
						}
					}
				}
			};
			var response = this.Client.PutWatch("some-watch", p => p
				.Input(i => i
					.Search(si => si
						.Request(r => r
							.SearchType(SearchType.Count)
							.Indices("a", "b")
							.IndicesOptions(o=>o
								.ExpandWildcards(ExpandWildcards.Closed)
								.AllowNoIndices()
								.IgnoreUnavailable()
							)
							.Types("c", "d")
							.Body<object>(b => b
								.MatchAll()
							)
						)
					)
				)
			);
			this.JsonEquals(expectedRequest, response);
		}

		[Test]
		public void HtppInput()
		{
			var expectedRequest = new 
			{
				input = new {
					http = new {
						extract = new [] { "x"},
						request = new {
							scheme = "https",
							port = 8080,
							host= "test.example",
							path = "/path",
							method = "post",
							headers = new { x =  "y"},
							@params = new { q =  "a"},
							auth = new { basic = new {username = "u", password = "p" }},
							body = "body",
						}
					}
				}
			};
			var response = this.Client.PutWatch("some-watch", p => p
				.Input(i => i
					.Http(h=>h
						.Extract("x")
						.Request(r=>r
							.Authentication(a=>a
								.Basic(b=>b
									.Password("p")
									.Username("u")
								)
							)
							.Body("body")
							.Headers(headers=>headers
								.Add("x", "y")
							)
							.Path("/path")
							.Host("test.example")
							.Params(param=>param
								.Add("q", "a")
							)
							.Method(HttpMethod.Post)
							.Port(8080)
							.Scheme(ConnectionScheme.Https)
						)
					)
				)
			);
			this.JsonEquals(expectedRequest, response);
		}
		
		[Test]
		public void SimpleInput()
		{
			var expectedRequest = new 
			{
				input = new {
					simple = new Dictionary<string, object>
					{
						{ "x", "y" }, 
						{ "VerbaTim3" , "please" }
					}
				}
			};
			var response = this.Client.PutWatch("some-watch", p => p
				.Input(i => i
					.Simple(h=>h
						.Add("x", "y")
						.Add("VerbaTim3", "please")
					)
				)
			);
			this.JsonEquals(expectedRequest, response);
		}
		

	}
}
