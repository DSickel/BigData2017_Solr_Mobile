using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_Solr.Model;
using Xamarin_Solr.Service;
using Xamarin_Solr.View;

namespace Xamarin_Solr.ViewModel
{
    public class QueryViewModel : BaseViewModel
    {


        private string adv_Query;

        public string Adv_Query
        {
            get { return adv_Query; }
            set
            {
                if (adv_Query != value)
                {
                    adv_Query = value;
                    OnPropertyChanged();
                }

            }
        }

        private string adv_Filter;

        public string Adv_Filter
        {
            get { return adv_Filter; }
            set
            {
                if (adv_Filter != value)
                {
                    adv_Filter = value;
                    OnPropertyChanged();
                }

            }
        }

        private string adv_Facet_Query;

        public string Adv_Facet_Query
        {
            get { return adv_Facet_Query; }
            set
            {
                if (adv_Facet_Query != value)
                {
                    adv_Facet_Query = value;
                    OnPropertyChanged();
                }

            }
        }

        private string adv_Facet_Field;

        public string Adv_Facet_Field
        {
            get { return adv_Facet_Field; }
            set
            {
                if (adv_Facet_Field != value)
                {
                    adv_Facet_Field = value;
                    OnPropertyChanged();
                }

            }
        }

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

        public ObservableCollection<BigDatDocument> ListOfDocuments // Property
        {
            get { return _listOfDocuments; }
            set
            {
                _listOfDocuments = value;
                OnPropertyChanged();
            }
        }

        private SolrQuery _solrQuery;
        public SolrQuery SolrQuery
        {
            get { return _solrQuery; }
            set
            {
                _solrQuery = value;
                OnPropertyChanged();
            }
        }


        public Command SearchCommand
        {
            get
            {
                return new Command(() =>
                {
                    SearchForDocument(SearchText);
                });
            }
        }

        public Command OnAdvancedSearch_Clicked
        {
            get
            {
                return new Command(() =>
                {
                    var page = new AdvancedSearch(this);
                    PopupNavigation.PushAsync(page);
                });
            }
        }

        public Command OnSearch_Clicked
        {
            get
            {
                return new Command(() =>
                {
                    SearchForDocumentAdvanced(adv_Query, adv_Filter, adv_Facet_Field, adv_Facet_Query);
                    PopupNavigation.PopAsync();
                });
            }
        }



        public QueryViewModel()
        {
            Title = "Customer List";
            Icon = "icon.png";
            ListOfDocuments = new ObservableCollection<BigDatDocument>();
            
        }

        private async void SearchForDocument(string term)
        {
            IsBusy = true;
            SolrDocService service = new SolrDocService();
            ListOfDocuments = await service.SendQueryRequest_Rest(term, new SolrQuery());
            IsBusy = false;
        }

        private async void SearchForDocumentAdvanced(string query, string filter, string facet_field, string facet_query)
        {
            IsBusy = true;
            SolrDocService service = new SolrDocService();
            ListOfDocuments = await service.SendQueryRequestAdvanced_Rest(query, filter, facet_field, facet_query);   
            IsBusy = false;
        }
    }
}
