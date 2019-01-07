using System;
using Xamarin.Forms;

namespace CommunityGroup.Models
{
    public class DtoStatus
    {
        public int StatutId { get; set; }
        public string photoUser { get; set; }
        public string fullNameUser { get; set; }
        public string Topic { get; set; }
        public Color BackgroundTopic { get; set; }
        public string DatePublication { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public CommentDTO Comment{ get; set; }
        public int NbrLikes { get; set; }
        public int NbrComment { get; set; }
        public bool IsImageVisible { get; set; }
    }
}