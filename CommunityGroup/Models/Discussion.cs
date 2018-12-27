﻿using System;
using System.IO;
using Xamarin.Forms;

namespace CommunityGroup.Models
{
    public class Discussion
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        //public MediaFileType MessageVideo { get; set; }

        public ImageSource MessageImage { get; set; }

        public Stream MessageImageStream { get; set; }

        public ImageSource MessageImageSource
        {
            get
            {
                return ImageSource.FromStream(() =>
                {
                    return MessageImageStream;
                });
            }
        }

        public DateTime DateEnvoyer { get; set; }

        public DateTime DateReception { get; set; }

        public bool Vu { get; set; }

        public int GroupeId { get; set; }

        public bool IsOnline { get; set; }

        public int UserId { get; set; }

        public string Statuts { get; set; }
    }
}