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
    public class PostServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private InterestResource Interest { get; set; }
        private TagResource Tag { get; set; }
        private UserAdvisedResource User { get; set; }
        private PostResource Post { get; set; }

        public PostServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/posts is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPostsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/posts");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
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

        [Given(@"A Tag is already stored")]
        public async void GivenATagIsAlreadyStored(Table existingTagResource)
        {
            var tagUri = new Uri("https://localhost:5001/api/v1/tags");
            var resource = existingTagResource.CreateSet<SaveTagResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var tagResponse = Client.PostAsync(tagUri, content);
            var tagResponseData = await tagResponse.Result.Content.ReadAsStringAsync();
            var existingTag = JsonConvert.DeserializeObject<TagResource>(tagResponseData);
            Tag = existingTag;
        }

        [Given(@"A User is already stored")]
        public async void GivenAUserIsAlreadyStored(Table existingUserResource)
        {
            var userUri = new Uri("https://localhost:5001/api/v1/usersadviseds");
            var resource = existingUserResource.CreateSet<SaveUserAdvisedResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var userResponse = Client.PostAsync(userUri, content);
            var userResponseData = await userResponse.Result.Content.ReadAsStringAsync();
            var existingUser = JsonConvert.DeserializeObject<UserAdvisedResource>(userResponseData);
            User = existingUser;
        }

        [Given(@"A Post is already stored")]
        public async void GivenAPostIsAlreadyStored(Table existingPostResource)
        {
            var postUri = new Uri("https://localhost:5001/api/v1/posts");
            var resource = existingPostResource.CreateSet<SavePostResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var postResponse = Client.PostAsync(postUri, content);
            var postResponseData = await postResponse.Result.Content.ReadAsStringAsync();
            var existingPost = JsonConvert.DeserializeObject<PostResource>(postResponseData);
            Post = existingPost;
        }

        [When(@"A Post Request is Sent")]
        public void WhenAPostRequestIsSent(Table savePostResource)
        {
            var resource = savePostResource.CreateSet<SavePostResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }
        
        [Then(@"A Response with status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Post Resource is included in Response Body")]
        public async void ThenAPostResourceIsIncludedInResponseBody(Table expectedPostResource)
        {
            var expectedResource = expectedPostResource.CreateSet<PostResource>().First();
            //expectedResource.Tag = Tag;
            //expectedResource.Interest = Interest;
            //expectedResource.UserAdvised = User;
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<PostResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }

        [Then(@"A Message of ""(.*)"" is included in Response Body")]
        public async void ThenAMessageOfIsIncludedInResponseBody(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonExpectedMessage = expectedMessage.ToJson();
            var jsonActualMessage = actualMessage.ToJson();
            Assert.Equal(jsonExpectedMessage, jsonActualMessage);
        }
        
    }
}