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
        private const string ENDPOINT = "http://192.168.178.157:8983/solr/";
        private const string BASE = "documentCollection/query";
        private const string QUERY = "?q=";
        private const string FILTER_QUERY = "&fg=";
        private const string FACET_QUERY = "&facet.query=";
        private const string FACET_FIELD = "&facet.field=";

        public HttpClient RestClient { get; set; }

        public SolrDocService()
        {
            CreateHttpClient();
        }

        private void CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ENDPOINT);
            httpClient.Timeout = new TimeSpan(0, 2, 0);
            httpClient.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));
            System.Diagnostics.Debug.WriteLine("Vlient created");
            RestClient = httpClient;
        }

        public async Task<ObservableCollection<BigDatDocument>> SendQueryRequest_Rest(string term, Model.SolrQuery solrquery)
        {
            var restClient = RestClient;

            try
            {
                var endpoint = BASE + QUERY + term;
                var requestUri = Uri.EscapeUriString(endpoint);

                System.Diagnostics.Debug.WriteLine("SendQueryRest: Query started");

                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;

                var method = new HttpMethod("GET");
                
                var request = new HttpRequestMessage(method, endpoint);

                var response = await restClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                { 
                    System.Diagnostics.Debug.WriteLine("Sucess: " + response.Content.ReadAsStringAsync().Result);
                    var json = response.Content.ReadAsStringAsync().Result;
                    var jsonValue = JObject.Parse(json)["response"]["docs"];
                    var objectList = JsonConvert.DeserializeObject<ObservableCollection<BigDatDocument>>(jsonValue.ToString());
                    return objectList;
                } 

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<ObservableCollection<BigDatDocument>> SendQueryRequestAdvanced_Rest(string query, string filter, string facet_field, string facet_query)
        {
            var restClient = RestClient;

            try
            {
                
                var endpoint = BASE + QUERY + query;

                if(filter != null)
                {
                    endpoint = endpoint + FILTER_QUERY + filter;
                }

                if(facet_field != null)
                {
                    endpoint = endpoint + FACET_FIELD + facet_field;
                }

                if(facet_query != null)
                {
                    endpoint = endpoint + FACET_QUERY + facet_query;
                }

                var requestUri = Uri.EscapeUriString(endpoint);

                System.Diagnostics.Debug.WriteLine("SendQueryRest: Query started");

                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;

                var method = new HttpMethod("GET");

                var request = new HttpRequestMessage(method, endpoint);

                var response = await restClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine("Sucess: " + response.Content.ReadAsStringAsync().Result);
                    var json = response.Content.ReadAsStringAsync().Result;
                    var jsonValue = JObject.Parse(json)["response"]["docs"];
                    var objectList = JsonConvert.DeserializeObject<ObservableCollection<BigDatDocument>>(jsonValue.ToString());
                    return objectList;
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return null;
        }

    }
}
