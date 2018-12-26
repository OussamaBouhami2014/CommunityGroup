using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CommunityGroup.Views.Inscription
{
    public partial class InscriptionEtape1Page : ContentView
    {
        public InscriptionEtape1Page()
        {
            InitializeComponent();
        }
        private void Inscription_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Tapped.TappedPagePrincipal());
        }
    }
}
