using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
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
        private Uri BaseUrl { get; set; }
        private Task<HttpResponseMessage>Response { get; set; }
        private UserAdvisedResource UserAdvised { get; set; }
        public UserAdvisedServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/useradviseds is available")]
        public void GivenTheUseradvisedsEndpointIsAvailable(int port, int version)

        {
         BaseUrl= new Uri($"https://localhost:{port}/api/v{version}/useradviseds");
         Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUrl});
        }

        [When(@"A UserAdvised Request is sent")]
        public void WhenAUserAdvisedRequestIsSent(Table saveUserAdvisedResource)
        {
            var resource = saveUserAdvisedResource.CreateSet<SaveUserAdvisedResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUrl, content);
        }

        [Then(@"A Reponse with Status (.*) is received")]
        public void ThenAReponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }
    }
}