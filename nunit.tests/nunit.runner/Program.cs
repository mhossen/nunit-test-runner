// See https://aka.ms/new-console-template for more information

using nunit.tests;


var engine = TestEngineActivator.CreateInstance();
var package = new TestPackage($"{TestAssemblyReference.AssemblyName}.dll");
var filterBuilder = engine.Services.GetService(typeof(TestFilterService)) as ITestFilterService;
var builder = filterBuilder?.GetTestFilterBuilder();

foreach (var testName in TestAssemblyReference.TestNames)
{
  builder?.AddTest(testName);
}


// builder?.AddTest("nunit.tests.ChromeTests.AnotherGoogleTest");
// builder?.SelectWhere("cat == ui");
// builder?.SelectWhere("test =~ AmazonTest || test=~ GoogleTest");
var runner = engine.GetRunner(package);
// engine.Services.GetService<SettingsService>().
var filters = builder?.GetFilter();


var testResult = runner.Run(listener: null, new TestFilter(filters?.Text));

var testCount = runner.CountTestCases(TestFilter.Empty);
Console.WriteLine($"Total test count: {testCount}");
var explore = runner.Explore(new TestFilter(filters?.Text));
// Console.WriteLine(explore.OuterXml);
Console.WriteLine("=====================================>");
Console.WriteLine(filters?.Text);
Console.WriteLine(testResult.OuterXml);


Console.WriteLine("=====================================>");
Console.WriteLine("=====================================>");

Console.WriteLine(explore.OuterXml);
runner.StopRun(true);
engine.Dispose();