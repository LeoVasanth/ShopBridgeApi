using System;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;
using Moq;
using Moq.Protected;
using System.Threading;
using FakeItEasy;
using System.Net.Http.Headers;
using FakeItEasy.Sdk;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using ShopBridgeApi;
using ShopBridgeApi.Models;
using ShopBridgeApi.Controllers;

namespace ShopBridgeTest
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
       
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Content as string")
            };

            return await Task.FromResult(responseMessage);

        }
    }

    public class ShopBridgeTest
    {
        public readonly HttpClient client;
        public ShopBridgeTest()
        {
            var webhhostbuild = new WebHostBuilder().UseStartup<Startup>();
            client = new TestServer(webhhostbuild).CreateClient();

        }
        [Fact]
        public async Task TestGetAllItems()
        {
           
            var httpClient = new HttpClient(new MockHttpMessageHandler());

            var response = await httpClient.GetAsync("https://localhost/api/items");

            

            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.StatusCode);
            Assert.Equal( 200,Convert.ToInt64 (response.StatusCode)) ;
        }
        [Fact]
        public async Task TestGetSepcificItems()
        {

            var httpClient = new HttpClient(new MockHttpMessageHandler());

            var response = await httpClient.GetAsync("https://localhost/api/items/1");

            

            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestpostItems()
        {

            var client = new HttpClient(new MockHttpMessageHandler());

            client.BaseAddress = new Uri("http://localhost/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            var response = await client.PostAsync("https://localhost/api/items/1", new StringContent(
                JsonConvert.SerializeObject(new Item() { ItemId = 3, Name = "Test", Description = "test item", Price = 34.33, Stock = 3 })));

            

            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestPutItems()
        {

            var client = new HttpClient(new MockHttpMessageHandler());

            client.BaseAddress = new Uri("http://localhost/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
          
            var response = await client.PutAsync("https://localhost/api/items/2", new StringContent(
                JsonConvert.SerializeObject(new Item() { ItemId = 2, Name = "Test1", Description = "test1 item", Price = 34.33, Stock = 3 })));

            

            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.StatusCode);
            Assert.Equal(200, Convert.ToInt64(response.StatusCode));
        }

        [Fact]
        public async Task TestDeleteItems()
        {

            var client = new HttpClient(new MockHttpMessageHandler());

            client.BaseAddress = new Uri("http://localhost/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.DeleteAsync("https://localhost/api/items/2");

            

            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.StatusCode);
            Assert.Equal(200, Convert.ToInt64(response.StatusCode));
        }
    }
}
