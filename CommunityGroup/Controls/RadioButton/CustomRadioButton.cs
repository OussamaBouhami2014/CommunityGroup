using System;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{

    public class CustomRadioButton : Grid
    {
        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(CRColor), typeof(Color), typeof(CustomRadioButton), Color.Transparent);
        public Color CRColor
        {
            get { return (Color)GetValue(ColorProperty); }
            set
            {
                SetValue(ColorProperty, value);
                this.ChangeState();
            }

        }
        public static readonly BindableProperty LightColorProperty =
            BindableProperty.Create(nameof(CRLightColor), typeof(Color), typeof(CustomRadioButton), Color.White);
        public Color CRLightColor
        {
            get { return (Color)GetValue(LightColorProperty); }
            set
            {
                SetValue(LightColorProperty, value);
            }

        }
        public static readonly BindableProperty TextProperty =
       BindableProperty.Create(nameof(CRText), typeof(string), typeof(CustomRadioButton), string.Empty);

        public string CRText
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(CRTextColor), typeof(Color), typeof(CustomRadioButton), Color.LightGray);
        public Color CRTextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        //public static readonly BindableProperty CRCheckedProperty =
        //BindableProperty.Create(nameof(CRChecked), typeof(bool), typeof(CustomRadioButton), false, BindingMode.TwoWay );

        public static readonly BindableProperty CRCheckedProperty = BindableProperty.Create("CRChecked", typeof(bool), typeof(CustomRadioButton), (object)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate)null, (BindableProperty.BindingPropertyChangedDelegate)CustomRadioButton.OnCheckedPropertyChanged, (BindableProperty.BindingPropertyChangingDelegate)null, (BindableProperty.CoerceValueDelegate)null, (BindableProperty.CreateDefaultValueDelegate)null);
        public bool CRChecked
        {
            get { return (bool)GetValue(CRCheckedProperty); }
            set
            {
                SetValue(CRCheckedProperty, value);
                OnPropertyChanged();
                ChangeState();
            }
        }

        //OnCheckedPropertyChanged

        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var d = newvalue;
        }

        public static readonly BindableProperty SpacingProperty =
         BindableProperty.Create(nameof(CRSpacing), typeof(int), typeof(CustomRadioButton), 8);
        public int CRSpacing
        {
            get { return (int)GetValue(SpacingProperty); }
            set
            {
                SetValue(SpacingProperty, value);
            }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(CRFontSize), typeof(int), typeof(CustomRadioButton), 12);
        public int CRFontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create(nameof(CRFontAttributes), typeof(FontAttributes), typeof(CustomRadioButton), FontAttributes.None);
        public FontAttributes CRFontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set
            {
                SetValue(FontAttributesProperty, value);
            }
        }

        public EventHandler<EventArgs<bool>> CheckedChanged;

        public void ChangeState()
        {
            circle.BackgroundColor = CRChecked ? CRColor : CRLightColor;
        }

        private Frame outline, transparent, circle;
        public CustomRadioButton()
        {
            this.HorizontalOptions = LayoutOptions.Start;
            this.VerticalOptions = LayoutOptions.Center;
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

            outline = new Frame()
            {
                BindingContext = this,
                HeightRequest = 22,
                WidthRequest = 22,
                CornerRadius = 11,
                Padding = 0,
                IsClippedToBounds = true,
                HasShadow = false,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
            outline.SetBinding(Frame.BackgroundColorProperty, new Binding(nameof(CRColor)));

            transparent = new Frame()
            {
                BindingContext = this,
                HeightRequest = 18,
                WidthRequest = 18,
                CornerRadius = 9,
                Padding = 0,
                IsClippedToBounds = true,
                HasShadow = false,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            transparent.SetBinding(Frame.BackgroundColorProperty, new Binding(nameof(CRLightColor)));

            circle = new Frame()
            {
                BindingContext = this,
                HeightRequest = 12,
                WidthRequest = 12,
                CornerRadius = 6,
                Padding = 0,
                IsClippedToBounds = true,
                HasShadow = false,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            //Label
            var label = new Label()
            {
                BindingContext = this,
                LineBreakMode = LineBreakMode.TailTruncation,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                VerticalTextAlignment = TextAlignment.Center
            };
            label.SetBinding(Label.TextProperty, new Binding(nameof(CRText)));
            label.SetBinding(Label.TextColorProperty, new Binding(nameof(CRTextColor)));
            label.SetBinding(Label.FontSizeProperty, new Binding(nameof(CRFontSize)));
            label.SetBinding(Label.FontAttributesProperty, new Binding(nameof(CRFontAttributes)));

            this.BindingContext = this;
            this.SetBinding(Grid.ColumnSpacingProperty, new Binding(nameof(CRSpacing)));
            this.Children.Add(outline, 0, 0);
            this.Children.Add(transparent, 0, 0);
            this.Children.Add(circle, 0, 0);
            this.Children.Add(label, 1, 0);

            TapGestureRecognizer gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            this.GestureRecognizers.Add(gestureRecognizer);

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var view = sender as CustomRadioButton;
            CRChecked = !CRChecked;
            CheckedChanged?.Invoke(view.BindingContext, new EventArgs<bool>(CRChecked));

            AppsHelper.EffectClick(view);
        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int CRId { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    }
}