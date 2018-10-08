using APITestChallenge.Utilities;
using TechTalk.SpecFlow;

namespace APITestChallenge.Tests
{
    [Binding]
    public class BDDTestBase
    {
        public RestManager RestManager { get; private set; }

        [BeforeScenario]
        public void Initialize()
        {
            RestManager = new RestManager();
        }

        [AfterScenario]
        public void CleanUp()
        {
            RestManager = null;
        }
    }
}