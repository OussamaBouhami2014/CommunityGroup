using System;
using System.IO;
using Xamarin.Forms;

namespace CommunityGroup.Models
{
    public class DtoMessage
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        public string UserPhoto { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }

        public DateTime DateEnvoyer { get; set; }

        public DateTime DateReception { get; set; }

        public bool Vu { get; set; }

        public int GroupeId { get; set; }

        public bool IsOnline { get; set; }

        public int UserId { get; set; }

        public string Statuts { get; set; }
    }
}