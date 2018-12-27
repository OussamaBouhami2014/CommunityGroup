using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class InscriptionCompletePopup : PopupPage
    {
        public InscriptionCompletePopup()
        {
            InitializeComponent();
        }

        private async void Envoyer_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Login.LoginPage());
            await PopupNavigation.Instance.PopAsync();
        }
    }
}