using System;
namespace CommunityGroup.Models
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string PhotoUser { get; set; }
        public string FullNameUser { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ImageFileUrl { get; set; }
        public string AttachementFileUrl { get; set; }
        public long SourceId { get; set; }
        public string CreatedByFullName { get; set; }
        public string CreatedBy { get; set; }
    }
}