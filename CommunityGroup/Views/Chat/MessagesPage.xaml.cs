using System;
using System.Collections.Generic;
using CommunityGroup.Models;
using CommunityGroup.ViewModels;
using Xamarin.Forms;

namespace CommunityGroup.Views.Chat
{
    public partial class MessagesPage : ContentPage
    {
        private ActualiteViewModel Vm;


        public MessagesPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            Vm = new ActualiteViewModel();
            this.BindingContext = Vm;
        }

        private void MessagesListView_Refreshing(object sender, System.EventArgs e)
        {
            MessagesListView.IsRefreshing = false;
        }

        private async void MessagesListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as DtoActualite;
            if (item == null)
                return;

            await Application.Current.MainPage.Navigation.PushAsyncSingle(new Chat.ChatPage());

            ((ListView)sender).SelectedItem = null;
        }

    }
}