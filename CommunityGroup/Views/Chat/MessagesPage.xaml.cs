using System;
using System.Collections.Generic;
using CommunityGroup.Models;
using CommunityGroup.ViewModels;
using Xamarin.Forms;

namespace CommunityGroup.Views.Chat
{
    public partial class MessagesPage : ContentPage
    {
        private ChatMessageViewModel Vm;


        public MessagesPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            Vm = new ChatMessageViewModel();
            this.BindingContext = Vm;
        }

        private void MessagesListView_Refreshing(object sender, System.EventArgs e)
        {
            MessagesListView.IsRefreshing = false;
        }

        private async void MessagesListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = ((ListView)sender).SelectedItem as DtoMessage;
            if (item == null)
                return;

            await Application.Current.MainPage.Navigation.PushAsyncSingle(new Chat.ChatPage(item));

            ((ListView)sender).SelectedItem = null;
        }
        private void FloatingButton_Clicked(object sender, System.EventArgs e)
        {
            if (viewDetailFloating.IsVisible)
            {
                viewDetailFloating.IsVisible = false;
                btnFloating.RotateTo(0, 500);
            }
            else
            {
                viewDetailFloating.IsVisible = true;
                btnFloating.RotateTo(45, 500);
            }
        }
    }
}