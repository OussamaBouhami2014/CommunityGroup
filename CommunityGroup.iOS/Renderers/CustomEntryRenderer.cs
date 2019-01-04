using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using CommunityGroup.Controls;
using MyOCP_Mobile.XForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace MyOCP_Mobile.XForms.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || this.Element == null) return;

            UpdateControl();

            //Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));  
            //Control.LeftViewMode = UITextFieldViewMode.Always;  
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || this.Element == null) return;

            if (e.PropertyName == CustomEntry.IsBorderErrorVisibleProperty.PropertyName)
                UpdateControl();
        }

        private void UpdateControl()
        {
            var element = (CustomEntry)Element;
            Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
            Control.ReturnKeyType = UIReturnKeyType.Done;
            // Radius for the curves  
            Control.Layer.CornerRadius = float.Parse(element.CornerRaduis) / 2;
            // Thickness of the Border Color  
            Control.Layer.BorderColor = element.BorderColor.ToCGColor();

            Control.BackgroundColor = element.BackgroundColor.ToUIColor();
            Control.TextAlignment = (UITextAlignment)((CustomEntry)Element).HorizontalTextAlignment;

            //Control.LeftView = new UIView(new CGRect(0, 0, 15, 0));
            //Control.LeftViewMode = UITextFieldViewMode.Always;
            //Control.RightView = new UIView(new CGRect(0, 0, 15, 0));
            //Control.RightViewMode = UITextFieldViewMode.Always;
            Control.Layer.MasksToBounds = true;
            //CGRect rc = this.Bounds.Inset(20, 20);

            // Thickness of the Border Width  
            Control.Layer.BorderWidth = 1;
            Control.ClipsToBounds = true;

            if (element.IsBorderErrorVisible)
            {
                Control.Layer.BorderColor = element.BorderErrorColor.ToCGColor();
            }
            else
            {
                Control.Layer.BorderColor = element.BorderColor.ToCGColor();
            }
        }
    }
}