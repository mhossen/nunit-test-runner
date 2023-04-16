namespace nunit.tests;

[TestFixture]
public class ChromeTests : BaseTest
{
  [Test]
  [Order(0)]
  [Category("google")]
  [Category("ui")]
  public void GoogleTest()
  {
    Driver?.Navigate().GoToUrl("https://google.com");
    Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
    Console.WriteLine(Driver?.Url);
    Driver?.Url.ToLower().Should().Contain("google");
  }


}