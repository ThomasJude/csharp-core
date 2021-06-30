
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThomasJude.Core.HttpClient;

namespace ThomasJude.Tests.IntegrationTests
{
    [TestClass]
    public class HttpClientAdapterTests
    {
        [TestMethod]
        public async Task GetAsync_ValidUrl_ContentIsJson()
        {
            // arrange
            IHttpClient http = new HttpClientAdapter("https://jsonplaceholder.typicode.com");

            // act
            var result = await http.GetAsync("/todos/1");

            // assert
            Assert.AreEqual(@"{
  ""userId"": 1,
  ""id"": 1,
  ""title"": ""delectus aut autem"",
  ""completed"": false
}", result.Content);
        }
        [TestMethod]
        public async Task GetAsync_ValidUrl_StatusCodeOK()
        {
            // arrange
            IHttpClient http = new HttpClientAdapter("https://jsonplaceholder.typicode.com");

            // act
            var result = await http.GetAsync("/todos/1");

            // assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
        [TestMethod]
        public async Task GetAsync_ValidUrl_ReturnsSomeHeaders()
        {
            // arrange
            IHttpClient http = new HttpClientAdapter("https://jsonplaceholder.typicode.com");

            // act
            var result = await http.GetAsync("/todos/1");

            // assert
            var headers = result.Headers.ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(23, headers.Count());
        }
    }
}
