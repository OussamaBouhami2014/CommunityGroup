using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace CommunityGroup.Views.Actualite
{
    public partial class ActualiteFilterPopup : PopupPage
    {
        public ActualiteFilterPopup()
        {
            InitializeComponent();

            var ListRadioButton = new Dictionary<string, bool>();

            ListRadioButton.Add("News", false);
            ListRadioButton.Add("Offres", false);
            rdGroup.CGRItemsSource = ListRadioButton;
        }

        private async void ApliquerFilters_Clicked(object sender, System.EventArgs e)
        {
   

            await PopupNavigation.Instance.PopAsync();
        }
    }


}
