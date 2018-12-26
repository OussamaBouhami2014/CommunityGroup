using System;
using Xamarin.Forms;

namespace CommunityGroup.Views.Login
{
    public partial class RolePage : ContentPage
    {
        public RolePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Stagiaire_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsyncSingle(new Login.LoginPage(), true);
        }
    }
}