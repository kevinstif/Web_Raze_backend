using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Raze.Api;
using Raze.Api.Resources;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Raze.API.Tests
{
    [Binding]
    public class UserAdvisedServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private InterestResource Interest { get; set; }
        private Task<HttpResponseMessage>Response { get; set; }
        private UserAdvisedResource UserAdvised{ get; set; }
        public UserAdvisedServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/useradviseds is available")]
        public void GivenTheEndpointHttpsLocalhostApiVUseradvisedsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/useradviseds");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
            ScenarioContext.StepIsPending();
        }

        [When(@"A UserAdvised Request is Sent")]
        public void WhenAUserAdvisedRequestIsSent(Table saveUserAdvisedResource)
        {
            var resources = saveUserAdvisedResource.CreateSet<SaveUserAdvisedResource>().First();
            var content = new StringContent(resources.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A UserAdvised Resource is included in Response Body")]
        public async void ThenAUserAdvisedResourceIsIncludedInResponseBody(Table expectedUserAdvisedResource)
        {
            var expectedResources = expectedUserAdvisedResource.CreateSet<UserAdvisedResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<UserAdvisedResource>(responseData);
            expectedResources.Id = resource.Id;
            var jsonExpectedResources = expectedResources.ToJson();
            var jsonActualResources = resource.ToJson();
            Assert.Equal(jsonExpectedResources,jsonActualResources);
        }

        [Given(@"Interest is already stored")]
        public async void GivenInterestIsAlreadyStored(Table existingInterestResource)
        {
            var interestUri = new Uri("https://localhost:5001/api/v1/interests");
            var resource = existingInterestResource.CreateSet<SaveInterestResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var interestResponse = Client.PostAsync(interestUri, content);
            var interestResponseData = await interestResponse.Result.Content.ReadAsStringAsync();
            var existingInterest = JsonConvert.DeserializeObject<InterestResource>(interestResponseData);
            Interest = existingInterest;
        }

        [Then(@"Response with status (.*) is received")]
        public void ThenResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"Message of ""(.*)"" is included in Response")]
        public async void ThenMessageOfIsIncludedInResponse(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonExpectedMessage = expectedMessage.ToJson();
            
            Assert.Equal(jsonExpectedMessage, actualMessage);
        }
    }
}