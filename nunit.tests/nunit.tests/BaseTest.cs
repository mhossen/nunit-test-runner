namespace nunit.tests;

[SetUpFixture]
public abstract class BaseTest
{
  protected IWebDriver? Driver;

  [SetUp]
  public void Setup()
  {
    new DriverManager().SetUpDriver(new ChromeConfig());
    Driver = new ChromeDriver();
    Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
    Driver.Manage().Window.Maximize();
  }

  [TearDown]
  public void DisposeDriver()
  {
    Driver?.Close();
  }
}