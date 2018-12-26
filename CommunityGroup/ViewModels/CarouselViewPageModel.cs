using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CommunityGroup.ViewModels
{
    public class CarouselViewPageViewModel : BaseViewModel
    {
        private ObservableCollection<CarouselViewPageModel> _myCarouselViewPageList;
        public ObservableCollection<CarouselViewPageModel> MyCarouselViewPageList
        {
            get { return _myCarouselViewPageList; }
            set { _myCarouselViewPageList = value; OnPropertyChanged(); }
        }
        public CarouselViewPageViewModel()
        {
            MyCarouselViewPageList = new ObservableCollection<CarouselViewPageModel>()
            {
                new CarouselViewPageModel()
                {
                    Type=1,
                },
                new CarouselViewPageModel()
                {
                    Type=2,
                },
                new CarouselViewPageModel()
                {
                    Type=3,
                },
            };
        }
    }
}