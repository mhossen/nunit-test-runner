namespace nunit.tests;

[TestFixture]
public class AmazonTests : BaseTest
{
  [Test]
  [Order(1)]
  [Category("amazon")]
  [Category("ui")]
  public void AmazonTest()
  {
    Driver?.Navigate().GoToUrl("https://amazon.com/");
    Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
    Console.WriteLine($"this is from the second url {Driver?.Url}");
    Driver?.Url.ToLower().Should().Contain("amazon");
  }
}