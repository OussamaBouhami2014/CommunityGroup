using System;
using CommunityGroup.Models;
using CommunityGroup.UI.Chat;
using Xamarin.Forms;

namespace CommunityGroup.Controls
{
    public class ChatDataTemplateSelector : DataTemplateSelector
    {
        private DataTemplate fromTemplateMsgText = new DataTemplate(typeof(FromTemplateMsgText));
        private DataTemplate toTemplateMsgText = new DataTemplate(typeof(ToTemplateMsgText));

        //private DataTemplate fromTemplateMsgImage = new DataTemplate(typeof(FromTemplateMsgImage));
        //private DataTemplate toTemplateMsgImage = new DataTemplate(typeof(ToTemplateMsgImage));

        //private DataTemplate fromTemplateMsgVideo = new DataTemplate(typeof(FromTemplateMsgVideo));
        //private DataTemplate toTemplateMsgVideo = new DataTemplate(typeof(ToTemplateMsgVideo));


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as DtoMessage;

            if (!string.IsNullOrEmpty(message.Statuts))
            {
                switch (message.Statuts)
                {
                    case "SentText":
                        return fromTemplateMsgText;

                    case "ReceivedText":
                        return toTemplateMsgText;

                    //case "SentImage":
                    //    return fromTemplateMsgImage;

                    //case "ReceivedImage":
                    //    return toTemplateMsgImage;

                    //case "SentVideo":
                    //    return fromTemplateMsgVideo;

                    //case "ReceivedVideo":
                        //return toTemplateMsgVideo;
                }

            }

            return null;

            //return ((ChatMessage)item).Statuts.ToUpper().Equals("SENT") ? FromTemplate : ToTemplate;
        }
    }
}