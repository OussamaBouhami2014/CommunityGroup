using System;
namespace CommunityGroup.Models
{
    public class DtoNetwork
    {
        public int NetworkId { get; set; }

        public string Post { get; set; }

        public string UserPhoto { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }

        public DateTime DateEnvoyer { get; set; }

        public DateTime DateReception { get; set; }

        public bool Vu { get; set; }

        public int GroupeId { get; set; }

        public bool IsOnline { get; set; }

        public int UserId { get; set; }

        public string Localite { get; set; }
    }
}