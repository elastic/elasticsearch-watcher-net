using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGeneration.Watcher
{
	class Program
	{
		static void Main(string[] args)
		{
			var spec = ApiGenerator.GetRestApiSpec();

			ApiGenerator.GenerateRequestParameters(spec);
			
			ApiGenerator.GenerateRequestParametersExtensions(spec);
			
			ApiGenerator.GenerateDescriptors(spec);
			
			ApiGenerator.GenerateRequests(spec);

			ApiGenerator.GenerateDispatchExtensions(spec);

			ApiGenerator.GenerateLowLevelExtensions(spec);

			Console.WriteLine("Found {0} api documentation endpoints", spec.Endpoints.Count());
		}
	}
}
