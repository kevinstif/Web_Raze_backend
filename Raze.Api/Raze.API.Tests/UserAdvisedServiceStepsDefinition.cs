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
using Raze.Api.Users.Resources;
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
        private Task<HttpResponseMessage>Response { get; set; }
        private UserAdvisedResource UserAdvised { get; set; }
        private InterestResource Interest { get; set; }
        public UserAdvisedServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/useradviseds is available")]
        public void GivenTheUseradvisedsEndpointIsAvailable(int port, int version)

        {
            BaseUri= new Uri($"https://localhost:{port}/api/v{version}/useradviseds");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"A UserAdvised Request is sent")]
        public void WhenAUserAdvisedRequestIsSent(Table saveUserAdvisedResource)
        {
            var resource = saveUserAdvisedResource.CreateSet<SaveUserAdvisedResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }

        [Given(@"A Interest is already stored")]
        public async void GivenAInterestIsAlreadyStored(Table existingInterestResource)
        {
            var interestUri = new Uri("https://localhost:5001/api/v1/interests");
            var resource = existingInterestResource.CreateSet<SaveInterestResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var interestResponse = Client.PostAsync(interestUri, content);
            var interestResponseData = await interestResponse.Result.Content.ReadAsStringAsync();
            var existingInterest = JsonConvert.DeserializeObject<InterestResource>(interestResponseData);
            Interest = existingInterest;
        }
    }
}