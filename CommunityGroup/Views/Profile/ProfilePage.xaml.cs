using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CommunityGroup.Views.Profile
{
    public partial class ProfilePage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        public ProfilePage()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {

        }
        private void Logout_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                Helpers.Settings.ClearSettings();
                Application.Current.MainPage = new NavigationPage(new Views.Login.LoginPage());
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }


    }
}