using TechTalk.SpecFlow;

namespace Raze.API.Tests
{
    [Binding]
    public class InterestServiceStepsDefinition
    {
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/interests is available")]
        public void GivenTheEndpointHttpsLocalhostApiVInterestsIsAvailable(int port, int version)
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

        [Then(@"A Interest Resource is included in Response Body")]
        public void ThenAInterestResourceIsIncludedInResponseBody(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A Message of ""(.*)"" is included in Response Body")]
        public void ThenAMessageOfIsIncludedInResponseBody(string p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A Interest with the same Title already exists")]
        public void GivenAInterestWithTheSameTitleAlreadyExists(Table table)
        {
            ScenarioContext.StepIsPending();
        }
    }
}