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
    public class TagServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private TagResource Tag { get; set; }

        public TagServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/tags is available")]
        public void GivenTheTagsEndpointIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/{version}/tags");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"A Post Request is sent")]
        public void WhenAPostRequestIsSent(Table saveTagResource)
        {
            var resources = saveTagResource.CreateSet<SaveTagResource>().First();
            var content = new StringContent(resources.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode,actualStatusCode);
        }

        [Then(@"A Tag Resource is included in response body")]
        public async void ThenATagResourceIsIncludedInResponseBody(Table expectedTagResource)
        {
            var expectedResources = expectedTagResource.CreateSet<TagResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<TagResource>(responseData);
            expectedResources.Id = resource.Id;
            var jsonExpectedResources = expectedResources.ToJson();
            var jsonActualResources = resource.ToJson();
            Assert.Equal(jsonExpectedResources,jsonActualResources);
        }

        [Then(@"A Message of ""(.*)"" is include in response body")]
        public async void ThenAMessageOfIsIncludeInResponseBodyWithValue(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonExpectedMessage = expectedMessage.ToJson();
            Assert.Equal(jsonExpectedMessage,actualMessage);
        }

        [Given(@"A Tag is already stored")]
        public async void GivenATagIsAlreadyStored(Table existingTagResources)
        {
            var resources = existingTagResources.CreateSet<SaveTagResource>().First();
            var content = new StringContent(resources.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var tagResponse = Client.PostAsync(BaseUri, content);
            var tagResponseData = await tagResponse.Result.Content.ReadAsStringAsync();
            var existingTag = JsonConvert.DeserializeObject<TagResource>(tagResponseData);
            Tag = existingTag;
        }
    }
}