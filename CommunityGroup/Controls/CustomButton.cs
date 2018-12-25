using System;
using Xamarin.Forms;
//using static OCPA4C_XFomrs.AppEnums;

namespace CommunityGroup.Controls
{
    public class CustomButton : Grid
    {

        public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(CBText), typeof(string), typeof(CustomButton), string.Empty);

        public string CBText
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
                if (stack != null && label != null)
                    stack.Children.Add(label);
            }
        }

        public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(CBTextColor), typeof(Color), typeof(CustomButton), Color.LightGray);
        public Color CBTextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public static readonly BindableProperty ImageProperty =
      BindableProperty.Create(nameof(CBImage), typeof(string), typeof(CustomButton), string.Empty, propertyChanged: ImageChanged);
        public string CBImage
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(CBBackgroundColor), typeof(Color), typeof(CustomButton), Color.Transparent);
        public Color CBBackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(CBBorderColor), typeof(Color), typeof(CustomButton), Color.Transparent);
        public Color CBBorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public static readonly BindableProperty CornerRaduisProperty =
        BindableProperty.Create(nameof(CBCornerRaduis), typeof(int), typeof(CustomButton), 0);
        public int CBCornerRaduis
        {
            get { return (int)GetValue(CornerRaduisProperty); }
            set
            {
                SetValue(CornerRaduisProperty, value);
            }
        }

        public static readonly BindableProperty WidthRequestProperty =
            BindableProperty.Create(nameof(CBWidthRequest), typeof(int), typeof(CustomButton), 0);
        public int CBWidthRequest
        {
            get { return (int)GetValue(WidthRequestProperty); }
            set
            {
                SetValue(WidthRequestProperty, value);
            }
        }


        static readonly BindableProperty HeightRequestProperty =
            BindableProperty.Create(nameof(CBHeightRequest), typeof(int), typeof(CustomButton), 0);
        public int CBHeightRequest
        {
            get { return (int)GetValue(HeightRequestProperty); }
            set
            {
                SetValue(HeightRequestProperty, value);
            }
        }

        public static readonly BindableProperty ImageWidthRequestProperty =
         BindableProperty.Create(nameof(CBImageWidthRequest), typeof(int), typeof(CustomButton), 30);
        public int CBImageWidthRequest
        {
            get { return (int)GetValue(ImageWidthRequestProperty); }
            set
            {
                SetValue(ImageWidthRequestProperty, value);
            }
        }


        public static readonly BindableProperty ImageHeightRequestProperty =
            BindableProperty.Create(nameof(CBImageHeightRequest), typeof(int), typeof(CustomButton), 30);
        public int CBImageHeightRequest
        {
            //if (true) {

            //}
            get { return (int)GetValue(ImageHeightRequestProperty); }
            set
            {
                SetValue(ImageHeightRequestProperty, value);
            }
        }

        public static readonly BindableProperty SpacingProperty =
           BindableProperty.Create(nameof(CBSpacing), typeof(int), typeof(CustomButton), 5);
        public int CBSpacing
        {
            get { return (int)GetValue(SpacingProperty); }
            set
            {
                SetValue(SpacingProperty, value);
            }
        }

        public static readonly BindableProperty FontSizeProperty =
         BindableProperty.Create(nameof(CBFontSize), typeof(int), typeof(CustomButton), 12);
        public int CBFontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create(nameof(CBFontAttributes), typeof(FontAttributes), typeof(CustomButton), FontAttributes.Bold);
        public FontAttributes CBFontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set
            {
                SetValue(FontAttributesProperty, value);
            }
        }

        public static readonly BindableProperty PaddingProperty =
    BindableProperty.Create(nameof(CBPadding), typeof(Thickness), typeof(CustomButton), new Thickness(20, 15));

        public Thickness CBPadding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set
            {
                SetValue(PaddingProperty, value);
            }
        }

        public static readonly BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(CBHasShadow), typeof(bool), typeof(CustomButton), true);

        public bool CBHasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set
            {
                SetValue(HasShadowProperty, value);
            }
        }

        private static void ImageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var itemsLayout = (CustomButton)bindable;
            itemsLayout.SetItems();
        }


        private ControlStyleCorner _styleCorner = ControlStyleCorner.Circle;
        public ControlStyleCorner StyleCorner
        {
            get { return _styleCorner; }
            set { _styleCorner = value; }
        }

        public ControlAlignment ImageAlignment { get; set; }

        private StackLayout stack;
        private Label label;
        private Image image;
        Frame frame;
        public CustomButton()
        {
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.VerticalOptions = LayoutOptions.FillAndExpand;
            //Label
            label = new Label()
            {
                BindingContext = this,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };

            label.SetBinding(Label.TextProperty, new Binding(nameof(CBText)));
            label.SetBinding(Label.TextColorProperty, new Binding(nameof(CBTextColor)));
            label.SetBinding(Label.FontSizeProperty, new Binding(nameof(CBFontSize)));
            label.SetBinding(Label.FontAttributesProperty, new Binding(nameof(CBFontAttributes)));

            //Frame
            frame = new Frame()
            {
                BindingContext = this,
                IsClippedToBounds = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                HasShadow = false
            };
            frame.SizeChanged += (object sender, EventArgs e) =>
            {
                switch (StyleCorner)
                {
                    case ControlStyleCorner.Circle:
                        frame.CornerRadius = (float)frame.Height / 2;
                        break;

                    case ControlStyleCorner.Default:
                        break;

                };
            };

            //frame.SetBinding(Frame.CornerRadiusProperty, new Binding(nameof(CBCornerRaduis)));
            frame.SetBinding(Frame.BackgroundColorProperty, new Binding(nameof(CBBackgroundColor)));
            frame.SetBinding(Frame.PaddingProperty, new Binding(nameof(CBPadding)));
            frame.SetBinding(Frame.WidthProperty, new Binding(nameof(CBWidthRequest)));
            frame.SetBinding(Frame.HeightProperty, new Binding(nameof(CBHeightRequest)));
            frame.SetBinding(Frame.HasShadowProperty, new Binding(nameof(CBHasShadow)));
            frame.SetBinding(Frame.BorderColorProperty, new Binding(nameof(CBBorderColor)));

            //StackLayout
            stack = new StackLayout()
            {
                BindingContext = this,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            frame.Content = stack;

            this.Padding = 0;
            this.HorizontalOptions = LayoutOptions.Center;
            this.Children.Add(frame);

            TapGestureRecognizer gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            this.GestureRecognizers.Add(gestureRecognizer);
        }

        public void SetItems()
        {
            stack.Children.Clear();

            image = new Image()
            {
                BindingContext = this,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.AspectFit
            };
            image.SetBinding(Image.HeightRequestProperty, new Binding(nameof(CBImageHeightRequest)));
            image.SetBinding(Image.WidthRequestProperty, new Binding(nameof(CBImageWidthRequest)));
            image.SetBinding(Image.SourceProperty, new Binding(nameof(CBImage)));

            if (ImageAlignment == ControlAlignment.Left || ImageAlignment == ControlAlignment.Right)
            {
                stack.Orientation = StackOrientation.Horizontal;
            }

            stack.Orientation = ImageAlignment == (ControlAlignment.Left) ? StackOrientation.Horizontal : StackOrientation.Vertical;
            stack.SetBinding(StackLayout.SpacingProperty, new Binding(nameof(CBSpacing)));

            switch (ImageAlignment)
            {
                case ControlAlignment.Left:
                    stack.Orientation = StackOrientation.Horizontal;
                    stack.Children.Add(image);
                    //if (!string.IsNullOrEmpty(label.Text)) 
                    stack.Children.Add(label);
                    break;
                case ControlAlignment.Right:
                    stack.Orientation = StackOrientation.Horizontal;
                    //if (!string.IsNullOrEmpty(label.Text))  
                    stack.Children.Add(label);
                    stack.Children.Add(image);
                    break;
                case ControlAlignment.Top:
                    stack.Orientation = StackOrientation.Vertical;
                    stack.Children.Add(image);
                    //if (!string.IsNullOrEmpty(label.Text))  
                    stack.Children.Add(label);
                    break;
                case ControlAlignment.Bottom:
                    stack.Orientation = StackOrientation.Vertical;
                    //if (!string.IsNullOrEmpty(label.Text)) 
                    stack.Children.Add(label);
                    stack.Children.Add(image);
                    break;
                default:
                    break;
            }
        }

        public event EventHandler Clicked;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            var view = sender as CustomButton;
            AppsHelper.EffectClick(view);
            Clicked?.Invoke(sender, e);
        }
    }
}