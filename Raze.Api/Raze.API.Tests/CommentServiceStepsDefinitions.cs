using TechTalk.SpecFlow;

namespace Raze.API.Tests
{
    [Binding]
    public class CommentServiceStepsDefinitions
    {
        [Given(@"The EndPoint https://localhost:(.*)/api/v(.*)/comments is available")]
        public void GivenTheEndPointHttpsLocalhostApiVCommentsIsAvailable(int port, int version)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A Tag is already stored")]
        public void GivenATagIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A Interest is already stored")]
        public void GivenAInterestIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A Advised is already stored")]
        public void GivenAAdvisedIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A Advisor is already stored")]
        public void GivenAAdvisorIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A Post is already stored")]
        public void GivenAPostIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"A Post Request is sent")]
        public void WhenAPostRequestIsSent(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A Status (.*) is received")]
        public void ThenAStatusIsReceived(int p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"Comment Resource is included in Response body")]
        public void ThenCommentResourceIsIncludedInResponseBody(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"Message of ""(.*)"" is included in response body")]
        public void ThenMessageOfIsIncludedInResponseBody(string p0)
        {
            ScenarioContext.StepIsPending();
        }
    }
}