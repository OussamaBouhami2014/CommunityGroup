
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
    public class ChatMessageViewModel : BaseViewModel
    {
        private ObservableCollection<DtoMessage> _chatList;

        private ObservableCollection<DtoMessage> ListChatParGroupe
        {
            get { return _chatList; }
            set
            {
                _chatList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DtoMessage> ChatList
        {
            get { return _chatList; }
            set
            {
                _chatList = value;
                OnPropertyChanged();
            }
        }

        private string _sendMsgText;

        public string SendMsgText
        {
            get { return _sendMsgText; }
            set { _sendMsgText = value; OnPropertyChanged(); }
        }


        private ImageSource _sendMsgImage;

        public ImageSource SendMsgImage
        {
            get { return _sendMsgImage; }
            set { _sendMsgImage = value; OnPropertyChanged(); }
        }

        //private MediaFileType _sendMsgVideo;

        //public MediaFileType SendMsgVideo
        //{
        //    get { return _sendMsgVideo; }
        //    set { _sendMsgVideo = value; OnPropertyChanged(); }
        //}

        private string _statutMsg;

        public string StatutsMsg
        {
            get { return _statutMsg; }
            set { _statutMsg = value; OnPropertyChanged(); }
        }

        public ICommand SendMessage { get; set; }

        public ChatMessageViewModel()
        {
            var chatMessageService = new ChatMessagesService();

            ChatList = chatMessageService.GetChatMessages();

            //foreach (var item in chatMessageService.GetChatMessages())
            //{
            //  if (item.GroupeId == 0)
            //  {
            //      //ListChatParGroupe.Add(item);
            //  }
            //}

            //ChatList = ListChatParGroupe;

            SendMessage = new Command(() =>

            {
                ChatList.Add(new DtoMessage
                {
                    MessageText = SendMsgText,
                    //MessageImage = SendMsgImage,
                    //MessageVideo = SendMsgVideo,
                    Statuts = StatutsMsg,
                    DateEnvoyer = DateTime.Now
                });
            });
        }

        public Command RemoveMessage
        {
            get
            {
                return new Command<DtoMessage>((message) =>
                {
                    ChatList.Remove(message);
                });
            }
        }

    }
}