using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityGroup.Models;

namespace CommunityGroup.ViewModels
{
    public class ActualiteViewModel : BaseViewModel
    {
        private bool _isFindData;
        public bool IsFindData { get { return _isFindData; } set { _isFindData = value; OnPropertyChanged(); } }

        private List<DtoActualite> _listActualite;
        public List<DtoActualite> ListActualite { get { return _listActualite; } set { _listActualite = value; OnPropertyChanged(); } }

        private int _position = 0;
        public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }

        private int CarouselCount = 0;

        public ActualiteViewModel()
        {
            ListActualite = new List<DtoActualite>()
            {
                new DtoActualite() {
                    ActualiteId = 1,
                    CodeUnivers = "NEWS",
                    ColorUnivers = App.RedColor,
                    Title = "Economie circulaire : OCP partage sa vision",
                    Text = "En lançant son Programme d’Economie circulaire, le Groupe OCP ne souhaite pas seulement créer une nouvelle dynamique verte en son sein, mais espère aussi étendre sa vision environnementale à l’ensemble de son écosystème, industriels, fédérations, associations et d’autres. C’est pourquoi, en plus de faire la promotion de son programme au sein du Groupe, les équipes en charge du programme saisissent toute occasion qui se présente, voire prennent l’initiative d’en créer pour échanger autour de cette vision en externe. C’était récemment le cas à la Conférence africaine pour la gestion responsable des produits chimiques. C’était aussi le cas quelques semaines avant auprès de la Chambre de Commerce Suisse au Maroc (CCSM).",
                    Details = "OCP News",
                    ColorDetail = App.BlueColor,
                    ImageActualite = "economie_circulaire.png",
                    DateActualite = DateTime.Now.AddDays(-12),
                    DatePublication = DateTime.Now.AddDays(-12),
                     NbrLike = 11,
                    NbrComment = 23,
                    IsVue = false,
                    IsVue2 = true
                    },

                new DtoActualite() {
                    ActualiteId = 2,
                    CodeUnivers = "NEWS",
                    ColorUnivers = App.RedColor,
                    Title="OCP prend part à la 11ème Foire internationale de commerce à Addis-Abeba",
                    Text="Addis Abeba a abrité, du 1er au 5 novembre dernier, la 11ème édition de la Foire internationale de commerce. Pour la seconde fois, OCP a pris part à cet événement, organisé par la Chambre Ethiopienne de Commerce pour présenter au grand public Ethiopien ses activités.",
                    Details = "OCP Africa News",
                    ColorDetail = App.GreenColor,
                    DateActualite = DateTime.Now.AddDays(-2),
                    DatePublication = DateTime.Now.AddDays(-2),
                    ImageActualite = "participation_addis_abeba.jpg",
                     NbrLike = 17,
                    NbrComment = 13,
                    IsVue = false,
                    IsVue2 = true,
                    },

                 new DtoActualite() {
                    ActualiteId = 3,
                    CodeUnivers = "OFFRE",
                    ColorUnivers = App.OrangeColor,
                    Title = "Recherche de profil UX/UI 3ans d'Exp.",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
                    Details = "Offre d'emploi",
                    ColorDetail = App.YellowColor,
                    ImageActualite = "uiux-01.png",
                    DateActualite = DateTime.Now.AddDays(-12),
                    DatePublication = DateTime.Now.AddDays(-12),
                     NbrLike = 22,
                    NbrComment = 10,
                    IsVue = true,
                    IsVue2 = false,
                    },

                new DtoActualite() {
                    ActualiteId = 4,
                    CodeUnivers = "OFFRE",
                    ColorUnivers = App.OrangeColor,
                    Title = "Appel à candidature PHD à l'UM6P",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
                    Details = "Appel à candidature",
                    ColorDetail = App.BlueColor,
                    DateActualite = DateTime.Now.AddDays(-2),
                    DatePublication = DateTime.Now.AddDays(-2),
                    ImageActualite = "um6p.png",
                    IsVue = true,
                    IsVue2 = false,
                    },
                    
            };
        }
    }
}