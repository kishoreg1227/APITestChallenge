using APITestChallenge.Utilities;
using NUnit.Framework;

namespace APITestChallenge.Tests
{
    [TestFixture]
    public class TestBase
    {
        public RestManager RestManager { get; private set; }

        [SetUp]
        public void Initialize()
        {
            RestManager = new RestManager();
        }

        [TearDown]
        public void CleanUp()
        {
            RestManager = null;
        }
    }
}