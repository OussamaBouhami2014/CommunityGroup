using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{

    public class CustomGroupRadioButton : Grid
    {

        public ObservableCollection<CustomRadioButton> CGRItems;

        public CustomGroupRadioButton()
        {
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            CGRItems = new ObservableCollection<CustomRadioButton>();
        }


        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(CGRItemsSource), typeof(Dictionary<string, bool>), typeof(CustomGroupRadioButton), default(Dictionary<string, bool>), propertyChanged: OnItemsSourceChanged);



        public static readonly BindableProperty SelectedIndexProperty =
           BindableProperty.Create(nameof(CGRSelectedIndex), typeof(int), typeof(CustomGroupRadioButton), null, BindingMode.TwoWay, propertyChanged: OnSelectedIndexChanged);


        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(CGRTextColor), typeof(Color), typeof(CustomGroupRadioButton), Color.LightGray);


        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(CGRTextColor), typeof(Color), typeof(CustomGroupRadioButton), Color.Black);

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(CGRFontSize), typeof(int), typeof(CustomGroupRadioButton), 12);


        public Dictionary<string, bool> CGRItemsSource
        {
            get { return (Dictionary<string, bool>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public int CGRSelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public Color CGRTextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        public Color CGRColor
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public double CGRFontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }


        /// <summary>
        /// Gets or sets the name of the font.
        /// </summary>
        /// <value>The name of the font.</value>
        //public string FontName
        //{
        //    get
        //    {
        //        return (string)GetValue(FontNameProperty);
        //    }
        //    set
        //    {
        //        SetValue(FontNameProperty, value);
        //    }
        //}


        public event EventHandler<int> CGRCheckedChanged;
        public bool CGRIsMultiSelect { get; set; }

        private void OnCheckedChanged(object sender, EventArgs<bool> e)
        {
            if (e.Value == false)
            {
                return;
            }

            var selectedItem = sender as CustomRadioButton;

            if (selectedItem == null)
            {
                return;
            }

            foreach (var item in CGRItems)
            {
                if (!selectedItem.CRId.Equals(item.CRId))
                {
                    if (!CGRIsMultiSelect)
                        item.CRChecked = false;
                }
                else
                {
                    CGRCheckedChanged?.Invoke(sender, item.CRId);
                    if (!CGRIsMultiSelect)
                        CGRSelectedIndex = selectedItem.CRId;
                }
            }
        }

        private static void OnSelectedIndexChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if ((int)newvalue == -1)
            {
                return;
            }

            var customGroupRadioButton = bindable as CustomGroupRadioButton;

            if (customGroupRadioButton == null)
            {
                return;
            }

            foreach (var button in customGroupRadioButton.CGRItems.Where(button => button.CRId == customGroupRadioButton.CGRSelectedIndex))
            {
                button.CRChecked = true;
            }
        }
        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var radButtons = bindable as CustomGroupRadioButton;

            foreach (var item in radButtons.CGRItems)
            {
                item.CheckedChanged -= radButtons.OnCheckedChanged;
            }

            radButtons.Children.Clear();

            var radIndex = 0;
            var Row = 0;
            var Column = 0;

            foreach (var item in radButtons.CGRItemsSource)
            {
                var button = new CustomRadioButton
                {
                    CRText = item.Key,
                    CRChecked = item.Value,
                    CRId = radIndex++,
                    CRColor = radButtons.CGRColor,
                    CRTextColor = radButtons.CGRTextColor,
                    //CRFontSize = Device.GetNamedSize(NamedSize.Small, radButtons),
                    CRFontSize = 12,
                    //FontName = radButtons.FontName
                };

                button.CheckedChanged += radButtons.OnCheckedChanged;

                radButtons.CGRItems.Add(button);

                radButtons.Children.Add(button, Column, Row);

                Column = Column == 0 ? 1 : 0;
                if ((radIndex - 1) % 2 != 0) Row++;

            }
        }

        public Dictionary<string, bool> GetSource()
        {
            Dictionary<string, bool> SourceList = new Dictionary<string, bool>();

            foreach (var item in CGRItems)
            {
                SourceList.Add(item.CRText, item.CRChecked);
            }
            return SourceList;
        }

    }
}