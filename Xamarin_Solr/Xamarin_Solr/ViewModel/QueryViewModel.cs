using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_Solr.Model;

namespace Xamarin_Solr.ViewModel
{
    public class QueryViewModel : BaseViewModel
    {
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

        public QueryViewModel()
        {
            Title = "Customer List";
            Icon = "icon.png";
            IsBusy = true;

        }
    }
}
