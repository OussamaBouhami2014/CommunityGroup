using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using Plugin.Media;
using Plugin.Media.Abstractions;
using CommunityGroup.Models;
using CommunityGroup.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
//using Plugin.MediaManager.Abstractions.Enums;
//using Plugin.MediaManager;

namespace CommunityGroup.Views.Chat

{
    public partial class ChatPage : ContentPage
    {
        bool boole = true;
        Image imageCamera, imageProfile;
        bool BackPressed = false;
        ChatMessageViewModel Vm;

        public ChatPage()
        {
            InitializeComponent();
            //this.Title = GroupeName;
            Vm = new ChatMessageViewModel();
            this.BindingContext = Vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //List View Scrool To End //
            var lastItem = ChatMessagesListView.ItemsSource.Cast<object>().LastOrDefault();
            ChatMessagesListView.ScrollTo(lastItem, ScrollToPosition.End, false);
        }

        // On Image Chat Click 
        private void cameraTap_Tapped(object sender, EventArgs e)
        {

        }

        #region Chat Button Event
        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avialable.", "Ok");

                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    //Directory="Sample",
                    //Name = "test.jpg"
                });

            if (file == null) return;

            // Find Image Path => file.Path;


            var btn = sender as Button;
            var messageChat = btn?.BindingContext as DtoMessage;
            Vm = BindingContext as ChatMessageViewModel;

            Device.BeginInvokeOnMainThread(async () =>
            {

                if (boole)
                {
                    Vm.SendMsgImage = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();

                        file.Dispose();
                        GC.Collect();
                        return stream;
                    });

                    Vm.StatutsMsg = "SentImage";


                    boole = false;
                }
                else
                {
                    Vm.SendMsgImage = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();

                        file.Dispose();
                        GC.Collect();
                        return stream;
                    });

                    Vm.StatutsMsg = "ReceivedImage";

                    boole = true;
                }

                entryMessage.Text = "";
                Vm?.SendMessage.Execute(messageChat);

                // List View Scrool To End //
                //var lastItem = ChatMessagesListView.ItemsSource.Cast<object>().LastOrDefault();
                //OR
                ChatMessagesListView.ScrollTo(Vm.ChatList.LastOrDefault(), ScrollToPosition.End, true);

            });


        }

        private async void btnAudio_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            {
                DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Name = "video.mp4",
                Directory = "DefaultVideos",
            });

            await DisplayAlert("Video Recorded", "Location: " + file.Path, "OK");

            if (file == null)
                return;


            var btn = sender as Button;
            var messageChat = btn?.BindingContext as DtoMessage;
            Vm = BindingContext as ChatMessageViewModel;

            //Device.BeginInvokeOnMainThread(async () =>
            //{

            //  if (boole)
            //  {
            //      vm.SendMsgImage = ImageSource.FromStream(() =>
            //      {
            //          var stream = file.GetStream();

            //          file.Dispose();
            //          GC.Collect();
            //          return stream;
            //      });

            //      vm.StatutsMsg = "SentVideo";


            //      boole = false;
            //  }
            //  else
            //  {

            //      vm.SendMsgVideo = CrossMediaManager.Current.Play("https://www.youtube.com/watch?v=luDyX0kYzY4", MediaFileType.Video);
            //      vm.SendMsgVideo = MediaFileType.Video(() =>
            //      {
            //          var stream = file.GetStream();

            //          file.Dispose();
            //          GC.Collect();
            //          return stream;
            //      });

            //      vm.StatutsMsg = "ReceivedVideo";

            //      boole = true;
            //  }


            //  entryMessage.Text = "";
            //  vm?.SendMessage.Execute(messageChat);

            //  // List View Scrool To End //
            //  //var lastItem = ChatMessagesListView.ItemsSource.Cast<object>().LastOrDefault();
            //  //OR
            //  ChatMessagesListView.ScrollTo(vm.ChatList.LastOrDefault(), ScrollToPosition.End, true);
            //});
        }

        private async void btnImage_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium
            });


            if (file == null)
                return;


            var btn = sender as Button;
            var messageChat = btn?.BindingContext as DtoMessage;
            Vm = BindingContext as ChatMessageViewModel;

            Device.BeginInvokeOnMainThread(async () =>
            {

                if (boole)
                {
                    Vm.SendMsgImage = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();

                        file.Dispose();
                        GC.Collect();
                        return stream;
                    });

                    Vm.StatutsMsg = "SentImage";


                    boole = false;
                }
                else
                {
                    Vm.SendMsgImage = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();

                        file.Dispose();
                        GC.Collect();
                        return stream;
                    });

                    Vm.StatutsMsg = "ReceivedImage";

                    boole = true;
                }


                entryMessage.Text = "";
                Vm?.SendMessage.Execute(messageChat);

                // List View Scrool To End //
                //var lastItem = ChatMessagesListView.ItemsSource.Cast<object>().LastOrDefault();
                //OR
                ChatMessagesListView.ScrollTo(Vm.ChatList.LastOrDefault(), ScrollToPosition.End, true);
            });

        }

        private async void btnSend_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryMessage.Text) && !contentAdd.IsVisible)
            {
                string message = entryMessage.Text;

                var btn = sender as Button;
                var messageChat = btn?.BindingContext as DtoMessage;
                Vm = BindingContext as ChatMessageViewModel;

                //await chatHubproxy.invoke("sendmessage", new object[] { myusername, message });

                Device.BeginInvokeOnMainThread(async () =>
                {

                    if (boole)
                    {
                        Vm.SendMsgText = message;
                        Vm.StatutsMsg = "SentText";


                        boole = false;
                    }
                    else
                    {
                        Vm.SendMsgText = message;
                        Vm.StatutsMsg = "ReceivedText";

                        boole = true;
                    }

                    entryMessage.Text = "";
                    Vm?.SendMessage.Execute(messageChat);

                    // List View Scrool To End //
                    //var lastItem = ChatMessagesListView.ItemsSource.Cast<object>().LastOrDefault();
                    //OR
                    ChatMessagesListView.ScrollTo(Vm.ChatList.LastOrDefault(), ScrollToPosition.End, true);

                });

            }
            else
            {
                if (!contentAdd.IsVisible)
                {
                    entryMessage.IsEnabled = false;
                    btnSend.RotateTo(45);
                    contentAdd.IsVisible = true;
                    await frameAdd.TranslateTo(0, 0, 250, Easing.CubicInOut);
                }
                else
                {
                    entryMessage.IsEnabled = true;
                    btnSend.RotateTo(0);
                    contentAdd.IsVisible = false;
                    await frameAdd.TranslateTo(0, 300, 250, Easing.CubicInOut);
                }

            }
        }

        #endregion

        private void ChatMessagesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ChatMessagesListView.SelectedItem = null;
        }

        private void ChatMessagesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ChatMessagesListView.SelectedItem = null;
        }

        private async void entryMessage_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (!string.IsNullOrEmpty(entryMessage.Text))
            {



                btnSend.Source = "iconSend";
                gridCameraAudio.TranslateTo(-gridCameraAudio.Height * 2, 0, 250, Easing.CubicInOut);
                gridCameraAudio.IsVisible = false;


            }
            else
            {
                btnSend.Source = "iconAdd";
                gridCameraAudio.IsVisible = true;
                await gridCameraAudio.TranslateTo(0, 0, 250, Easing.CubicInOut);
            }
        }

        private void entryMessage_Unfocused(object sender, FocusEventArgs e)
        {
        }

        private void entryMessage_Completed(object sender, EventArgs e)
        {
            entryMessage.Focus();
        }

        private string ImageNameFromResource(string u)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                //  System.Diagnostics.Debug.WriteLine("found resource: " + res);
                if (res.Contains(u))
                {
                    return res;
                }
            }
            return null;
        }

    }
}