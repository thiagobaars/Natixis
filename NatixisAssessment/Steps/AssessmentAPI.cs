using TechTalk.SpecFlow;
using System.Net.Http.Headers;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace NatixisAssessment.StepDefinitions
{
    [Binding]
    public sealed class NatixisAssessment
    {
        private const string URL = "https://corona.lmao.ninja";
        private string Endpoint;
        private string URI;
        HttpResponseMessage response;

        [Given(@"the url and the endpoint '([^']*)'")]
        public void GivenTheUrlAndTheEndpoint(string endpoint)
        {
            Endpoint = endpoint;
            URI = URL + endpoint;
        }

        [When(@"the request is submited")]
        public void WhenTheRequestIsSubmited()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            response = client.GetAsync(URI).Result;
        }

        [Then(@"the response should have status code (.*)")]
        public void ThenTheResponseShouldHaveStatusCode(int StatusCode)
        {
            Assert.AreEqual(StatusCode, (int)response.StatusCode);
        }

        [Then(@"the critical cases should be less than (.*)")]
        public async void ThenTheCriticalCasesShouldBeLessThan(int CriticalCases)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(responseBody);

            Assert.True(int.Parse(json.GetValue("critical").ToString()) < CriticalCases, "Number os critical cases higher than " + CriticalCases);
        }


    }
}