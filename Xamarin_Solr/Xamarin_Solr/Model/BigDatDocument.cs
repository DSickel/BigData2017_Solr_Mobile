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

        [SolrUniqueKey("id")]
        public string Id { get; set; }

        public string Title { get; set; }

        public int PubDate { get; set; }

        public string Content { get; set; }

    }
}
