using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{
    public class CustomEntry : Entry
    {

        public static readonly BindableProperty IsBorderErrorVisibleProperty =
            BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(CustomEntry), false, BindingMode.TwoWay);

        public bool IsBorderErrorVisible
        {
            get { return (bool)GetValue(IsBorderErrorVisibleProperty); }
            set
            {
                SetValue(IsBorderErrorVisibleProperty, value);
            }
        }

        public static readonly BindableProperty LeftImageProperty =
        BindableProperty.Create(nameof(LeftImage), typeof(string), typeof(CustomDatePicker), string.Empty);

        public string LeftImage
        {
            get { return (string)GetValue(LeftImageProperty); }
            set
            {
                SetValue(LeftImageProperty, value);
            }
        }
        public static readonly BindableProperty IsCustomProperty =
            BindableProperty.Create(nameof(IsCustom), typeof(bool), typeof(CustomEntry), false, BindingMode.TwoWay);

        public bool IsCustom
        {
            get { return (bool)GetValue(IsCustomProperty); }
            set
            {
                SetValue(IsCustomProperty, value);
            }
        }

        public static readonly BindableProperty BorderErrorColorProperty =
            BindableProperty.Create(nameof(BorderErrorColor), typeof(Xamarin.Forms.Color), typeof(CustomEntry), Xamarin.Forms.Color.Red, BindingMode.TwoWay);

        public Xamarin.Forms.Color BorderErrorColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BorderErrorColorProperty); }
            set
            {
                SetValue(BorderErrorColorProperty, value);
            }
        }

        public static readonly BindableProperty ErrorTextProperty =
        BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(CustomEntry), string.Empty);

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set
            {
                SetValue(ErrorTextProperty, value);
            }
        }

        public static readonly BindableProperty BackgroundColorProperty =
           BindableProperty.Create(nameof(BackgroundColor), typeof(Xamarin.Forms.Color), typeof(CustomEntry), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);
        public Xamarin.Forms.Color BackgroundColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BackgroundColorProperty); }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }

        public static readonly BindableProperty BorderColorProperty =
           BindableProperty.Create(nameof(BorderColor), typeof(Xamarin.Forms.Color), typeof(CustomEntry), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);
        public Xamarin.Forms.Color BorderColor
        {
            get { return (Xamarin.Forms.Color)GetValue(BorderColorProperty); }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public static readonly BindableProperty CornerRaduisProperty =
        BindableProperty.Create(nameof(CornerRaduis), typeof(string), typeof(CustomEntry), "0");

        public string CornerRaduis
        {
            get { return (string)GetValue(CornerRaduisProperty); }
            set
            {
                SetValue(CornerRaduisProperty, value);
            }
        }

        public static readonly BindableProperty HorizontalTextAlignmentProperty =
    BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(CustomEntry), TextAlignment.Start);

        public TextAlignment HorizontalTextAlignment
        {

            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set
            {
                SetValue(HorizontalTextAlignmentProperty, value);
            }
        }


        public static readonly BindableProperty PaddingProperty =
    BindableProperty.Create(nameof(Padding), typeof(Tuple<int, int, int, int>), typeof(CustomEntry));

        public Tuple<int, int, int, int> Padding
        {

            get { return (Tuple<int, int, int, int>)GetValue(PaddingProperty); }
            set
            {
                SetValue(PaddingProperty, value);
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

            this.Completed += (sender, e) =>
            {
                OnNext();
            };
        }

        public void OnNext()
        {
            NextView?.Focus();
        }

        public CustomEntry()
        {
            this.Effects.Add(Effect.Resolve("Effects.EntryMoveNextEffect"));
            //this.Behaviors.Add(new Behavior.EmptyEntryValidatorBehavior());
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.HeightRequest = 40;

            }
        }
    }
}