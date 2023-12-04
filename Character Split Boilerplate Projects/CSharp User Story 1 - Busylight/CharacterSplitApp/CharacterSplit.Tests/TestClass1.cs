using Xunit;

// we need this once
[assembly: TestFramework("CodelutionXUnitTestFramework.CodelutionTestFramework", "CodelutionXUnitTestFramework")]

namespace CharacterSplit.Tests
{
    // we need this for every test class
    [Collection("Default")]
    public class TestClass1
    {
        public TestClass1()
        {
            
        }

        [Fact]
        public void Some_Example_Test()
        {
            Assert.True(true);
        }

    }
}
