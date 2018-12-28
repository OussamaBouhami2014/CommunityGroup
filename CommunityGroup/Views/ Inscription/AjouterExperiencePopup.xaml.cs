using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class AjouterExperiencePopup : PopupPage
    {
        public AjouterExperiencePopup()
        {
            InitializeComponent();
            PickerDomaine.SelectedIndex = 0;
        }
        private async void Ajouter_Clicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}