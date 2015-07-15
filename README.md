# elasticsearch-watcher-net

Repository for the Elasticsearch Watcher extension library for [NEST](https://github.com/elastic/elasticsearch-net/tree/master/src/Nest#nest-).

[![elasticsearch-net MyGet Build Status](https://www.myget.org/BuildSource/Badge/elasticsearch-net?identifier=c7c303f7-2e2c-48dc-9c01-88975eeac6b2)](https://www.myget.org/)

[Watcher](https://www.elastic.co/products/watcher) is a plugin for Elasticsearch that provides alerting and notifications based on changes in your data. This library extends NEST, allowing you to interface with the Watcher plugin.

## Installation

```
PM> Install-Package Nest.Watcher -IncludePrerelease
```

## Compatibility Matrix

| NEST.Watcher | NEST | Watcher |
| --------------------- | ------------------------ | ------------------------ |
| 1.0.0-beta1   | ≥ 1.5.1 | 1.0.0-Beta1 |
| 1.0.0-beta2	| ≥ 1.5.1 | 1.0.0

## Usage

Once the package is installed, there is no need to include any additional namespaces as the extension methods are part of the `Nest` namespace and will immediately become available on any `ElasticClient` instance.

### Put watch example

```csharp
var client = new ElasticClient();

var response = client.PutWatch("my-watch", p => p
		.Trigger(t => t
			.Schedule(s => s
				.Hourly(h => h
					.Minute(0, 15)
				)
			)
		)
		.Input(i => i
			.Search(srch => srch
				.Request(r => r
					.Body<object>(b => b
						.MatchAll()
					)
				)
			)
		)
		.Condition(c => c.Always())	
		.Actions(a => a
			.Add("test_index", new IndexAction { Index = "my-index", DocType = "my-type" })
		)
```

Just like the core NEST client, an object initializer syntax is also available for **all** Watcher API methods:

```csharp
var request = new PutWatchRequest(watchId)
	{
		Trigger = new TriggerContainer
		{
			Schedule = new ScheduleContainer(
				new HourlySchedule
				{
					Minute = new int[] { 0, 15 }
				}
			)
		},
		Input = new SearchInput
		{
			Request = new SearchInputRequest
			{
				Body = new SearchRequest { Query = new QueryContainer(new MatchAllQuery()) }
			}
		},
		Condition = new AlwaysCondition(),
		Actions = new Dictionary<string, IAction>
		{
			{ "test_index", new IndexAction { Index = "my-index", DocType = "my-type" } }
		}
	};

var response = client.PutWatch(request);
```

...and async support for all methods as well:

```
var response = client.PutWatchAsync(request);
```

### Getting a watch

```csharp
var response = client.GetWatch("my-watch");
```

### Executing a watch

```csharp
var response = client.ExecuteWatch("my-watch", w => w
		.TriggerEvent(t => t
			.Schedule(schd => schd
				.ScheduledTime(new DateTime(2015, 05, 05, 20, 58, 02))
				.TriggeredTime(new DateTime(2015, 05, 05, 20, 58, 02))
			)
		)
		.AlternativeInput(i => i
			.Add("foo", "bar")
		)
		.IgnoreCondition()
		.RecordExecution(true)
	);
```

### More examples

See [the tests](https://github.com/elastic/elasticsearch-watcher-net/tree/master/src/Tests/Nest.Watcher.Tests.Integration) for more examples.  Also, refer to the official [Watcher documentation](https://www.elastic.co/guide/en/watcher/current/index.html) for the full API.

## License

This software is Copyright (c) 2014-2015 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0.](license.txt)