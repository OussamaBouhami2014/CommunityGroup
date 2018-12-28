using CommunityGroup.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityGroup.Services
{
    public class ChatMessagesService
    {
        //Connecting to Web Service here
        public ObservableCollection<DtoMessage> listChatMessages = new ObservableCollection<DtoMessage>();

        public ObservableCollection<DtoMessage> GetChatMessages()
        {
            listChatMessages = new ObservableCollection<DtoMessage>
            {
                    new DtoMessage{
                    MessageId = 1,
                    UserName = "MALAL Zakariae",
                    MessageText = "Bonjour, Cv",
                    UserPhoto = "photoMalal.png",
                    //MessageImage = "",
                    Date = "02:11 AM",
                    DateEnvoyer = DateTime.Now,
                    DateReception = DateTime.Now,
                    Vu = false,
                    IsOnline = true,
                    GroupeId = 0,
                    UserId = 1,
                    Statuts = "SentText",
                    },

                    new DtoMessage{
                    MessageId = 2,
                    UserName = "DERRIJ Faris",
                    MessageText = "Envoi moi stp le document relatif à OTN",
                    UserPhoto = "photoDerrij.png",
                    //MessageImage = "empty",
                    Date = "06:14 PM",

                    DateEnvoyer = DateTime.Now,
                    DateReception = DateTime.Now,
                    Vu = false,
                    IsOnline = false,

                    GroupeId = 0,
                    UserId = 2,
                    Statuts = "ReceivedText",
                    },

                    new DtoMessage{
                    MessageId = 3,
                    UserName = "TAHIRI Meriem",
                    MessageText = "Je t'en prie",
                    UserPhoto = "photoTahiri.png",
                    Date = "07:39 AM",

                    DateEnvoyer = DateTime.Now,
                    DateReception = DateTime.Now,
                    Vu = false,
                    IsOnline = true,

                    GroupeId = 1,
                    UserId = 1,
                    Statuts = "SentImage",
                    },

                    new DtoMessage{
                    MessageId = 4,
                    UserName = "EL KHATIB Mehdi",
                    MessageText = "Wé, Hmd et toi ?",
                    UserPhoto = "photoMehdi.png",
                    DateEnvoyer = DateTime.Now,
                    DateReception = DateTime.Now,
                    Vu = false,
                    Date = "01:17 AM",

                    GroupeId = 2,
                    UserId = 2,
                    Statuts = "ReceivedText",
                    },



    };

            //FillListChat();

            return listChatMessages;
        }

        public void FillListChat()
        {
            foreach (var item in listChatMessages)
            {
                if (item.GroupeId != 0)
                {
                    listChatMessages.Remove(item);
                }
            }
        }
    }
}