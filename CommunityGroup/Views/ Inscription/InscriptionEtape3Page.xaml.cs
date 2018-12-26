using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class InscriptionEtape3Page : ContentView
    {
        public InscriptionEtape3Page()
        {
            InitializeComponent();
        }

        private void Inscription_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Tapped.TappedPagePrincipal());
        }

       

    }
}