using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class InscriptionEtape2Page : ContentView
    {
        public InscriptionEtape2Page()
        {
            InitializeComponent();
        }

        private void Inscription_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Tapped.TappedPagePrincipal());
        }
    }
}