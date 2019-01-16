using System;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{
    public class ViewAucunResultat : StackLayout
    {
        public event EventHandler ReloadClicked;
        public bool IsHasButton { get; set; }

        public static readonly BindableProperty NavColorProperty = BindableProperty.Create(nameof(NavColor), typeof(Color), typeof(CustomSwitch));
        public Color NavColor
        {
            get
            {
                return (Color)GetValue(NavColorProperty);
            }
            set
            {
                SetValue(NavColorProperty, value);
            }
        }

        public ViewAucunResultat()
        {
            this.HorizontalOptions = LayoutOptions.CenterAndExpand;
            this.VerticalOptions = LayoutOptions.CenterAndExpand;
            this.Padding = new Thickness(50, 0);
            this.Spacing = 10;

            var imageReessayer = new Image()
            {
                Opacity = .2,
                Source = "iconNotFound.png",
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 60,
                WidthRequest = 60
            };

            var txtReessayer = new Label()
            {
                Opacity = .2,
                Text = "Aucun résultat trouvé !",
                TextColor = Color.FromHex(App.DarkTextColor),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                FontAttributes = FontAttributes.Bold
            };

            this.Children.Add(imageReessayer);
            this.Children.Add(txtReessayer);

            if (IsHasButton)
            {
                var btnReessayer = new CustomButton()
                {
                    BindingContext = this,
                    CBText = "RÉESSAYER",
                    CBPadding = 10,
                    CBHasShadow = false,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                };
                btnReessayer.SetBinding(CustomButton.TextColorProperty, new Binding(nameof(NavColor)));

                this.Children.Add(btnReessayer);
                btnReessayer.Clicked += (object sender, EventArgs e) =>
                {
                    ReloadClicked?.Invoke(this, null);
                };
            }
        }
    }
}