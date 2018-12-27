using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityGroup.Models;
using Xamarin.Forms;
using XamForms.Controls;

namespace CommunityGroup.Views.Story
{
    public partial class AgendaPage : ContentPage
    {
        private DateTime? _date;
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<SpecialDate> selectedDatesList = new ObservableCollection<SpecialDate>();
        public ObservableCollection<SpecialDate> SelectedDatesList
        {
            get { return selectedDatesList; }
            set { selectedDatesList = value; OnPropertyChanged(); }
        }

        List<DateTime> DateSelectedList;
        int nbrSelectedDate = 0;
        bool isNewchoice;
        bool isCalendarInit;

        DtoDateInterval DateDebutFin;

        public event EventHandler<DtoDateInterval> DatesSelectedAcquired;
        DtoDateInterval args;
        private bool DatesSelected = false;

        private DateTime FirstDate = DateTime.Now.AddDays(1);
        private DateTime LastDate = DateTime.Now.AddDays(5);


        public AgendaPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            this.BindingContext = this;

            SelectedDatesList = new ObservableCollection<SpecialDate>();
            FirstDate = DateTime.Now;
            FirstDate = DateTime.Now.AddDays(3);

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();


            calendar.MultiSelectDates = false;

            //SelectedDatesList.Add(new SpecialDate(DateTime.Now.Date) { BackgroundColor = Color.FromHex("#778088"), TextColor = Color.FromHex("#f5f7F9"), Selectable = false });

            isCalendarInit = true;
            //DateSelectedList = new List<DateTime>();
            //SelectedDatesList = new List<SpecialDate>();


            selectedDatesList.Add(new SpecialDate(FirstDate) { BackgroundColor = Color.FromHex(App.Accent), TextColor = Color.White, FontAttributes = FontAttributes.Bold, FontSize = 15, Selectable = true });
            selectedDatesList.Add(new SpecialDate(LastDate) { BackgroundColor = Color.FromHex("#50" + App.Accent.Replace("#", "")), TextColor = Color.FromHex(App.DarkTextColor), Selectable = true });


            for (int i = 0; i < ((LastDate - FirstDate).Days); i++)
            {
                selectedDatesList.Add(new SpecialDate(FirstDate.AddDays(i)) { BackgroundColor = Color.FromHex("#50" + App.Accent.Replace("#", "")), TextColor = Color.FromHex(App.DarkTextColor), Selectable = true });
            }
            calendar.SpecialDates = SelectedDatesList;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            SelectedDatesList = new ObservableCollection<SpecialDate>();
            calendar.MultiSelectDates = false;
            //calendar.SelectedDate = null;
        }
        private async void Submit_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsyncSingle(new StoryPage(), true);
            }
            catch (Exception Ex)
            {
                AppsHelper.Snack(Ex.Message);
            }
        }

        private async void Calendar_DateClicked(object sender, XamForms.Controls.DateTimeEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    //AppHelpers.LoadingShow();
                }
                catch (Exception Ex)
                {
                    AppsHelper.Snack(Ex.Message);
                }
                finally
                {
                    //AppHelpers.LoadingHide();
                }
            });


        }

    }
}