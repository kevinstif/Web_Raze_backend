using TechTalk.SpecFlow;

namespace Raze.API.Tests
{
    [Binding]
    public class TagServiceStepsDefinition
    {
        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/tags is available")]
        public void GivenTheEndpointHttpsLocalhostApiVTagsIsAvailable(int port, int version)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"A Post Request is sent")]
        public void WhenAPostRequestIsSent(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A Tag Resource is included in response body")]
        public void ThenATagResourceIsIncludedInResponseBody(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A Message of ""(.*)"" is include in response body")]
        public void ThenAMessageOfIsIncludeInResponseBody(string p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A Tag is already stored")]
        public void GivenATagIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }
    }
}