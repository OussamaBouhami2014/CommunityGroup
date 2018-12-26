using System;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{
    public class CustomSwitch : Grid
    {
        public static readonly BindableProperty TextLightProperty = BindableProperty.Create(nameof(CSTextLight), typeof(string), typeof(CustomSwitch));
        public string CSTextLight
        {
            get
            {
                return (string)GetValue(TextLightProperty);
            }
            set
            {
                SetValue(TextLightProperty, value);
            }
        }

        public static readonly BindableProperty TextDarkProperty = BindableProperty.Create(nameof(CSTextDark), typeof(string), typeof(CustomSwitch));
        public string CSTextDark
        {
            get
            {
                return (string)GetValue(TextDarkProperty);
            }
            set
            {
                SetValue(TextDarkProperty, value);
            }
        }

        public static readonly BindableProperty LightColorProperty = BindableProperty.Create(nameof(CSLightColor), typeof(Color), typeof(CustomSwitch), Color.LightGray);
        public Color CSLightColor
        {
            get
            {
                return (Color)GetValue(LightColorProperty);
            }
            set
            {
                SetValue(LightColorProperty, value);
            }
        }

        public static readonly BindableProperty DarkColorProperty = BindableProperty.Create(nameof(CSDarkColor), typeof(Color), typeof(CustomSwitch), Color.LightBlue);
        public Color CSDarkColor
        {
            get
            {
                return (Color)GetValue(DarkColorProperty);
            }
            set
            {
                SetValue(DarkColorProperty, value);
            }
        }

        public static readonly BindableProperty HeightRequestProperty =
          BindableProperty.Create(nameof(CSHeightRequest), typeof(int), typeof(CustomButton), 50);
        public int CSHeightRequest
        {
            get { return (int)GetValue(HeightRequestProperty); }
            set
            {
                SetValue(HeightRequestProperty, value);
            }
        }

        public static readonly BindableProperty FontSizeProperty =
         BindableProperty.Create(nameof(CSFontSize), typeof(int), typeof(CustomButton), 15);
        public int CSFontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }
        private BoxView parentSwitchView, childSwitchView;
        private Label switchTxtOne, switchTxtTwo;

        public event EventHandler ClickedSwitchOne, ClickedSwitchTwo;
        private double ViewWidth;
        private bool isSwitchInRight;

        public CustomSwitch()
        {
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            this.ColumnSpacing = 0;

            //BoxView 
            parentSwitchView = new BoxView()
            {
                BindingContext = this,
                CornerRadius = Device.RuntimePlatform == Device.Android ? 40 : 20
            };
            parentSwitchView.SetBinding(BoxView.BackgroundColorProperty, new Binding(nameof(CSLightColor)));

            childSwitchView = new BoxView()
            {
                BindingContext = this,
                CornerRadius = Device.RuntimePlatform == Device.Android ? 40 : 20
            };

            childSwitchView.SetBinding(BoxView.BackgroundColorProperty, new Binding(nameof(CSDarkColor)));

            //Label
            switchTxtOne = new Label()
            {
                BindingContext = this,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            switchTxtOne.SetBinding(Label.FontSizeProperty, new Binding(nameof(CSFontSize)));
            switchTxtOne.SetBinding(Label.TextProperty, new Binding(nameof(CSTextDark)));

            switchTxtTwo = new Label()
            {
                BindingContext = this,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
            };
            switchTxtTwo.SetBinding(Label.FontSizeProperty, new Binding(nameof(CSFontSize)));
            switchTxtTwo.SetBinding(Label.TextProperty, new Binding(nameof(CSTextLight)));
            switchTxtTwo.SetBinding(Label.TextColorProperty, new Binding(nameof(CSDarkColor)));

            //Setup
            this.Children.Add(parentSwitchView);
            this.Children.Add(childSwitchView);
            this.Children.Add(switchTxtOne, 0, 0);
            this.Children.Add(switchTxtTwo, 1, 0);

            Grid.SetColumnSpan(parentSwitchView, 2);

            //Events
            TapGestureRecognizer gestureSwitchOne = new TapGestureRecognizer();
            gestureSwitchOne.Tapped += GestureSwitchOne;
            switchTxtOne.GestureRecognizers.Add(gestureSwitchOne);

            TapGestureRecognizer gestureSwitchTwo = new TapGestureRecognizer();
            gestureSwitchTwo.Tapped += GestureSwitchTwo;
            switchTxtTwo.GestureRecognizers.Add(gestureSwitchTwo);
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > -1 && height > -1 && ViewWidth > -1 && (width != ViewWidth))
            {
                ViewWidth = width;

                if (isSwitchInRight)
                    childSwitchView.TranslationX = (ViewWidth / 2);
                else
                    childSwitchView.TranslationX = 0;
            }
        }

        private async void GestureSwitchOne(object sender, EventArgs e)
        {
            switchTxtOne.TextColor = Color.White;

            switchTxtTwo.TextColor = CSDarkColor;
            childSwitchView.FadeTo(.8, 100, Easing.CubicIn);
            await childSwitchView.TranslateTo(0, 0, 200, Easing.CubicOut);
            childSwitchView.FadeTo(1, 100, Easing.CubicIn);

            isSwitchInRight = false;
            ClickedSwitchOne?.Invoke(sender, e);
        }

        private async void GestureSwitchTwo(object sender, EventArgs e)
        {
            switchTxtOne.TextColor = CSDarkColor;
            switchTxtTwo.TextColor = Color.White;

            childSwitchView.FadeTo(.8, 100, Easing.CubicIn);
            await childSwitchView.TranslateTo(ViewWidth / 2, 0, 200, Easing.CubicOut);
            childSwitchView.FadeTo(1, 100, Easing.CubicIn);

            isSwitchInRight = true;
            ClickedSwitchTwo?.Invoke(sender, e);
        }
    }
}