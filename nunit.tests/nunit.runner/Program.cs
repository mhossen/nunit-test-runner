// See https://aka.ms/new-console-template for more information

using NUnit.Engine.Services;

var engine = TestEngineActivator.CreateInstance();
var package = new TestPackage($"nunit.tests.dll");
var filterBuilder = engine.Services.GetService(typeof(TestFilterService)) as ITestFilterService;
var builder = filterBuilder?.GetTestFilterBuilder();
// builder?.AddTest("nunit.tests.ChromeTests.AnotherGoogleTest");
// builder?.SelectWhere("cat == ui");
builder?.SelectWhere("test =~ AmazonTest || test=~ GoogleTest");
var runner = engine.GetRunner(package);
// engine.Services.GetService<SettingsService>().
// filterBuilder?.GetTestFilterBuilder().SelectWhere("test==CheckCurrentUrlIsGoogle");
var filters = builder?.GetFilter();


// var filters = new ServiceContext().GetService<TestFilterService>().GetTestFilterBuilder().GetFilter();
var testResult = runner.Run(listener: null, new TestFilter(filters?.Text));

var testCount = runner.CountTestCases(TestFilter.Empty);
// Console.WriteLine($"Total test count: {testCount}");
var explore = runner.Explore(new TestFilter(filters?.Text));
// Console.WriteLine(explore.OuterXml);
Console.WriteLine("=====================================>");
Console.WriteLine(filters.Text);
Console.WriteLine(testResult.OuterXml);
// testResult.
// Console.ReadKey();