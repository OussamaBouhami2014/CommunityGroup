using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{
    public class CostumList : Grid
    {
         
        private ICommand _innerSelectedCommand;
        public readonly ScrollView _scrollView;
        private readonly StackLayout _itemsStackLayout;


        public event EventHandler SelectedItemChanged;

        public StackOrientation ListOrientation { get; set; }

        public double Spacing { get; set; }
        public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }
        public ScrollBarVisibility VerticalScrollBarVisibility { get; set; }

        public static readonly BindableProperty SelectedCommandProperty =
            BindableProperty.Create("SelectedCommand", typeof(ICommand), typeof(CostumList), null);

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(CostumList), default(IEnumerable<object>), BindingMode.TwoWay, propertyChanged: ItemsSourceChanged);

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create("SelectedItem", typeof(object), typeof(CostumList), null, BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(CostumList), default(DataTemplate));

        public ICommand SelectedCommand
        {
            get { return (ICommand)GetValue(SelectedCommandProperty); }
            set { SetValue(SelectedCommandProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }


        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var itemsLayout = (CostumList)bindable;
            itemsLayout.SetItems();
        }

        public CostumList()
        {

            Spacing = 6;
            _scrollView = new ScrollView();
           
            _itemsStackLayout = new StackLayout
            {
                Padding = this.Padding,
                Spacing = this.Spacing,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };


            _scrollView.Content = _itemsStackLayout;
            Children.Add(_scrollView);
        }

        public virtual void SetItems()
        {
            _itemsStackLayout.Children.Clear();
            _itemsStackLayout.Spacing = Spacing;

            _innerSelectedCommand = new Command<View>(async view =>
            {
                SelectedItem = view.BindingContext;
              
                SelectedItem = null; // Allowing item second time selection
            });

            _itemsStackLayout.Orientation = ListOrientation;
            _scrollView.Orientation = ListOrientation == StackOrientation.Horizontal
                ? ScrollOrientation.Horizontal
                : ScrollOrientation.Vertical;

            _scrollView.VerticalScrollBarVisibility = this.VerticalScrollBarVisibility;
            _scrollView.HorizontalScrollBarVisibility = this.HorizontalScrollBarVisibility;

            if (ItemsSource == null)
            {
              return;
            }

            foreach (var item in ItemsSource)
            {
              _itemsStackLayout.Children.Add(GetItemView(item));
            }

        
                SelectedItem = null;
        }

        protected virtual View GetItemView(object item)
        {
            var content = ItemTemplate.CreateContent();
            var view = content as View;

            if (view == null)
            {
                return null;
            }

            view.BindingContext = item;

            var gesture = new TapGestureRecognizer
            {
                Command = _innerSelectedCommand,
                CommandParameter = view,
                NumberOfTapsRequired = 1
            };

            AddGesture(view, gesture);

            return view;
        }

        private void AddGesture(View view, TapGestureRecognizer gesture)
        {
            view.GestureRecognizers.Add(gesture);

            var layout = view as Layout<View>;

            if (layout == null)
            {
                return;
            }

            //foreach (var child in layout.Children)
            //{
            //  AddGesture(child, gesture);
            //}
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var itemsView = (CostumList)bindable;
            if (newValue == oldValue && newValue != null)
            {
                return;
            }

            itemsView.SelectedItemChanged?.Invoke(itemsView, EventArgs.Empty);

            if (itemsView.SelectedCommand?.CanExecute(newValue) ?? false)
            {
                itemsView.SelectedCommand?.Execute(newValue);
            }
        }

    }
}