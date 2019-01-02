using CommunityGroup.Models;
using CommunityGroup.Services;
//using CommunityGroup.Services;
using CommunityGroup.ViewModels;
//using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace CommunityGroup.ViewModels
{
    public class NetworkViewModel : BaseViewModel
    {
        private List<DtoNetwork> _listNetwork;
        public List<DtoNetwork> ListNetwork { get { return _listNetwork; } set { _listNetwork = value; OnPropertyChanged(); } }

        public NetworkViewModel()
        {
            ListNetwork = new List<DtoNetwork>
            {
                    new DtoNetwork{
                    NetworkId = 1,
                    UserName = "MALAL Zakariae",
                    Post = "HR Digital",
                    UserPhoto = "photoMalal.png",
                    Company = "HP",
                    GroupeId = 0,
                    Localite = "NewYork",
                    },
                         new DtoNetwork{
                    NetworkId = 1,
                    UserName = "DERRIJ Faris",
                    Post = "EVP Capital Humain",
                    UserPhoto = "photoDerrij.png",
                    Company = "P&G",
                    GroupeId = 0,
                    Localite = "Chicago",
                    },
                      new DtoNetwork{
                    NetworkId = 1,
                    UserName = "EL KHATIB Mehdi",
                    Post = "Manager Recrutement",
                    UserPhoto = "photoMehdi.png",
                    Company = "IBM",
                    GroupeId = 0,
                    Localite = "NewYork",
                    },

                      new DtoNetwork{
                    NetworkId = 1,
                    UserName = "TAHIRI Meriem",
                    Post = "Director R&D",
                    UserPhoto = "photoTahiri.png",
                    Company = "DELL",
                    GroupeId = 0,
                    Localite = "Paris",
                    },
                         new DtoNetwork{
                    NetworkId = 1,
                    UserName = "BOUHAMI Oussama",
                    Post = "VP Ressources Humaines",
                    UserPhoto = "avatarHome.png",
                    Company = "TOTAL",
                    GroupeId = 0,
                    Localite = "MIAMI",
                    },
                      new DtoNetwork{
                    NetworkId = 1,
                    UserName = "ALAOUI Dounia",
                    Post = "VP Develeppement RH",
                    UserPhoto = "avatarWomen.png",
                    Company = "APPLE",
                    GroupeId = 0,
                    Localite = "BRUXELLES",
                    },
                      new DtoNetwork{
                    NetworkId = 1,
                    UserName = "OUKACHA Anouar",
                    Post = "Chargé de mission",
                    UserPhoto = "avatarProfil.png",
                    Company = "BNP PARIBAS",
                    GroupeId = 0,
                    Localite = "PARIS",
                    },

    };
        }
    }
}