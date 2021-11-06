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
using Raze.Api.Domain.Models;
using Raze.Api.Resources;
using Raze.Api.Resources.CommentResources;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Raze.API.Tests
{
    [Binding]
    public class InterestServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private InterestResource Interest { get; set; }

        public InterestServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/interests is available")]
        public void GivenTheInterestsEndpointIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/interests");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
        }

        [When(@"A Post Request is sent")]
        public void WhenAPostRequestIsSent(Table saveInterestResource)
        {
            var resource = saveInterestResource.CreateSet<SaveInterestResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }
        
        [When(@"A Post Request is sent with title null")]
        public void WhenAPostRequestIsSentWithTitleNull(Table saveInterestResource)
        {
            var resource = saveInterestResource.CreateSet<SaveInterestResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Interest Resource is included in Response Body")]
        public async void ThenAInterestResourceIsIncludedInResponseBody(Table expectedInterestResource)
        {
            var expectedResource = expectedInterestResource.CreateSet<InterestResource>().First();
            expectedResource.Interest = Interest;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<InterestResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }

        [Then(@"A Message of ""(.*)"" is included in Response Body")]
        public async void ThenAMessageIsIncludedInResponseBodyWithValue(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonExpectedMessage = expectedMessage.ToJson();
            var jsonActualMessage = actualMessage.ToJson();
            Assert.Equal(jsonExpectedMessage, jsonActualMessage);
        }
    }
}