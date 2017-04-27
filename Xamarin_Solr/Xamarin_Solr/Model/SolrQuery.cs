using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_Solr.Model
{
    public class SolrQuery
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
