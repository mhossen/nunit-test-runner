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
  }

  [TearDown]
  public void DisposeDriver()
  {
    Driver?.Close();
  }
}