using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace CommunityGroup.Popups
{
    public partial class LoadingPopup : PopupPage
    {
        private bool IsMirrorAnimationVisible;
        public LoadingPopup(bool isMirrorAnimationVisible = true)
        {
            InitializeComponent();
            IsMirrorAnimationVisible = isMirrorAnimationVisible;
            //animLoading.SetValue(propertyKey, Color.Red);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        //protected override Task OnAppearingAnimationBeginAsync()
        //{
        //    //return base.OnAppearingAnimationBeginAsync();
        //    return animLoading.ScaleTo(1, 2000);

        //}

        //protected override Task OnDisappearingAnimationEndAsync()
        //{
        //    //return base.OnDisappearingAnimationEndAsync();
        //    return Task.WhenAll(animLoading.ScaleTo(4, 2000));
        //}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            #region Setup AnimMirrorLoading
            if (Width <= 0 || height <= 0 || App.StandardPageHeight <= 0 || Device.RuntimePlatform != Device.Android || !IsMirrorAnimationVisible)
                return;

            if (!animMirrorLoading.IsVisible)
                animMirrorLoading.IsVisible = true;

            if (Width < Height)
            {
                animMirrorLoading.ScaleX = 1.2;
                animMirrorLoading.HeightRequest = App.StandardPageHeight;
            }
            else
            {
                animMirrorLoading.ScaleX = 4.2;
                animMirrorLoading.HeightRequest = height - 70;
            }
            #endregion
        }

        private async void Right_Swiped(object sender, Xamarin.Forms.SwipedEventArgs e)
        {
            //FormsToolkit.MessagingService.Current.SendMessage("CancelHttp", "#17c0eb");
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
        private void Loading_Tapped(object sender, EventArgs e)
        {
            animSwipe.IsVisible = true;
            animSwipe.IsPlaying = true;
            animSwipe.Play();
        }

        private void AnimSwipe_OnFinish(object sender, System.EventArgs e)
        {
            animSwipe.IsVisible = false;
            animSwipe.IsPlaying = false;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
            //return false;
        }
    }
}