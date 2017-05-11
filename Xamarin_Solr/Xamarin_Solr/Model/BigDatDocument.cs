using Newtonsoft.Json;
using SolrNetLight.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_Solr.Model
{
    public class BigDatDocument
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public List<string> Title { get; set; }
        //public string TitleSingle { get; set; }

        [JsonProperty("pub-date")]
        public List<long> PubDate { get; set; }
        //public long PubDateSingle { get; set; }

        [JsonProperty("content")]
        public List<string> Content { get; set; }
        //public string ContentSingle { get; set; }
    }
}
