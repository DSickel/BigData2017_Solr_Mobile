using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SolrNetLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin_Solr.Model;

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
            httpClient.BaseAddress = new Uri("http://192.168.43.194:8983/solr/documentCollection/query?q=Interstate");
            httpClient.Timeout = new TimeSpan(0, 2, 0);
            httpClient.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));

            RestClient = httpClient;
        }

        public async Task<ObservableCollection<BigDatDocument>> SendQueryRequest_Rest(string endpoint, Model.SolrQuery solrquery)
        {
            var restClient = RestClient;

            try
            {
               // endpoint = QUERY_BASE_GET_REQUEST + "Interstate";
                var requestUri = Uri.EscapeUriString(endpoint);

                System.Diagnostics.Debug.WriteLine("SendQueryRest: Query started");

                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;

                var method = new HttpMethod("GET");
                
                var request = new HttpRequestMessage(method, endpoint);

                var response = await restClient.SendAsync(request);
               
                    System.Diagnostics.Debug.WriteLine("Sucess: " + response.Content.ReadAsStringAsync().Result);
                    var json = response.Content.ReadAsStringAsync().Result;
                    var jsonValue = JObject.Parse(json)["response"]["docs"];
                    var objectList = JsonConvert.DeserializeObject<ObservableCollection<BigDatDocument>>(jsonValue.ToString());
                    return objectList;
                
          
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return null;
        }

        public void SendQueryRequest_SolrNet()
        {
            //TODO
        }
    }
}
