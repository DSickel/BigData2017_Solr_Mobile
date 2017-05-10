using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_Solr.Model;
using Xamarin_Solr.Service;

namespace Xamarin_Solr.ViewModel
{
    public class QueryViewModel : BaseViewModel
    {

        private string _searchText;

        public string SearchText
        { get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                }

            }
        }

        private ObservableCollection<BigDatDocument> _listOfDocuments; // backing field

        private string _query;

        public string Query {
            get { return _query; }
            set
            {
                _query = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BigDatDocument> ListOfDocuments // Property
        {
            get { return _listOfDocuments; }
            set
            {
                _listOfDocuments = value;
                OnPropertyChanged();
            }
        }


        public Command SearchCommand
        {
            get
            {
                return new Command(() =>
                {
                    SearchForDocument();
                });
            }
        }

        public QueryViewModel()
        {
            Title = "Customer List";
            Icon = "icon.png";
            IsBusy = true;
            ListOfDocuments = new ObservableCollection<BigDatDocument>();
            var docu = new BigDatDocument();
               

        }

        private async void SearchForDocument()
        {
            IsBusy = true;
            SolrDocService service = new SolrDocService();
            ListOfDocuments = await service.SendQueryRequest_Rest("", new SolrQuery());
       
            IsBusy = false;
        }

    }
}
