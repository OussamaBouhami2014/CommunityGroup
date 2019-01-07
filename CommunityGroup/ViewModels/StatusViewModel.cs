using System;
using System.Collections.Generic;
using CommunityGroup.Models;
using Xamarin.Forms;

namespace CommunityGroup.ViewModels
{
    public class StatusViewModel : BaseViewModel
    {
        private bool _isFindData;
        public bool IsFindData { get { return _isFindData; } set { _isFindData = value; OnPropertyChanged(); } }

        public List<DtoStatus> StatutsData;
        private List<DtoStatus> _listStatuts;
        public List<DtoStatus> ListStatuts { get { return _listStatuts; } set { _listStatuts = value; OnPropertyChanged(); } }

        public StatusViewModel()
        {
            StatutsData = new List<DtoStatus>()
            {
                    new DtoStatus()
                    {
                        photoUser = "photoMalal.png",
                        fullNameUser = "MALAL Zakariae",
                        Topic = "Innovation",
                        BackgroundTopic = App.TopicOneColor,
                        DatePublication = "2 Jan, 2019 à 08:15",
                        Title = "Première participation d'OCP à la CIIE",
                        Image = "EventFour.png",
                        IsImageVisible = true,
                        NbrLikes = 14,
                        NbrComment = 12,
                        Comment = new CommentDTO()
                        {
                            PhotoUser = "avatarWomen.png",
                            FullNameUser = "Amal Haki",
                            Text ="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout"
                        }
                    },
                     new DtoStatus()
                    {
                        photoUser = "photoTahiri.png",
                        fullNameUser = "TAHIRI Meriem",
                        Topic = "Digital",
                        BackgroundTopic = App.TopicTwoColor,
                        DatePublication = "3 Jan, 2019 à 02:33",
                        Title = "Hello cher club, je suis à la recherche d'un encadrant pour le développement d'une solution digital sur Android",
                        Image = null,
                        IsImageVisible = false,
                        NbrLikes = 22,
                        NbrComment = 37,
                        Comment = new CommentDTO()
                        {
                            PhotoUser = "avatarHome.png",
                            FullNameUser = "Yassin Kasimi",
                            Text ="The point of using Lorem Ipsum is that it"
                        }
                    },
                       new DtoStatus()
                    {
                        photoUser = "photoDerrij.png",
                        fullNameUser = "DERRIJ Faris",
                        Topic = "International",
                        BackgroundTopic = App.TopicFiveColor,
                        DatePublication = "4 Jan, 2019 à 05:51",
                        Title = "Félicitation à OCP qui a reçu la médaille d'Or HSE",
                        Image = "EventFour.png",
                        IsImageVisible = true,
                        NbrLikes = 51,
                        NbrComment = 18,
                        Comment = new CommentDTO()
                        {
                            PhotoUser = "avatarWomen.png",
                            FullNameUser = "Amal Haki",
                            Text ="Various versions have evolved over the years"
                        }
                    },
            };

            ListStatuts = StatutsData;
        }

        public Command<Dictionary<string, bool>> Filtrer
        {
            get
            {
                return new Command<Dictionary<string, bool>>((filtresStatuts) =>
                {
                    try
                    {
                        var statutsList = new List<DtoStatus>();

                        bool valueStatut = false, partenariaSelected = filtresStatuts.ContainsValue(true);

                        if (partenariaSelected)
                        {
                            foreach (var item in StatutsData)
                            {
                                filtresStatuts.TryGetValue(item.Topic, out valueStatut);

                                if (valueStatut)
                                {
                                    statutsList.Add(item);
                                }
                            }
                        }
                        else
                        {
                            statutsList = StatutsData;
                        }

                        IsFindData = statutsList.Count > 0 ? false : true;
                        ListStatuts = statutsList.Count > 0 ? new List<DtoStatus>(statutsList) : StatutsData;

                    }
                    catch (Exception Ex)
                    {
                        AppsHelper.Snack(Ex.Message);
                    }
                });
            }
        }
    }
}