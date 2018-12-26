using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{
    public class CustomDatePicker : DatePicker
    {
        public static readonly BindableProperty RightImageProperty =
        BindableProperty.Create(nameof(RightImage), typeof(string), typeof(CustomDatePicker), string.Empty);

        public string RightImage
        {
            get { return (string)GetValue(RightImageProperty); }
            set
            {
                SetValue(RightImageProperty, value);
            }
        }

        public static readonly BindableProperty NextViewProperty = BindableProperty.Create(nameof(NextView), typeof(View), typeof(Entry));
        public View NextView
        {
            get => (View)GetValue(NextViewProperty);
            set => SetValue(NextViewProperty, value);
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            this.DateSelected += (sender, e) =>
            {
                NextView?.Focus();
            };
        }


        public CustomDatePicker()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.HeightRequest = 40;
            }
        }
    }
}