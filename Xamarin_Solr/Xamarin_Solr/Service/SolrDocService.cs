using Newtonsoft.Json;
using SolrNetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_Solr.Service
{
    public class SolrDocService
    {

        // Rest API Base Endpoints
        private const string QUERY_BASE_GET_REQUEST = "documentCollection/query?q=";

        public HttpClient RestClient { get; set; }

        public SolrDocService()
        {
            CreateHttpClient();
        }

        private void CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8983/solr/");
            httpClient.Timeout = new TimeSpan(0, 2, 0);
            httpClient.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));

            RestClient = httpClient;
        }

        public void SendQueryRequest_Rest(string endpoint, Model.SolrQuery solrquery)
        {
            var restClient = RestClient;

            System.Diagnostics.Debug.WriteLine("SendQueryRest: Query started");
            // Testing
            // solrquery.Query = "Interstate";

            endpoint = QUERY_BASE_GET_REQUEST + "Interstate";

            var settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            var json = JsonConvert.SerializeObject(solrquery, settings);

            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, endpoint);
            //{
            //    Content = new StringContent(json, Encoding.UTF8, "application/json")
            //};

            var response = restClient.SendAsync(request);

            if (response.Result.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("Sucess: " + response.Result.Content.ReadAsStringAsync().Result);
                var result = response.Result.
            }
        }

        public void SendQueryRequest_SolrNet()
        {
            //TODO
        }
    }
}
