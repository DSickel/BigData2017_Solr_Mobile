using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin_Solr.CustomControl;
using Xamarin_Solr.ViewModel;

namespace Xamarin_Solr.View
{
    public partial class AdvancedSearch : PopupPage
    {

        BaseViewModel viewModel;

        public AdvancedSearch(BaseViewModel baseViewModel)
        {
            InitializeComponent();
            
            viewModel = baseViewModel;
            BindingContext = viewModel;
            Animation = new PopUpAnimation();
        }

        public async void OnCancel_Clicked(object sender, EventArgs args)
        {
            await Navigation.PopPopupAsync();
        }
    }
}
