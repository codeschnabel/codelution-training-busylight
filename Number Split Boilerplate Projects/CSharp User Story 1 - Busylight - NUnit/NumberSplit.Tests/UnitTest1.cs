namespace NumberSplit.Tests
{
    [SetUpFixture]
    public class BusyLightIntegration
    {
        [OneTimeTearDown]
        public async Task NotifyBusyLight()
        {
            // Prüfe, ob alle Tests erfolgreich waren
            var result = TestContext.CurrentContext.Result.Outcome.Status;
            string url = result == NUnit.Framework.Interfaces.TestStatus.Passed
                ? "http://localhost:8989/?action=light&red=0&green=255&blue=0"
                : "http://localhost:8989/?action=light&red=255&green=0&blue=0";

            using var client = new HttpClient();
            await client.GetAsync(url);
        }
    }

    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.That(true);
        }
    }
}