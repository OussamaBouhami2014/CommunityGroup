using System;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{
    public class FloatingTwoButton : Grid
    {

        public static readonly BindableProperty TextOneProperty =
    BindableProperty.Create(nameof(CBTextOne), typeof(string), typeof(FloatingTwoButton), string.Empty);
        public string CBTextOne
        {
            get { return "" + (string)GetValue(TextOneProperty); }
            set { SetValue(TextOneProperty, value); }
        }

        public static readonly BindableProperty TextOneColorProperty =
        BindableProperty.Create(nameof(CBTextOneColor), typeof(Color), typeof(FloatingTwoButton), Color.Gray);
        public Color CBTextOneColor
        {
            get { return (Color)GetValue(TextOneColorProperty); }
            set
            {
                SetValue(TextOneColorProperty, value);
            }
        }

        public static readonly BindableProperty TextTwoProperty =
    BindableProperty.Create(nameof(CBTextTwo), typeof(string), typeof(FloatingTwoButton), string.Empty);
        public string CBTextTwo
        {
            get { return "" + (string)GetValue(TextTwoProperty); }
            set { SetValue(TextTwoProperty, value); }
        }

        public static readonly BindableProperty TextTwoColorProperty =
            BindableProperty.Create(nameof(CBTextTwoColor), typeof(Color), typeof(FloatingTwoButton), Color.Gray);
        public Color CBTextTwoColor
        {
            get { return (Color)GetValue(TextTwoColorProperty); }
            set
            {
                SetValue(TextTwoColorProperty, value);
            }
        }


        static readonly BindableProperty ImageOneProperty =
     BindableProperty.Create(nameof(CBImageOne), typeof(string), typeof(FloatingTwoButton), "info.png");
        public string CBImageOne
        {
            get { return (string)GetValue(ImageOneProperty); }
            set { SetValue(ImageOneProperty, value); }
        }


        static readonly BindableProperty ImageTwoProperty =
    BindableProperty.Create(nameof(CBImageTwo), typeof(string), typeof(FloatingTwoButton), "info.png");
        public string CBImageTwo
        {
            get { return (string)GetValue(ImageTwoProperty); }
            set { SetValue(ImageTwoProperty, value); }
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
            get { return (int)GetValue(ImageHeightRequestProperty); }
            set
            {
                SetValue(ImageHeightRequestProperty, value);
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


        public static readonly BindableProperty HeightRequestProperty =
            BindableProperty.Create(nameof(CBHeightRequest), typeof(int), typeof(CustomButton), 0);
        public int CBHeightRequest
        {
            get { return (int)GetValue(HeightRequestProperty); }
            set
            {
                SetValue(HeightRequestProperty, value);
            }
        }


        public static readonly BindableProperty FloatingImageProperty =
    BindableProperty.Create(nameof(CBFloatingImage), typeof(string), typeof(FloatingTwoButton), string.Empty);
        public string CBFloatingImage
        {
            get { return (string)GetValue(FloatingImageProperty); }
            set { SetValue(FloatingImageProperty, value); }
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

        private bool isFloatingBtnActive;
        private CustomButton btnChoiceOne, btnChoiceTwo, btnChoises;
        private Grid viewFloatingButton;
        private int Spacing = 10;
        public event EventHandler ClickedChoiceOne, ClickedChoiceTwo;

        public FloatingTwoButton()
        {
            viewFloatingButton = new Grid()
            {
                //Opacity = 0
            };

            btnChoiceOne = new CustomButton()
            {
                BindingContext = this,
                CBPadding = 0,
                BackgroundColor = Color.White,
                StyleCorner = ControlStyleCorner.Default,
                Opacity = 0
            };
            btnChoiceOne.SetBinding(CustomButton.ImageProperty, new Binding(nameof(CBImageOne)));
            btnChoiceOne.SetBinding(CustomButton.TextProperty, new Binding(nameof(CBTextOne)));
            btnChoiceOne.SetBinding(CustomButton.TextColorProperty, new Binding(nameof(CBTextOneColor)));
            btnChoiceOne.SetBinding(CustomButton.ImageWidthRequestProperty, new Binding(nameof(CBImageWidthRequest)));
            btnChoiceOne.SetBinding(CustomButton.ImageHeightRequestProperty, new Binding(nameof(CBImageHeightRequest)));
            btnChoiceOne.SetBinding(CustomButton.HasShadowProperty, new Binding(nameof(CBHasShadow)));

            btnChoiceTwo = new CustomButton()
            {
                BindingContext = this,
                CBPadding = 0,
                BackgroundColor = Color.White,
                StyleCorner = ControlStyleCorner.Default,
                Opacity = 0
            };
            btnChoiceTwo.SetBinding(CustomButton.ImageProperty, new Binding(nameof(CBImageTwo)));
            btnChoiceTwo.SetBinding(CustomButton.TextProperty, new Binding(nameof(CBTextTwo)));
            btnChoiceTwo.SetBinding(CustomButton.TextColorProperty, new Binding(nameof(CBTextTwoColor)));
            btnChoiceTwo.SetBinding(CustomButton.ImageWidthRequestProperty, new Binding(nameof(CBImageWidthRequest)));
            btnChoiceTwo.SetBinding(CustomButton.ImageHeightRequestProperty, new Binding(nameof(CBImageHeightRequest)));
            btnChoiceTwo.SetBinding(CustomButton.HasShadowProperty, new Binding(nameof(CBHasShadow)));

            btnChoises = new CustomButton()
            {
                BindingContext = this,
                CBPadding = 0,
            };

            btnChoises.SetBinding(CustomButton.ImageWidthRequestProperty, new Binding(nameof(CBWidthRequest)));
            btnChoises.SetBinding(CustomButton.ImageHeightRequestProperty, new Binding(nameof(CBHeightRequest)));
            btnChoises.SetBinding(CustomButton.ImageProperty, new Binding(nameof(CBFloatingImage)));
            btnChoises.SetBinding(CustomButton.HasShadowProperty, new Binding(nameof(CBHasShadow)));

            viewFloatingButton.Children.Add(btnChoiceOne);
            viewFloatingButton.Children.Add(btnChoiceTwo);

            this.Children.Add(viewFloatingButton);
            this.Children.Add(btnChoises);

            btnChoiceOne.Clicked += BtnChoiceOne_Clicked;
            btnChoiceTwo.Clicked += BtnChoiceTwo_Clicked;
            btnChoises.Clicked += BtnChoises_Clicked;
        }

        void BtnChoises_Clicked(object sender, EventArgs e)
        {
            Animation();
        }

        void BtnChoiceOne_Clicked(object sender, EventArgs e)
        {
            Animation();
            ClickedChoiceOne?.Invoke(sender, e);
        }

        void BtnChoiceTwo_Clicked(object sender, EventArgs e)
        {
            Animation();
            ClickedChoiceTwo?.Invoke(sender, e);
        }

        double ViewWidth;
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > -1 && height > -1 && ViewWidth > -1 && (width != ViewWidth))
            {
                ViewWidth = width;
            }
        }

        public async void Animation()
        {
            //var s = ((this.Width / 2) - ((btnChoiceOne.Width / 2) + (btnChoiceTwo.Width / 2) + (btnChoises.Width / 2) + (0)))/2;
            if (isFloatingBtnActive)
            {
                btnChoises.RotateTo(0, 500, Easing.CubicIn);
                btnChoises.TranslateTo(0, 0, 300, Easing.CubicIn);
                btnChoiceTwo.TranslateTo((btnChoiceTwo.Width / 2), 0, 350, Easing.SpringOut);
                btnChoiceTwo.FadeTo(0, 350);
                await System.Threading.Tasks.Task.Delay(100);
                btnChoiceOne.TranslateTo((btnChoises.Width / 2), 0, 350, Easing.SpringOut);
                btnChoiceOne.FadeTo(0, 350);

                isFloatingBtnActive = false;
            }
            else
            {
                btnChoises.RotateTo(45, 500, Easing.CubicIn);
                btnChoises.TranslateTo(-((btnChoiceOne.Width) + (btnChoises.Width)) + 0, 0, 300, Easing.CubicIn);
                btnChoiceOne.TranslateTo(-((btnChoiceOne.Width / 2) + (btnChoises.Width / 2)) + Spacing, 0, 350, Easing.SpringIn);
                btnChoiceOne.FadeTo(1, 350);
                await System.Threading.Tasks.Task.Delay(100);

                btnChoiceTwo.TranslateTo(-((btnChoiceOne.Width / 2) + (btnChoises.Width / 2)) + btnChoiceTwo.Width + Spacing * 2, 0, 350, Easing.SpringIn);
                btnChoiceTwo.FadeTo(1, 350);


                isFloatingBtnActive = true;
            }
        }
    }
}