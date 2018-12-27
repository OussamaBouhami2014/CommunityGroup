using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{
    public class CustomTemplateButton : ContentView
    {
        public event EventHandler Clicked;

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var view = sender as CustomTemplateButton;
            AppsHelper.EffectClick(view);
            Clicked?.Invoke(sender, e);
        }

        public CustomTemplateButton()
        {
            this.VerticalOptions = LayoutOptions.Center;
            this.HorizontalOptions = LayoutOptions.Center;

            TapGestureRecognizer gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            this.GestureRecognizers.Add(gestureRecognizer);
        }
    }
}